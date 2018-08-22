using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        public string name;
        public string id;

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomer neworder = new NewCustomer();
            //neworder.TopLevel = false;
            //this.Container_app.Controls.Add(neworder);
            neworder.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            NewOrder order = new NewOrder();
            order.txtcashier.Text = this.txtName.Text.ToString() ;
            order.ID_USER = this.txtID.Text.ToString();
            order.Text = "POS System Login By :"+ txtName.Text;
            order.ShowDialog();
               
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
                AllReport allReport = new AllReport();
            allReport.ShowDialog();
          
                
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tableSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            form_Table table = new form_Table();

            table.ShowDialog();
           
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                form_floor floor = new form_floor();

            floor.ShowDialog();
           
        }

        private void menuSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["form_menu"] == null)
            {
                form_menu floor = new form_menu();

                floor.ShowDialog();
            }
        }

        private void categorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
                form_category floor = new form_category();
                 floor.ShowDialog();
           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pointOfSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder order = new NewOrder();
            order.Text= "POS System Login By :" + txtName.Text;
            order.ShowDialog();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            this.Text = "POS System Login By :" + txtName.Text;
          
            
                //LoginForm log = new LoginForm();
                //log.ShowDialog();
                //txtName.Text = log.txtname.Text;
                //txtID.Text = log.id;
            

          
            

        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          
        
                employee emp = new employee();
               
                emp.Show();
          
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["position"] == null)
            {
                position emp = new position();

                emp.ShowDialog();
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Inventory"] == null)
            {
                Inventory emp = new Inventory();
                emp.TopLevel = false;
                this.Container_app.Controls.Add(emp);
                emp.Show();
            }
        }

        private void supplyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Suppliyer"] == null)
            {
                Suppliyer emp = new Suppliyer();
                emp.TopLevel = false;
                this.Container_app.Controls.Add(emp);
                emp.Show();
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Product_Category"] == null)
            {
                Product_Category emp = new Product_Category();
                emp.TopLevel = false;
                this.Container_app.Controls.Add(emp);
                emp.Show();
            }
        }

        private void todayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["sale_detail_today"] == null)
            {
                report.sale_detail_today allReport = new report.sale_detail_today();
                
                allReport.ShowDialog();
            }
        }

        private void reportByEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["employee_report_sale"] == null)
            {
                report.employee_report_sale allReport = new report.employee_report_sale();

                allReport.ShowDialog();
            }
        }

        private void advanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["report_by_item"] == null)
            {
                report.report_by_item allReport = new report.report_by_item();

                allReport.ShowDialog();
            }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Advance_Report"] == null)
            {
                report.Advance_Report allReport = new report.Advance_Report();
                
                allReport.ShowDialog();
            }
        }
        protected void clickOpen(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to start Day-End_Close ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Day_end_sale end_sale = new Day_end_sale();
                end_sale.empID = txtID.Text.ToString();

               
                    Day_end_sale allReport = new Day_end_sale();
                    allReport.empID = txtID.Text.ToString();

                allReport.ShowDialog();
               
            }

        }

        private void closeAllFromToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (frm != Parent)
                {
                    frm.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm log = new LoginForm();
            log.txtname.Text = "";
            log.txtpwd.Text = "";
            log.Show();
            
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TestButton bt = new TestButton();
            bt.ShowDialog();
        }

        private void reportByDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report.report_by_day days = new report.report_by_day();
            days.ShowDialog();
        }
    }
}
