using Microsoft.AspNetCore.Mvc;
using SocietyManagementWeb.Classes;
using SocietyManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementWeb.Controllers
{
    public class PaymentController : BaseController
    {
        DbConnection ObjDBConnection = new DbConnection();
        TaxMasterHelpers ObjTaxMasterHelpers = new TaxMasterHelpers();
        AccountGroupHelpers ObjAccountGroupHelpers = new AccountGroupHelpers();

        public IActionResult Index(long id)
        {
            try
            {
                bool isreturn = false;
                INIT(ref isreturn);
                if (isreturn)
                {
                    return RedirectToAction("index", "dashboard");
                }
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                long userId = GetIntSession("UserId");
                int YearId = Convert.ToInt32(GetIntSession("YearId"));
                var yearList = DbConnection.GetYearList(companyId, YearId);
                RecPayModel recPay = new RecPayModel();
                recPay.RecPay = new RecPayGridModel();
                recPay.VouTypeList = ObjTaxMasterHelpers.GetVoucherTypeList("PAY", companyId);
                recPay.DepList = ObjTaxMasterHelpers.GetDepartmentDropdown(companyId);
                recPay.DCList = ObjAccountGroupHelpers.GetPaymentCrDr();
                recPay.BookAccList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId, 1);
                recPay.RecPay.VcmAccountList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId, 0);
                var yearData = DbConnection.GetYearListByCompanyId(Convert.ToInt32(companyId)).Where(x => x.YearVou == YearId).FirstOrDefault();
                if (yearData != null)
                {
                    recPay.StartDt = yearData.StartDate;
                    recPay.EndDt = yearData.EndDate;
                }
                string[] yearSplit = yearList[0].Text.Split('-');
                if (yearSplit != null && yearSplit.Length > 0)
                {
                    recPay.VcmDt = new DateTime(Convert.ToInt32(yearSplit[0]), 4, 01).AddDays(0).ToString("yyyy-MM-dd");
                }
                SqlParameter[] Parameters = new SqlParameter[5];
                Parameters[0] = new SqlParameter("@VcmVou", id);
                Parameters[1] = new SqlParameter("@Flg", 4);
                Parameters[2] = new SqlParameter("@CmpVou", companyId);
                Parameters[3] = new SqlParameter("@Yrvou", YearId);
                Parameters[4] = new SqlParameter("@VouType", "PAY");
                DataTable DtRec = ObjDBConnection.CallStoreProcedure("GetRecPayDetails", Parameters);
                if (DtRec != null && DtRec.Rows.Count > 0)
                {
                    recPay.VcmDepVou = DbConnection.ParseInt32(DtRec.Rows[0]["VcmDepVou"].ToString());
                    recPay.VcmVouTypeN = DbConnection.ParseInt32(DtRec.Rows[0]["VcmVouTypeN"].ToString());
                    string voutype = DtRec.Rows[0]["VcmVouType"].ToString();
                    recPay.VcmVouType = (voutype).TrimEnd();
                    recPay.VcmDrCrVou = DbConnection.ParseInt32(DtRec.Rows[0]["VcmDrcr"].ToString());
                    recPay.VcmBookVou = DbConnection.ParseInt32(DtRec.Rows[0]["VcmBookVou"].ToString());
                    recPay.VcmDt = !string.IsNullOrWhiteSpace(DtRec.Rows[0]["VcmDate"].ToString()) ? Convert.ToDateTime(DtRec.Rows[0]["VcmDate"].ToString()).ToString("yyyy-MM-dd") : "";
                    recPay.VcmVNo = DbConnection.ParseInt32(ObjDBConnection.GetLatestVoucherNumber("VchMst", recPay.VcmVouTypeN, companyId, YearId));
                    string vno = DbConnection.ParseInt32(recPay.VcmVNo).ToString();
                    recPay.VcmRefNo = (DtRec.Rows[0]["VcmVouType"].ToString()).TrimEnd() + "-" + (vno).TrimStart();
                }
                else
                {
                    recPay.VcmDrCrVou = 2;
                    recPay.VcmVNo = DbConnection.ParseInt32(ObjDBConnection.GetLatestVoucherNumber("VchMst", recPay.VcmVouTypeN, companyId, YearId));
                    recPay.VcmVouType = "PAY";
                    string vno = DbConnection.ParseInt32(recPay.VcmVNo).ToString();
                    recPay.VcmRefNo = (recPay.VcmVouType).TrimEnd() + "-" + (vno).TrimStart();
                }

                if (id > 0)
                {
                    recPay.VcmVou = Convert.ToInt32(id);
                    SqlParameter[] sqlParameters = new SqlParameter[5];
                    sqlParameters[0] = new SqlParameter("@VcmVou", id);
                    sqlParameters[1] = new SqlParameter("@Flg", 2);
                    sqlParameters[2] = new SqlParameter("@CmpVou", companyId);
                    sqlParameters[3] = new SqlParameter("@Yrvou", YearId);
                    sqlParameters[4] = new SqlParameter("@VouType", "PAY");
                    DataTable DtAccOpen = ObjDBConnection.CallStoreProcedure("GetRecPayDetails", sqlParameters);
                    if (DtAccOpen != null && DtAccOpen.Rows.Count > 0)
                    {
                        recPay.VcmVou = DbConnection.ParseInt32(id);
                        recPay.VcmDepVou = DbConnection.ParseInt32(DtAccOpen.Rows[0]["VcmDepVou"].ToString());
                        recPay.VcmVouTypeN = DbConnection.ParseInt32(DtAccOpen.Rows[0]["VcmVouTypeN"].ToString());
                        recPay.VcmVouType = DtAccOpen.Rows[0]["VcmVouType"].ToString();
                        recPay.VcmRefNo = DtAccOpen.Rows[0]["VcmRefNo"].ToString();
                        recPay.VcmBookVou = DbConnection.ParseInt32(DtAccOpen.Rows[0]["VcmBookVou"].ToString());
                        recPay.VcmDrCrVou = DbConnection.ParseInt32(DtAccOpen.Rows[0]["VcmDrCr"].ToString());
                        recPay.VcmVNo = DbConnection.ParseInt32(DtAccOpen.Rows[0]["VcmVNo"].ToString());
                        recPay.VcmDt = !string.IsNullOrWhiteSpace(DtAccOpen.Rows[0]["VcmDate"].ToString()) ? Convert.ToDateTime(DtAccOpen.Rows[0]["VcmDate"].ToString()).ToString("yyyy-MM-dd") : "";
                        recPay.VcmAmount = Convert.ToDecimal(DtAccOpen.Rows[0]["VcmAmount"].ToString());

                        List<RecPayGridModel> lstobl = new List<RecPayGridModel>();

                        for (int i = 0; i < DtAccOpen.Rows.Count; i++)
                        {
                            RecPayGridModel RPTrn = new RecPayGridModel();
                            RPTrn.VcmAAccVou = Convert.ToInt32(DtAccOpen.Rows[i]["VcmAAccVou"].ToString());
                            RPTrn.VcmAAmt = Convert.ToDecimal(DtAccOpen.Rows[i]["VcmAAmount"].ToString());
                            RPTrn.VcmARemarks = DtAccOpen.Rows[i]["VcmARemarks"].ToString();
                            RPTrn.VcmARefNo = DtAccOpen.Rows[i]["VcmARefNo"].ToString();
                            RPTrn.VcmASrNo = Convert.ToInt32(DtAccOpen.Rows[i]["VcmASrNo"].ToString());
                            lstobl.Add(RPTrn);
                        }
                        recPay.RPList = lstobl;
                    }
                }
                return View(recPay);
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(long id, RecPayModel recPayModel)
        {
            try
            {
                bool isreturn = false;
                INIT(ref isreturn);
                if (isreturn)
                {
                    return RedirectToAction("index", "dashboard");
                }
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                int YearId = Convert.ToInt32(GetIntSession("YearId"));

                long userId = GetIntSession("UserId");
                recPayModel.RecPay = new RecPayGridModel();
                recPayModel.DepList = ObjTaxMasterHelpers.GetDepartmentDropdown(companyId);
                recPayModel.DCList = ObjAccountGroupHelpers.GetPaymentCrDr();
                recPayModel.BookAccList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId, 1);
                recPayModel.RecPay.VcmAccountList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId, 0);
                recPayModel.VouTypeList = ObjTaxMasterHelpers.GetVoucherTypeList("PAY", companyId);
                if (!string.IsNullOrWhiteSpace(recPayModel.VcmDt) && recPayModel.RPList.Count > 0)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[15];
                    sqlParameters[0] = new SqlParameter("@VoucherNumber", recPayModel.VcmVNo);
                    sqlParameters[1] = new SqlParameter("@Date", recPayModel.VcmDt);
                    sqlParameters[2] = new SqlParameter("@Amount", recPayModel.VcmAmount);
                    sqlParameters[3] = new SqlParameter("@Vou", id);
                    sqlParameters[4] = new SqlParameter("@DepVou", recPayModel.VcmDepVou);
                    sqlParameters[5] = new SqlParameter("@TrnVou", recPayModel.VcmVouTypeN);
                    sqlParameters[6] = new SqlParameter("@VouType", recPayModel.VcmVouType);
                    sqlParameters[7] = new SqlParameter("@BookVou", recPayModel.VcmBookVou);
                    sqlParameters[8] = new SqlParameter("@CrDr", recPayModel.VcmDrCrVou);
                    sqlParameters[9] = new SqlParameter("@RefNo", recPayModel.VcmRefNo);
                    sqlParameters[10] = new SqlParameter("@DateNumber", ObjDBConnection.GetNumericDate(recPayModel.VcmDt));
                    sqlParameters[11] = new SqlParameter("@CmpVou", companyId);
                    sqlParameters[12] = new SqlParameter("@Yrvou", YearId);
                    sqlParameters[13] = new SqlParameter("@Remks", recPayModel.VcmRemark);
                    sqlParameters[14] = new SqlParameter("@UsrId", userId);
                    DataTable DtRec = ObjDBConnection.CallStoreProcedure("RecPayMst_Insert", sqlParameters);
                    if (DtRec != null && DtRec.Rows.Count > 0)
                    {
                        int masterId = DbConnection.ParseInt32(DtRec.Rows[0][0].ToString());
                        if (masterId > 0)
                        {
                            for (int i = 0; i < recPayModel.RPList.Count; i++)
                            {

                                SqlParameter[] parameter = new SqlParameter[14];
                                parameter[0] = new SqlParameter("@VcmAVcmId", masterId);
                                parameter[1] = new SqlParameter("@PartyId", recPayModel.RPList[i].VcmAAccVou);
                                parameter[2] = new SqlParameter("@Amount", recPayModel.RPList[i].VcmAAmt);
                                parameter[3] = new SqlParameter("@DrCr", recPayModel.VcmDrCrVou);
                                parameter[4] = new SqlParameter("@Remarks", recPayModel.RPList[i].VcmARemarks);
                                parameter[5] = new SqlParameter("@RefNo", recPayModel.RPList[i].VcmARefNo);
                                parameter[6] = new SqlParameter("@SrNo", (i + 1));
                                parameter[7] = new SqlParameter("@CmpVou", companyId);
                                parameter[8] = new SqlParameter("@Yrvou", YearId);
                                parameter[9] = new SqlParameter("@Depvou", recPayModel.VcmDepVou);
                                parameter[10] = new SqlParameter("@Othvou", recPayModel.VcmBookVou);
                                parameter[11] = new SqlParameter("@VouType", recPayModel.VcmVouType);
                                parameter[12] = new SqlParameter("@VcmADt", recPayModel.VcmDt);
                                parameter[13] = new SqlParameter("@VcmADtN", ObjDBConnection.GetNumericDate(recPayModel.VcmDt));
                                DtRec = ObjDBConnection.CallStoreProcedure("RecPayTran_Insert", parameter);
                            }
                            int status = DbConnection.ParseInt32(DtRec.Rows[0][0].ToString());
                            if (status == 0)
                            {
                                recPayModel.VcmDt = Convert.ToDateTime(recPayModel.VcmDt).ToString("yyyy-MM-dd");
                                SetErrorMessage("Dulplicate Vou.No Details");
                                ViewBag.FocusType = "1";
                                return View(recPayModel);
                            }
                            else
                            {
                                if (id > 0)
                                {
                                    SetSuccessMessage("Updated Sucessfully");
                                }
                                else
                                {
                                    SetSuccessMessage("Inserted Sucessfully");
                                }
                                return RedirectToAction("index", "Payment", new { id = 0 });
                            }
                        }
                        else
                        {
                            if (masterId == -1)
                            {
                                recPayModel.VcmDt = Convert.ToDateTime(recPayModel.VcmDt).ToString("yyyy-MM-dd");
                                SetErrorMessage("Dulplicate Vou.No Details");
                                ViewBag.FocusType = "1";
                                return View(recPayModel);
                            }
                            else
                            {
                                recPayModel.VcmDt = Convert.ToDateTime(recPayModel.VcmDt).ToString("yyyy-MM-dd");
                                SetErrorMessage("Insert error");
                                ViewBag.FocusType = "1";
                                return View(recPayModel);
                            }
                        }
                    }
                    else
                    {
                        recPayModel.VcmDt = Convert.ToDateTime(recPayModel.VcmDt).ToString("yyyy-MM-dd");
                        SetErrorMessage("Please Enter the Value");
                        ViewBag.FocusType = "1";
                        return View(recPayModel);
                    }
                }
                else
                {
                    recPayModel.VcmDt = Convert.ToDateTime(recPayModel.VcmDt).ToString("yyyy-MM-dd");
                    SetErrorMessage("Please Enter the Value");
                    ViewBag.FocusType = "1";
                    return View(recPayModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(new RecPayModel());
        }

        public IActionResult Delete(long id)
        {
            try
            {
                RecPayModel recPay = new RecPayModel();
                if (id > 0)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@VcmVou", id);
                    sqlParameters[1] = new SqlParameter("@Flg", 1);
                    DataTable DtAccountOpening = ObjDBConnection.CallStoreProcedure("GetRecPayDetails", sqlParameters);
                    if (DtAccountOpening != null && DtAccountOpening.Rows.Count > 0)
                    {
                        SetSuccessMessage("Payment Deleted Sucessfully");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("index", "Payment");
        }


        public IActionResult GetReportView(int gridMstId, int pageIndex, int pageSize, string searchValue, string columnName, string sortby)
        {
            GetReportDataModel getReportDataModel = new GetReportDataModel();
            try
            {
                #region User Rights
                long userId = GetIntSession("UserId");
                UserFormRightModel userFormRights = new UserFormRightModel();
                string currentURL = "/Payment/Index";
                userFormRights = GetUserRights(userId, currentURL);
                if (userFormRights == null)
                {
                    SetErrorMessage("You do not have right to access requested page. Please contact admin for more detail.");
                }
                ViewBag.userRight = userFormRights;
                #endregion

                double startRecord = 0;
                if (pageIndex > 0)
                {
                    startRecord = (pageIndex - 1) * pageSize;
                }
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                int YearId = Convert.ToInt32(GetIntSession("YearId"));
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@Vou", 0);
                sqlParameters[1] = new SqlParameter("@Flg", 2);
                sqlParameters[2] = new SqlParameter("@CmpVou", companyId);
                DataTable DtDepartment = ObjDBConnection.CallStoreProcedure("GetDepartmentCheck", sqlParameters);
                if (DtDepartment != null && DtDepartment.Rows.Count > 0)
                {
                    int status = DbConnection.ParseInt32(DtDepartment.Rows[0][0].ToString());
                    if (status == 0)
                    {
                        getReportDataModel = GetReportData(gridMstId, pageIndex, pageSize, columnName, sortby, searchValue, companyId, 0, YearId);
                        if (getReportDataModel.IsError)
                        {
                            ViewBag.Query = getReportDataModel.Query;
                            return PartialView("_reportView");
                        }
                        getReportDataModel.pageIndex = pageIndex;
                        getReportDataModel.ControllerName = "Payment";
                    }
                    else
                    {
                        SetErrorMessage("First Add Department");
                        ViewBag.FocusType = "1";
                        return View();
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return PartialView("_reportView", getReportDataModel);
        }

        public IActionResult GetLatestVouNumber(string vou)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(vou))
                {
                    int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                    int YearId = Convert.ToInt32(GetIntSession("YearId"));
                    string value = ObjDBConnection.GetLatestVoucherNumber("VchMst", DbConnection.ParseInt32(vou), companyId, YearId);
                    return Json(new { response = true, message = value });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(new { response = true, message = string.Empty });
        }

        public IActionResult GetBalance(string bookvou, string dt)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(bookvou))
                {
                    int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                    int YearId = Convert.ToInt32(GetIntSession("YearId"));
                    int dtn = Convert.ToInt32(ObjDBConnection.GetNumericDate(dt));
                    string value = ObjDBConnection.GetBalance(DbConnection.ParseInt32(bookvou), companyId, YearId, dtn);
                    return Json(new { response = true, message = value });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(new { response = true, message = string.Empty });
        }
        public IActionResult GetBalance_New(string bookvou, string dt)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(bookvou))
                {
                    int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                    int YearId = Convert.ToInt32(GetIntSession("YearId"));
                    int dtn = Convert.ToInt32(ObjDBConnection.GetNumericDate(dt));
                    string value = ObjDBConnection.GetBalance_New(DbConnection.ParseInt32(bookvou), companyId, YearId, dtn);
                    return Json(new { response = true, message = value });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(new { response = true, message = string.Empty });
        }
        public IActionResult GetClosBalance(string bookvou, string dt, int vcmvou, decimal grdAmt)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(bookvou))
                {
                    int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                    int YearId = Convert.ToInt32(GetIntSession("YearId"));
                    int dtn = Convert.ToInt32(ObjDBConnection.GetNumericDate(dt));
                    int flg = 0;
                    if (vcmvou == 0)
                        flg = 1;
                    else
                        flg = 2;
                    string value = ObjDBConnection.GetClosBalance(DbConnection.ParseInt32(bookvou), companyId, YearId, dtn, vcmvou, flg, "PAY", grdAmt);
                    return Json(new { response = true, message = value });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Json(new { response = true, message = string.Empty });
        }

        private void INIT(ref bool isReturn)
        {
            #region User Rights
            long userId = GetIntSession("UserId");
            UserFormRightModel userFormRights = new UserFormRightModel();
            string currentURL = GetCurrentURL();
            userFormRights = GetUserRights(userId, currentURL);
            if (userFormRights == null)
            {
                SetErrorMessage("You do not have right to access requested page. Please contact admin for more detail.");
                isReturn = true;
            }
            ViewBag.userRight = userFormRights;

            #endregion

            #region Dynamic Report

            if (userFormRights != null)
            {
                ViewBag.layoutList = GetGridLayoutDropDown(DbConnection.GridTypeView, userFormRights.ModuleId);
                ViewBag.pageNoList = GetPageNo();
            }

            #endregion
        }

        public IActionResult ExportToExcelPDF(int gridMstId, string searchValue, int type)
        {
            GetReportDataModel getReportDataModel = new GetReportDataModel();
            try
            {
                long userId = GetIntSession("UserId");
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                int YearId = Convert.ToInt32(GetIntSession("YearId"));
                var companyDetails = DbConnection.GetCompanyDetailsById(companyId);
                getReportDataModel = getReportDataModel = GetReportData(gridMstId, 0, 0, "", "", searchValue, companyId, 0, YearId, "", 0, 1);
                if (type == 1)
                {
                    var bytes = Excel(getReportDataModel, "Payment Report", companyDetails.CmpName);
                    return File(
                          bytes,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                          "Payment.xlsx");
                }
                else
                {
                    var bytes = PDF(getReportDataModel, "Payment Report", companyDetails.CmpName);
                    return File(
                          bytes,
                          "application/pdf",
                          "Payment.pdf");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
