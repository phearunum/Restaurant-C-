using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauant.Class;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restauant.Class
{
    class cOrder_detial
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool Insert(int cusID,int ProID,int Qty,string Price, string discount ,string Amount)
        {
            cmd = new SqlCommand("Insert_Order", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@cusID", cusID);
            p.AddWithValue("@proID", ProID);
            p.AddWithValue("@Qty", Qty);
            p.AddWithValue("@price", Price);
            p.AddWithValue("@discount", discount);
            p.AddWithValue("@amount", Amount);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();              
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

        public bool Adjust(int cusID, int ProID)
        {
            cmd = new SqlCommand("Adjust_order", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@cusID", cusID);
            p.AddWithValue("@proID", ProID);
          

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        public bool Remove(int cusID, int ProID)
        {
            cmd = new SqlCommand("Remove_Order", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@cusID", cusID);
            p.AddWithValue("@proID", ProID);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        public bool Void_Invoice(int cusID)
        {
            cmd = new SqlCommand("void_invoice", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@cusID", cusID);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
        public bool add_discount(int cusID,int proID,int discount)
        {
            cmd = new SqlCommand("Add_discount_by_item", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@cusID", cusID);
            p.AddWithValue("@proID", proID);
            p.AddWithValue("@discount", discount);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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
