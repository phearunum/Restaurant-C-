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
    public partial class product_report_sale : Form
    {
        public product_report_sale()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        public void getData()
        {
            DateTime date = DateTime.Now; // Or whatever
            string s = date.ToString("yyyy-MM-dd");
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@date";
            par.Value = s;
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("TodayReport_Sale", par, null, null, null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"E:\Client Server\Restauant\Restauant\report\sale_invoice.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.report_sale_today.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("today_report", Dot));
            reportViewer1.RefreshReport();

        }
        private void product_report_sale_Load(object sender, EventArgs e)
        {
            getData();

        }
    }
}
