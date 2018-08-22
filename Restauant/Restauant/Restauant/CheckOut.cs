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
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
        }
        Class.cTable table = new Class.cTable();
        public string id;
        public string order_item;
        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Do you want to checkout ", "POS Request ", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    Class.cTable table = new Class.cTable();
            //    //table.Checkout(Convert.ToInt32(id));
            //}
            order_item = "0";
            this.Close();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            order_item = "1";
            this.Close();
        }
    }
}
