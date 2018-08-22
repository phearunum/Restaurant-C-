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
    public partial class frm_custom_order : Form
    {
        public frm_custom_order()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class.cOrder_detial order = new Class.cOrder_detial();
            order.Insert(1,1,2,"100","200","0");
            MessageBox.Show("Inserted ");
        }

        private void frm_custom_order_Load(object sender, EventArgs e)
        {

        }
    }
}
