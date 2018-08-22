using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cBooking
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool booking(int cashier,string date,int tb_id,int tableID)
        {
            cmd = new SqlCommand("BookTable", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@casheir", cashier);
            p.AddWithValue("@date", date);
            p.AddWithValue("@table_ID", tb_id);
                p.AddWithValue("@tableID", tableID);
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
