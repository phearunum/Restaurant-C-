using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restauant.Class;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Restauant.Class
{
    class main_function
    {
        SqlConnection cnn = new SqlConnection(connection.conStr);
      

        public DataTable getAllData(string sql,
        SqlParameter par, SqlParameter par1,
        SqlParameter par2, SqlParameter par3)
        {

                SqlDataAdapter DA = new SqlDataAdapter(sql, cnn);
                DA.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (par != null) { DA.SelectCommand.Parameters.Add(par); }
                if (par1 != null) { DA.SelectCommand.Parameters.Add(par1); }
                if (par2 != null) { DA.SelectCommand.Parameters.Add(par2); }
                if (par3 != null) { DA.SelectCommand.Parameters.Add(par3); }
                DataTable oDT = new DataTable();
                DA.Fill(oDT);
                DA.Dispose();

                return oDT;
           

           
        }
        public void refresh_address(ComboBox cbo, String Sqltext)
        {
            DataTable tb = new DataTable();

            SqlDataAdapter ads = new SqlDataAdapter(Sqltext, cnn);
            ads.Fill(tb);
            cbo.DataSource = tb;
            cbo.DisplayMember = tb.Columns[1].ColumnName;
            cbo.ValueMember = tb.Columns[0].ColumnName;

        }

        public void checkData(string textData, string mess)
        {
            if (textData == "")
            {
                MessageBox.Show(mess);
            }
        }
        public void ClearTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    if (!(c.Parent is NumericUpDown))
                    {
                        ((TextBox)c).Clear();
                    }
                }
                else if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0;
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }
        public DataTable getData(string procedureName, SqlParameter[] procedureParams)
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedureName;
            command.Connection = cnn;
            if (procedureParams != null)
            {
                for (int i = 0; i < procedureParams.Length; i++)
                {
                    command.Parameters.Add(procedureParams[i]);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        public void setData(string procedureName, SqlParameter[] procedureParams)
        {
            cnn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedureName;
            command.Connection = cnn;
            if (procedureParams != null)
            {
                command.Parameters.AddRange(procedureParams);
            }

            command.ExecuteNonQuery();
            cnn.Close();

        }

    
}
}
