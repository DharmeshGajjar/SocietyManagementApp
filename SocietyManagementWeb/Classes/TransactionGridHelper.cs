using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementWeb.Classes
{
    public static class TransactionGridHelper
    {
        #region Private Methods

        static DbConnection ObjDBConnection = new DbConnection();
        #endregion

        #region Public Methods

        public static List<SelectListItem> GetLayoutList(string url)
        {
            try
            {
                SqlParameter[] sqlParametersNew = new SqlParameter[6];
                sqlParametersNew[0] = new SqlParameter("@GridTransactionId", "0");
                sqlParametersNew[1] = new SqlParameter("@Flg", 3);
                sqlParametersNew[2] = new SqlParameter("@skiprecord", "0");
                sqlParametersNew[3] = new SqlParameter("@pagesize", "0");
                sqlParametersNew[4] = new SqlParameter("@searchvalue", "0");
                sqlParametersNew[5] = new SqlParameter("@URL", url);

                DataTable dt = ObjDBConnection.CallStoreProcedure("GetTransactionGridDetails", sqlParametersNew);
                if (dt != null && dt.Rows.Count > 0)
                {
                    List<SelectListItem> data = new List<SelectListItem>();
                    foreach (DataRow item in dt.Rows)
                    {
                        data.Add(new SelectListItem
                        {
                            Text = Convert.ToString(item["LayoutName"]),
                            Value = Convert.ToString(item["TransactionGridId"])
                        });
                    }
                    return data;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
        #endregion
    }
}
