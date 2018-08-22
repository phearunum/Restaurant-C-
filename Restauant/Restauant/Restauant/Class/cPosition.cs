using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cPosition
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();
        public bool Insert(string pos_name)
        {
            cmd = new SqlCommand("insert_position", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@position", pos_name);
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
        public bool update(int id,string pos_name)
        {
            cmd = new SqlCommand("update_position", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
            p.AddWithValue("@position", pos_name);
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
        public bool remove(int id)
        {
            cmd = new SqlCommand("remove_position", conn);
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
