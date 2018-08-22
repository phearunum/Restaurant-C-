using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cExchage
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool Insert(string rate, string date)
        {
            cmd = new SqlCommand("insert_exchage ", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@rate", rate);
            p.AddWithValue("@date", date);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return true;
        }
    }
}
