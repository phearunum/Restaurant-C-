using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.report
{
    public partial class Advance_Report : Form
    {
        public Advance_Report()
        {
            InitializeComponent();
        }
        TreeNode report_today = new TreeNode("Report Today Detail");
        TreeNode report_today_inv = new TreeNode("Report Today By Invoice");
        TreeNode report_by_em = new TreeNode("Report By Employee ");
        TreeNode report_by_day = new TreeNode("Report By Day ");
        TreeNode report_moth = new TreeNode("Monthly Report");
        TreeNode report_year = new TreeNode("Yearly Report");
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == report_today)
            {
                report.sale_detail_today today = new sale_detail_today();
                today.ShowDialog();
            }
            if (treeView1.SelectedNode == report_today_inv)
            {
                AllReport all = new AllReport();
                all.ShowDialog();
            }
            if (treeView1.SelectedNode == report_by_em)
            {
                report.employee_report_sale emp = new employee_report_sale();
                emp.ShowDialog();
            }
            if (treeView1.SelectedNode == report_by_day)
            {
                report.report_by_day day = new report.report_by_day();
                day.ShowDialog();
            }
            if (treeView1.SelectedNode == report_moth)
            {
                
            }

        }

        private void Advance_Report_Load(object sender, EventArgs e)
        {
          
            treeView1.Nodes.Add(report_today);
            treeView1.Nodes.Add(report_today_inv);
            treeView1.Nodes.Add(report_by_em);
            treeView1.Nodes.Add(report_by_day);
         //  // treeView1.Nodes.Add(report_moth);
          //  treeView1.Nodes.Add(report_year);

            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
        }
    }
}
