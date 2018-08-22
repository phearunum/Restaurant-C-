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
    public partial class Day_end_sale : Form
    {
        public Day_end_sale()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        public string empID;
        protected void getData()
        {
            DateTime date = DateTime.Now; // Or whatever
            string s = date.ToString("yyyy-MM-dd");
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@date";
            par.Value = s;

            dataGridView1.DataSource = cM.getAllData("TodayReport", par, null, null, null);
            double subtt = 0, dis = 0, amt = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                subtt += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                dis += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                amt += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
            }
            txtsub_tt.Text = subtt.ToString();
            txt_disc.Text = dis.ToString();
            txt_tt.Text = amt.ToString();

        }
        private void Day_end_sale_Load(object sender, EventArgs e)
        {

            getData();
           
            if (dataGridView1.Rows.Count > 0)
            {
                getData();
            }
            else
            {
                MessageBox.Show(" Sale to is empty ");
               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to start Day-End_Close ?", " Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
               
                Class.cDay_end_close close = new Class.cDay_end_close();
                DateTime date = DateTime.Now; // Or whatever
                string s = date.ToString("yyyy-MM-dd");
                close.Insert(s,empID, txtsub_tt.Text,txt_disc.Text,txt_tt.Text);
                MessageBox.Show(" You has been close sell to day !!!");
                getData();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
