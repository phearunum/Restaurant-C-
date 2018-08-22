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
    public partial class sale_detail_today : Form
    {
        public sale_detail_today()
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
            Dot = cM.getAllData("sale_detail_today", par, null, null, null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"E:\Client Server\Restauant\Restauant\report\sale_invoice.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.sale_detail_today.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("sale_detail_today", Dot));
            reportViewer1.RefreshReport();

        }
        private void sale_detail_today_Load(object sender, EventArgs e)
        {

            getData();
        }
    }
}
