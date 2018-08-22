using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.Class
{
    class insert_invoice
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connection.conStr);
        main_function cM = new main_function();

        public bool Insert(string date,string cashir,string subTotal,string discount, string payment_recivece, string payment_back, string totalAmount,string total_real, string cash_discount,string table)
        {
            cmd = new SqlCommand("Insert_invoice ", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
          
            p.AddWithValue("@inv_date", date);
            p.AddWithValue("@inv_casheir_id", cashir);
            p.AddWithValue("@subTotal", subTotal);
            p.AddWithValue("@discount", discount);
            p.AddWithValue("@payment_recivece", payment_recivece);
            p.AddWithValue("@payment_back", payment_back);
            p.AddWithValue("@totalAmount ", totalAmount);
            p.AddWithValue("@total_real ", total_real);
            p.AddWithValue("@cash_discount ", cash_discount);
            p.AddWithValue("@table ", table);
            conn.Open();
                cmd.ExecuteNonQuery();
          
                cmd.Dispose();
                conn.Close();
           
            return true;
        }
        public bool Update(int id,string date, string cashir, string subTotal, string discount, string payment_recivece, string payment_back, string totalAmount, string total_real, string cash_discount)
        {
            cmd = new SqlCommand("update_invoice_order ", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var p = cmd.Parameters;
            p.AddWithValue("@id", id);
            p.AddWithValue("@inv_date", date);
            p.AddWithValue("@inv_casheir_id", cashir);
            p.AddWithValue("@subTotal", subTotal);
            p.AddWithValue("@discount", discount);
            p.AddWithValue("@payment_recivece", payment_recivece);
            p.AddWithValue("@payment_back", payment_back);
            p.AddWithValue("@totalAmount ", totalAmount);
            p.AddWithValue("@total_real ", total_real);
            p.AddWithValue("@cash_discount ", cash_discount);

            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

            return true;
        }

    }
}
