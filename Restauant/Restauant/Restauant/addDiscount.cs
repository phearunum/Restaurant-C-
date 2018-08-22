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
    public partial class addDiscount : Form
    {
        public addDiscount()
        {
            InitializeComponent();
        }
        public string rate_dis;
        protected void loadDiscount()
        {
            Class.main_function cM = new Class.main_function();
            dataGridView1.DataSource = cM.getAllData("select_discount", null, null, null, null);
        }
        private void addDiscount_Load(object sender, EventArgs e)
        {
            loadDiscount();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rate_dis ="0";
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string check =check = dataGridView1.CurrentRow.Cells[1].Value.ToString();
           
            if (check!="")
            {
                rate_dis = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            else
            {
                rate_dis = "0";
                this.Close();
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
