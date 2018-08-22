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

namespace Restauant
{
    public partial class AllReport : Form
    {
        public AllReport()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();

        protected void getData()
        {
            DateTime date = DateTime.Now; // Or whatever
            string s = date.ToString("yyyy-MM-dd");
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@date";
            par.Value = s;

            dataGridView1.DataSource = cM.getAllData("TodayReport",par, null, null, null);

        }
        private void AllReport_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            report.product_report_sale rep_sale = new report.product_report_sale();
            rep_sale.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
