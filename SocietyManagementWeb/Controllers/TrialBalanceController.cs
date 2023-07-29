using Microsoft.AspNetCore.Mvc;
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
    public class TrialBalanceController : BaseController
    {
        DbConnection ObjDBConnection = new DbConnection();
        TaxMasterHelpers ObjTaxMasterHelpers = new TaxMasterHelpers();
        AccountGroupHelpers ObjAccountGroupHelpers = new AccountGroupHelpers();

        public IActionResult Index()
        {
            TrialBalanceModel trialbalanceModel = new TrialBalanceModel();
            try
            {
                bool isreturn = false;
                long companyId = GetIntSession("CompanyId");
                long userId = GetIntSession("UserId");
                long yearId = GetIntSession("YearId");
                var yearData = DbConnection.GetYearListByCompanyId(Convert.ToInt32(companyId)).Where(x => x.YearVou == yearId).FirstOrDefault();
                if (yearData != null)
                {
                    trialbalanceModel.GenFrDate = yearData.StartDate;
                    trialbalanceModel.GenToDate = yearData.EndDate;
                }
                INIT(ref isreturn);
                if (isreturn)
                {
                    return RedirectToAction("index", "dashboard");
                }
                trialbalanceModel.GroupList = ObjAccountGroupHelpers.GetOpositeGroupDropdown(Convert.ToInt32(companyId));
                trialbalanceModel.DeptList = ObjTaxMasterHelpers.GetDepartmentDropdown(Convert.ToInt32(companyId));
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(trialbalanceModel);
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
                ViewBag.layoutList = GetGridLayoutDropDown(DbConnection.GridTypeReport, userFormRights.ModuleId);
                ViewBag.pageNoList = GetPageNo();
            }

            #endregion

        }

        public IActionResult GetReportView(int gridMstId, int pageIndex, int pageSize, string searchValue, string columnName, string sortby, string fromDate, string toDate, string groupId, string departmentId)
        {
            GetReportDataModel getReportDataModel = new GetReportDataModel();
            try
            {
                #region User Rights
                int userId = Convert.ToInt32(GetIntSession("UserId"));
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));

                UserFormRightModel userFormRights = new UserFormRightModel();
                string currentURL = "/TrialBalance/Index";
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
                if (gridMstId == 61)
                {
                    string whereConditionQuery = string.Empty;
                    if (!string.IsNullOrWhiteSpace(fromDate))
                    {
                        whereConditionQuery += " AND LEDGER.LedDate>='" + fromDate + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(fromDate))
                    {
                        whereConditionQuery += " AND LEDGER.LedDate<='" + toDate + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(groupId))
                    {
                        whereConditionQuery += " AND AccountGroupMst.AgrVou='" + groupId + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(departmentId))
                    {
                        whereConditionQuery += " AND Ledger.LedDepVou='" + departmentId + "'";
                    }
                    getReportDataModel = GetReportData(gridMstId, pageIndex, pageSize, columnName, sortby, searchValue, companyId, userId, 0, "", 0, 0, whereConditionQuery);

                    //getReportDataModel = GetReportData(gridMstId, pageIndex, pageSize, columnName, sortby, searchValue, companyId, 0, 0, "", 0, 0, whereConditionQuery);
                    if (getReportDataModel.IsError)
                    {
                        ViewBag.Query = getReportDataModel.Query;
                        return PartialView("_reportView");
                    }
                    getReportDataModel.pageIndex = pageIndex;
                    getReportDataModel.ControllerName = "TrialBalance";
                }
                else
                {
                    SqlParameter[] sqlParameters = new SqlParameter[6];
                    sqlParameters[0] = new SqlParameter("@FromDate", fromDate);
                    sqlParameters[1] = new SqlParameter("@ToDate", toDate);
                    sqlParameters[2] = new SqlParameter("@AgrVou", groupId);
                    sqlParameters[3] = new SqlParameter("@DeptVou", departmentId);
                    sqlParameters[4] = new SqlParameter("@UserID", userId);
                    sqlParameters[5] = new SqlParameter("@CmpVou", companyId);
                    DataTable DtGenLed = ObjDBConnection.CallStoreProcedure("Get_TRIALBAL_REPORT", sqlParameters);
                    if (DtGenLed != null && DtGenLed.Rows.Count > 0)
                    {
                        int Status = DbConnection.ParseInt32(DtGenLed.Rows[0][0].ToString());
                        if (Status == 1)
                        {
                            getReportDataModel = GetReportData(gridMstId, pageIndex, pageSize, columnName, sortby, searchValue, companyId, userId, 0, "", 0, 0, "");
                            if (getReportDataModel.IsError)
                            {
                                ViewBag.Query = getReportDataModel.Query;
                                return PartialView("_reportView");
                            }
                            getReportDataModel.pageIndex = pageIndex;
                            getReportDataModel.ControllerName = "TrialBalance";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return PartialView("_reportView", getReportDataModel);
        }

        public IActionResult ExportToExcelPDF(int gridMstId, string searchValue, int type, string toDate, string groupId, string fromDate, string departmentId)
        {
            GetReportDataModel getReportDataModel = new GetReportDataModel();
            try
            {
                int userId = Convert.ToInt32(GetIntSession("UserId"));
                int companyId = Convert.ToInt32(GetIntSession("CompanyId"));
                int YearId = Convert.ToInt32(GetIntSession("YearId"));
                var companyDetails = DbConnection.GetCompanyDetailsById(companyId);

                if (gridMstId == 61)
                {
                    string whereConditionQuery = string.Empty;
                    if (!string.IsNullOrWhiteSpace(fromDate))
                    {
                        whereConditionQuery += " AND LEDGER.LedDate>='" + fromDate + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(fromDate))
                    {
                        whereConditionQuery += " AND LEDGER.LedDate<='" + toDate + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(groupId))
                    {
                        whereConditionQuery += " AND AccountGroupMst.AgrVou='" + groupId + "'";
                    }
                    if (!string.IsNullOrWhiteSpace(departmentId))
                    {
                        whereConditionQuery += " AND Ledger.LedDepVou='" + departmentId + "'";
                    }

                    getReportDataModel = GetReportData(gridMstId, 0, 0, "", "", searchValue, companyId, userId, 0, "", 0, 1, whereConditionQuery);
                }
                else
                {
                    SqlParameter[] sqlParameters = new SqlParameter[6];
                    sqlParameters[0] = new SqlParameter("@FromDate", fromDate);
                    sqlParameters[1] = new SqlParameter("@ToDate", toDate);
                    sqlParameters[2] = new SqlParameter("@AgrVou", groupId);
                    sqlParameters[3] = new SqlParameter("@DeptVou", departmentId);
                    sqlParameters[4] = new SqlParameter("@UserID", userId);
                    sqlParameters[5] = new SqlParameter("@CmpVou", companyId);
                    DataTable DtGenLed = ObjDBConnection.CallStoreProcedure("Get_TRIALBAL_REPORT", sqlParameters);
                    if (DtGenLed != null && DtGenLed.Rows.Count > 0)
                    {
                        int Status = DbConnection.ParseInt32(DtGenLed.Rows[0][0].ToString());
                        if (Status == 1)
                        {
                            getReportDataModel = GetReportData(gridMstId, 0, 0, "", "", searchValue, companyId, userId, 0, "", 0, 1, "");
                        }
                    }

                }

                if (type == 1)
                {
                    if (!string.IsNullOrWhiteSpace(departmentId))
                    {
                        var departmentDetails = DbConnection.GetDepartmentDetailsById(Convert.ToInt32(departmentId), companyId);
                        var bytes = Excel(getReportDataModel, "Trial Balance Report", departmentDetails.DepName, departmentId);
                        return File(
                          bytes,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                          "TrialBalance.xlsx");
                    }
                    else
                    {
                        var bytes = Excel(getReportDataModel, "Trial Balance Report", companyDetails.CmpName);
                        return File(
                          bytes,
                          "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                          "TrialBalance.xlsx");
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(departmentId))
                    {
                        var departmentDetails = DbConnection.GetDepartmentDetailsById(Convert.ToInt32(departmentId), companyId);
                        var bytes = PDF(getReportDataModel, "Trial Balance Report", departmentDetails.DepName, departmentId);
                        return File(
                              bytes,
                              "application/pdf",
                              "TrialBalance.pdf");
                    }
                    else
                    {
                        var bytes = PDF(getReportDataModel, "Trial Balance Report", companyDetails.CmpName, "");
                        return File(
                              bytes,
                              "application/pdf",
                              "TrialBalance.pdf");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
