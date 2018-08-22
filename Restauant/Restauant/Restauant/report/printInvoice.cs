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
using System.Drawing.Printing;
using System.Reflection;

namespace Restauant.report
{
    public partial class printInvoice : Form
    {
        public printInvoice()
        {
            InitializeComponent();
        }

        public string invID,Cashier;
        PrinterSettings printerSettings = new PrinterSettings();
        PrintDialog printDialog = new PrintDialog();
        //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoice", Dot));
        Microsoft.Reporting.WinForms.ReportViewer reportViewerSales = new Microsoft.Reporting.WinForms.ReportViewer();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSourceSales = new Microsoft.Reporting.WinForms.ReportDataSource();



        public void getData()
        {
            Class.main_function cM = new Class.main_function();
            DataTable Dot = new DataTable();
            SqlParameter par = new SqlParameter();
            par.Value = invID;
            par.ParameterName = "@invID";
            Dot = cM.getAllData("Print_Inv", par,null,null,null);

            //string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);
            // reportViewer1.LocalReport.ReportPath = @"Restauant.report.sale_invoice.rdlc";
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Restauant.report.sale_invoice.rdlc";
            //LocalReport report = new LocalReport();
            //report.ReportEmbeddedResource = "Restauant.report.sale_invoice.rdlc";                
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoice", Dot));
          

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = @"Restauant.report.sale_invoice.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("invoice", Dot));
            reportViewer1.RefreshReport();
            reportViewer1.RenderingComplete += new RenderingCompleteEventHandler(PrintSales);
       

        }
        private void Print()
        {
          

        }

        public void PrintSales(object sender, RenderingCompleteEventArgs e)
        {
            try
            {
               
                reportViewer1.PrintDialog();
               
                reportViewer1.Clear();
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
                
            }
            catch (Exception ex)
            {
                
            }
        }
        private void printInvoice_Load(object sender, EventArgs e)

        {
           
            getData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData(); 
        }
    }
}
