        using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class login
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();
        public string GetLogin(string uid, string pass)
        {         
            DataTable oDT = new DataTable();
            SqlParameter par = new SqlParameter();
            SqlParameter par1 = new SqlParameter();
            par.ParameterName = "@iqName";
            par1.ParameterName = "@pwd";
            par.Value = uid;
            par1.Value = pass;
            oDT = cM.getAllData("userLogin", par, par1, null, null);
            string RV = "";
            try
            {
                RV = oDT.Rows[0]["remark"].ToString();

            }
            catch { RV = ""; }
            return RV;
        }
    }
}
