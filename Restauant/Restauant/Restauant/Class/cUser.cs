using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauant.Class
{
    class cUser
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();


        public bool Insert(string fname,string lname,string sex,string address, string phone, byte[]img,string login_name,string pass, int position, int role )
        {
            cmd = new SqlCommand("Insert_user", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@lname", lname);
            p.AddWithValue("@fname", fname);
            p.AddWithValue("@sex", sex);
            p.AddWithValue("@address", address);
            p.AddWithValue("@phone", phone);
            p.AddWithValue("@image", img);
            p.AddWithValue("@login_name", login_name);
            p.AddWithValue("@pwd", pass);
            p.AddWithValue("@position", position);
            p.AddWithValue("@role", role);
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
        public bool Update(int id,string fname, string lname, string sex, string address, string phone, byte[] img,  int position, int role)
        {
            cmd = new SqlCommand("update_user", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
            p.AddWithValue("@lname", lname);
            p.AddWithValue("@fname", fname);
            p.AddWithValue("@sex", sex);
            p.AddWithValue("@address", address);
            p.AddWithValue("@phone", phone);
            p.AddWithValue("@image", img);
            p.AddWithValue("@position", position);
            p.AddWithValue("@role", role);
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
            cmd = new SqlCommand("remove_employee", conn);
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
