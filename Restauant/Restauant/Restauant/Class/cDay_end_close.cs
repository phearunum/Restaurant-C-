using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Restauant.Class
{
    class cDay_end_close
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();
        public bool Insert(string date, string rep_by, string sub_amt, string discount_amt,string total_amt)
        {

            cmd = new SqlCommand("Insert_day_end_close", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@date", date);
            p.AddWithValue("@rep_by", rep_by);
            p.AddWithValue("@sub_amt", sub_amt);
            p.AddWithValue("@discount_amt", discount_amt);
            p.AddWithValue("@total_amt", total_amt );
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Data has been saved ");
            }
            catch
            {
                MessageBox.Show(" Data has been error ");
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
