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
    public partial class frmCategorylist : Form
    {
        public frmCategorylist()
        {
            InitializeComponent();
            //ListCategory();
        }
        Class.main_function cM = new Class.main_function();
       public  string print = "0";
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            print = "0";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            print = "1";
            this.Close();
        }

        private void frmCategorylist_Load(object sender, EventArgs e)
        {

        }
    }
}
