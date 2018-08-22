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
    public partial class discount : Form
    {
        public discount()
        {
            InitializeComponent();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        protected void loadDiscount()
        {
            Class.main_function cM = new Class.main_function();
            dataGridView1.DataSource = cM.getAllData("select_discount", null,null,null,null);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            discount_insert dis_in = new discount_insert();
            dis_in.ShowDialog();
            loadDiscount();
        }

        private void discount_Load(object sender, EventArgs e)
        {
            loadDiscount();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
