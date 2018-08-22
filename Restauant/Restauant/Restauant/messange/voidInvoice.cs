using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant.messange
{
    public partial class voidInvoice : Form
    {
        public voidInvoice()
        {
            InitializeComponent();
        }

        public  string vale = "";
        private void button1_Click(object sender, EventArgs e)
        {
            this.vale = "1";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vale = "0";
            this.Close();
        }

        private void voidInvoice_Load(object sender, EventArgs e)
        {

        }
    }
}
