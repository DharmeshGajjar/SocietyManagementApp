using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementWeb.Models
{
    public class AccountOpeningModel
    {
        public int OblVou { get; set; }
        public int OblVNo { get; set; }
        public string OblDt { get; set; }
        public int OblDtN { get; set; }
        public decimal OblAmount { get; set; }
        public long OblDepVou { get; set; }
        public string DepName { get; set; }
        public List<SelectListItem> DepList { get; set; }
        public OpeningBalGridModel OpeningBal { get; set; }
        public List<OpeningBalGridModel> OblList { get; set; }
    }

    public class OpeningBalGridModel
    {
        public long OblAVou { get; set; }
        public long OblAOblVou { get; set; }
        public int OblASrNo { get; set; }
        public int OblAAccVou { get; set; }
        public List<CustomDropDown> OblAccountList { get; set; }
        public string OblAAccVouStr { get; set; }
        public string AccName { get; set; }
        public decimal OblAAmt { get; set; }
        public string OblAAmtStr { get; set; }
        public int OblACrDr { get; set; }
        public List<SelectListItem> CrDrList { get; set; }
        public string OblACrDrStr { get; set; }
        public string CrDr { get; set; }
        public string OblARemks { get; set; }
        public string OblARemksStr { get; set; }
    }
}
