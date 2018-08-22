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
    public partial class report_by_item : Form
    {
        public report_by_item()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
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
            par3.ParameterName = "@proID";
            par3.Value = textBox1.Text;
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("rep_sale_by_items", par, par2, par3, null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"E:\Client Server\Restauant\Restauant\report\sale_invoice.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.report_by_item.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("report_by_item", Dot));
            reportViewer1.RefreshReport();
        }
        private void report_by_item_Load(object sender, EventArgs e)
        {

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
