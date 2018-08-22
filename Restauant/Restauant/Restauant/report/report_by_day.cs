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
    public partial class report_by_day : Form
    {
        public report_by_day()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        public void getData()
        {

            SqlParameter par = new SqlParameter();
            par.ParameterName = "@date_from";
            par.Value = date_from.Text;
            SqlParameter par1 = new SqlParameter();
            par1.ParameterName = "@date_to";
            par1.Value = date_to.Text;
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("report_by_day", par, par1, null, null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"E:\Client Server\Restauant\Restauant\report\sale_invoice.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.report_by_day.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("report_by_day", Dot));
            reportViewer1.RefreshReport();

        }

        private void report_by_day_Load(object sender, EventArgs e)
        {
            getData();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();

        }
    }
}
