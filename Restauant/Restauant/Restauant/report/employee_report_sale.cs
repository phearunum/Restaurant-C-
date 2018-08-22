using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.report
{
    public partial class employee_report_sale : Form
    {
        public employee_report_sale()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();

        protected void getData()
        {
            cM.refresh_address(comboBox1, " Select * from tbl_user");
        }
        protected void LoadReport()
        {
            DateTime date = DateTime.Now; // Or whatever
         
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@datefrom";
            par.Value = txtdatefrom.Text;
            SqlParameter par2 = new SqlParameter();
            par2.ParameterName = "@dateto";
            par2.Value = txtdateto.Text;
            SqlParameter par3 = new SqlParameter();
            par3.ParameterName = "@userID";
            par3.Value = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("sale_by_employee", par, par2,par3, null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"E:\Client Server\Restauant\Restauant\report\sale_invoice.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.employee_report_sale.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("employee_report_sale", Dot));
            reportViewer1.RefreshReport();
        }
        private void employee_report_sale_Load(object sender, EventArgs e)
        {

            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport();

        }
    }
}
