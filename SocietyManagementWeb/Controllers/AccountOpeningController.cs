using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SocietyManagementWeb.Classes;
using SocietyManagementWeb.Models;

namespace SocietyManagementWeb.Controllers
{
    public class AccountOpeningController : BaseController
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
                AccountOpeningModel accountOpeningModel = new AccountOpeningModel();
                accountOpeningModel.OpeningBal = new OpeningBalGridModel();
                accountOpeningModel.DepList = ObjTaxMasterHelpers.GetDepartmentDropdown(companyId);
                accountOpeningModel.OpeningBal.OblAccountList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId,0);
                accountOpeningModel.OpeningBal.CrDrList = ObjAccountGroupHelpers.GetAccountCrDr();
                string[] yearSplit = yearList[0].Text.Split('-');
                if (yearSplit != null && yearSplit.Length > 0)
                {
                    accountOpeningModel.OblDt = new DateTime(Convert.ToInt32(yearSplit[0]), 4, 01).AddDays(-1).ToString("yyyy-MM-dd");
                }
                //accountOpeningModel.OblDt = DateTime.Now.ToString("yyyy-MM-dd");
                accountOpeningModel.OblVNo = DbConnection.ParseInt32(ObjDBConnection.GetLatestVoucherNumber("OblMst", 0, companyId));
                if (id > 0)
                {
                    accountOpeningModel.OblVou = Convert.ToInt32(id);
                    SqlParameter[] sqlParameters = new SqlParameter[4];
                    sqlParameters[0] = new SqlParameter("@OblVou", id);
                    sqlParameters[1] = new SqlParameter("@Flg", 2);
                    sqlParameters[2] = new SqlParameter("@CmpVou", companyId);
                    sqlParameters[3] = new SqlParameter("@Yrvou", YearId);
                    DataTable DtAccOpen = ObjDBConnection.CallStoreProcedure("GetAccountOpeningDetails", sqlParameters);
                    if (DtAccOpen != null && DtAccOpen.Rows.Count > 0)
                    {
                        accountOpeningModel.OblVou = DbConnection.ParseInt32(id);
                        accountOpeningModel.OblDepVou = DbConnection.ParseInt32(DtAccOpen.Rows[0]["OblDepVou"].ToString());
                        accountOpeningModel.OblVNo = DbConnection.ParseInt32(DtAccOpen.Rows[0]["OblVNo"].ToString());
                        accountOpeningModel.OblDt = !string.IsNullOrWhiteSpace(DtAccOpen.Rows[0]["OblDate"].ToString()) ? Convert.ToDateTime(DtAccOpen.Rows[0]["OblDate"].ToString()).ToString("yyyy-MM-dd") : "";
                        accountOpeningModel.OblAmount = Convert.ToDecimal(DtAccOpen.Rows[0]["OblAmount"].ToString());

                        List<OpeningBalGridModel> lstobl = new List<OpeningBalGridModel>();

                        for (int i = 0; i < DtAccOpen.Rows.Count; i++)
                        {
                            OpeningBalGridModel OblTran = new OpeningBalGridModel();
                            OblTran.OblAAccVou = Convert.ToInt32(DtAccOpen.Rows[i]["OblAAccVou"].ToString());
                            OblTran.OblAAmt = Convert.ToDecimal(DtAccOpen.Rows[i]["OblAAmount"].ToString());
                            OblTran.OblACrDr = Convert.ToInt32(DtAccOpen.Rows[i]["OblACrDr"].ToString());
                            OblTran.OblARemks = DtAccOpen.Rows[i]["OblARemark"].ToString();
                            OblTran.OblASrNo = Convert.ToInt32(DtAccOpen.Rows[i]["OblASrNo"].ToString());
                            lstobl.Add(OblTran);
                        }
                        accountOpeningModel.OblList = lstobl;
                    }
                }
                return View(accountOpeningModel);
            }
            catch (Exception ex)
            {

            }
            return View(new AccountOpeningModel());
        }

        [HttpPost]
        public IActionResult Index(long id, AccountOpeningModel accountOpeningModel)
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
                accountOpeningModel.OpeningBal = new OpeningBalGridModel();
                accountOpeningModel.OpeningBal.OblAccountList = ObjTaxMasterHelpers.GetSalesAccountDropdown(companyId,0);
                accountOpeningModel.DepList = ObjTaxMasterHelpers.GetDepartmentDropdown(companyId);
                accountOpeningModel.OpeningBal.CrDrList = ObjAccountGroupHelpers.GetAccountCrDr();
                if (!string.IsNullOrWhiteSpace(accountOpeningModel.OblDt) && !string.IsNullOrWhiteSpace(Convert.ToInt32(accountOpeningModel.OblDepVou).ToString()) && accountOpeningModel.OblList.Count > 0) 
                {
                    SqlParameter[] sqlParameters = new SqlParameter[8];
                    sqlParameters[0] = new SqlParameter("@VoucherNumber", accountOpeningModel.OblVNo);
                    sqlParameters[1] = new SqlParameter("@Date", accountOpeningModel.OblDt);
                    sqlParameters[2] = new SqlParameter("@AmountTotal", accountOpeningModel.OblAmount);
                    sqlParameters[3] = new SqlParameter("@Vou", id);
                    sqlParameters[4] = new SqlParameter("@DepVou", accountOpeningModel.OblDepVou);
                    sqlParameters[5] = new SqlParameter("@DateNumber", ObjDBConnection.GetNumericDate(accountOpeningModel.OblDt));
                    sqlParameters[6] = new SqlParameter("@CmpVou", companyId);
                    sqlParameters[7] = new SqlParameter("@Yrvou", YearId);
                    DataTable DtAccOpening = ObjDBConnection.CallStoreProcedure("AccountOpeningMst_Insert", sqlParameters);
                    if (DtAccOpening != null && DtAccOpening.Rows.Count > 0)
                    {
                        int masterId = DbConnection.ParseInt32(DtAccOpening.Rows[0][0].ToString());
                        if (masterId > 0)
                        {
                            for (int i = 0; i < accountOpeningModel.OblList.Count; i++)
                            {

                                SqlParameter[] parameter = new SqlParameter[8];
                                parameter[0] = new SqlParameter("@AccountOpnId", masterId);
                                parameter[1] = new SqlParameter("@PartyId", accountOpeningModel.OblList[i].OblAAccVou);
                                parameter[2] = new SqlParameter("@Amount", accountOpeningModel.OblList[i].OblAAmt);
                                parameter[3] = new SqlParameter("@DrCr", accountOpeningModel.OblList[i].OblACrDr);
                                parameter[4] = new SqlParameter("@Remarks", accountOpeningModel.OblList[i].OblARemks);
                                parameter[5] = new SqlParameter("@SrNo", (i + 1));
                                parameter[6] = new SqlParameter("@CmpVou", companyId);
                                parameter[7] = new SqlParameter("@Yrvou", YearId);
                                DtAccOpening = ObjDBConnection.CallStoreProcedure("AccountOpeningTran_Insert", parameter);
                            }
                            int status = DbConnection.ParseInt32(DtAccOpening.Rows[0][0].ToString());
                            if (status == 0)
                            {
                                accountOpeningModel.OblDt = Convert.ToDateTime(accountOpeningModel.OblDt).ToString("yyyy-MM-dd");
                                SetErrorMessage("Dulplicate Vou.No Details");
                                ViewBag.FocusType = "1";
                                return View(accountOpeningModel);
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
                                return RedirectToAction("index", "AccountOpening", new { id = 0 });
                            }
                        }
                        else
                        {
                            accountOpeningModel.OblDt = Convert.ToDateTime(accountOpeningModel.OblDt).ToString("yyyy-MM-dd");
                            SetErrorMessage("Insert error");
                            ViewBag.FocusType = "1";
                            return View(accountOpeningModel);
                        }
                    }
                    else
                    {
                        accountOpeningModel.OblDt = Convert.ToDateTime(accountOpeningModel.OblDt).ToString("yyyy-MM-dd");
                        SetErrorMessage("Please Enter the Value");
                        ViewBag.FocusType = "1";
                        return View(accountOpeningModel);
                    }
                }
                else
                {
                    accountOpeningModel.OblDt = Convert.ToDateTime(accountOpeningModel.OblDt).ToString("yyyy-MM-dd");
                    SetErrorMessage("Please Enter the Value");
                    ViewBag.FocusType = "1";
                    return View(accountOpeningModel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(new AccountOpeningModel());
        }

        public IActionResult Delete(long id)
        {
            try
            {
                AccountOpeningModel accountOpeningModel = new AccountOpeningModel();
                if (id > 0)
                {
                    SqlParameter[] sqlParameters = new SqlParameter[2];
                    sqlParameters[0] = new SqlParameter("@OblVou", id);
                    sqlParameters[1] = new SqlParameter("@Flg", 1);
                    DataTable DtAccountOpening = ObjDBConnection.CallStoreProcedure("GetAccountOpeningDetails", sqlParameters);
                    if (DtAccountOpening != null && DtAccountOpening.Rows.Count > 0)
                    {
                        SetSuccessMessage("Opening Entry Deleted Sucessfully");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("index", "AccountOpening");
        }


        public IActionResult GetReportView(int gridMstId, int pageIndex, int pageSize, string searchValue, string columnName, string sortby)
        {
            GetReportDataModel getReportDataModel = new GetReportDataModel();
            try
            {
                #region User Rights
                long userId = GetIntSession("UserId");
                UserFormRightModel userFormRights = new UserFormRightModel();
                string currentURL = "/AccountOpening/Index";
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
                        getReportDataModel.ControllerName = "AccountOpening";
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
                    string value = ObjDBConnection.GetLatestVoucherNumber("OblMst", DbConnection.ParseInt32(vou), companyId);
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
                if(type==1)
                {
                    var bytes = Excel(getReportDataModel, "Account Opening Report", companyDetails.CmpName);
                    return File(
                          bytes,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                          "AccountOpening.xlsx");
                }
                else
                {
                    var bytes = PDF(getReportDataModel, "Account Opening Report", companyDetails.CmpName);
                    return File(
                          bytes,
                          "application/pdf",
                          "AccountOpening.pdf");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
