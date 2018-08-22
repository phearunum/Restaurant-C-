using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cCategory
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool Insert(string catName)
        {
            cmd = new SqlCommand("saveCategory", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@name",catName);
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
        public bool Update(int id,string name )
        {
            cmd = new SqlCommand("Update_Category", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
            p.AddWithValue("@name", name);
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

        public bool Remove(int id)
        {
            cmd = new SqlCommand("Remove_Category", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
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
