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
    public partial class fPayment : Form
    {
        public fPayment()
        {
            InitializeComponent();
        }

        public string txtGetReal="";
        public string txtGetUsd="";
        private void button1_Click(object sender, EventArgs e)
        {
            calulator cl = new calulator();
            cl.ShowDialog();
            txtGetReal = "";
            txtGetUsd = cl.pay;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calulator cl = new calulator();
           
            cl.ShowDialog();
            txtGetUsd = "";
            txtGetReal = cl.pay;

            this.Close();
        }

        private void fPayment_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
