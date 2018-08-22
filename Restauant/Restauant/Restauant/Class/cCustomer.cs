using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.Class
{
    class cCustomer
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool Insert(string Cname, string sex, string address, string email, string phone,string status)
        {
            cmd = new SqlCommand("InsertCustomer", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@name", Cname);
            p.AddWithValue("@sex", sex);
            p.AddWithValue("@address", address);
            p.AddWithValue("@email", email);
            p.AddWithValue("@phone", phone);
            p.AddWithValue("@status", status);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted ");
            }
            catch
            {
                MessageBox.Show("Error  ");
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
