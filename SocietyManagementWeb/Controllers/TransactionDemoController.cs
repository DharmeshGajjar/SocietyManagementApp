using Microsoft.AspNetCore.Mvc;
using SocietyManagementWeb.Classes;
using SocietyManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementWeb.Controllers
{
    public class TransactionDemoController : BaseController
    {
        #region Private Methods

        AccountMasterHelpers ObjAccountMasterHelpers = new AccountMasterHelpers();
        #endregion

        #region Constructor

        #endregion

        #region Public Methods

        [HttpGet]
        public IActionResult Index(int? Id)
        {
            long companyid = GetIntSession("CompanyId");
            ViewBag.DepartmentList = ObjAccountMasterHelpers.GetUserRoleDropdown(Convert.ToInt32(companyid));
            string currentURL = GetCurrentURL();
            ViewBag.LayoutList = TransactionGridHelper.GetLayoutList(currentURL);
            EmployeeClass employeeClass = new EmployeeClass();
            if (Id.HasValue)
            {
                employeeClass.Data = TempData["TransactionGridDemo"] as string;
                TempData.Keep("TransactionGridDemo");
            }
            return View(employeeClass);
        }

        [HttpPost]
        public IActionResult Index(EmployeeClass model)
        {
            try
            {
                TempData["TransactionGridDemo"] = model.Data;
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
