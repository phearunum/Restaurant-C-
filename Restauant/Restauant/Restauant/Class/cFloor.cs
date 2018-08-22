using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cFloor
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();
        public bool Insert(string floorName, string desc)
        {
            cmd = new SqlCommand("Insert_floor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@name", floorName);
            p.AddWithValue("@desc", desc);
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
        public bool Update(int id , string floorName, string desc)
        {
            cmd = new SqlCommand("Update_floor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
            p.AddWithValue("@name", floorName);
            p.AddWithValue("@desc", desc);
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
            cmd = new SqlCommand("Remove_floor", conn);
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
