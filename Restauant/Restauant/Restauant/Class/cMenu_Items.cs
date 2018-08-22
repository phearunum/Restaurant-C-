using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.Class
{
    class cMenu_Items
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();
         public bool Insert(string name,string code,int cat_id,string price_big,byte[] img, string info)
        {

            cmd = new SqlCommand("AddItem", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@name", name);
            p.AddWithValue("@code", code);
            p.AddWithValue("@cat_id", cat_id);
            p.AddWithValue("@price_big", price_big);
           
            p.AddWithValue("@img", img);
            p.AddWithValue("@comment", info);
          
                conn.Open();
                cmd.ExecuteNonQuery();
                
          
                cmd.Dispose();
                conn.Close();
         
            return true;

        }

        public bool Update(string id,string name, string code, int cat_id, string price_big, string price_small, byte[] img, string info,int remark)
        {
            cmd = new SqlCommand("UpdateItem", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@name", name);
            p.AddWithValue("@code", code);
            p.AddWithValue("@cat_id", cat_id);
            p.AddWithValue("@price_big", price_big);
            p.AddWithValue("@price_small", price_small);
            p.AddWithValue("@img", img);
            p.AddWithValue("@comment", info);
            p.AddWithValue("@id", id);
            p.AddWithValue("@remark",remark);
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
        public bool RemoveItem(string Id)
        {
            cmd = new SqlCommand("RemoveItem", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", Id);
           
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
