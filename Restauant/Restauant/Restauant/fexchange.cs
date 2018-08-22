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
    public partial class fexchange : Form
    {
        public fexchange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now; // Or whatever
            string s = date.ToString("yyyy-MM-dd");
            Class.cExchage ex = new Class.cExchage();
            ex.Insert(textBox1.Text,s);
            textBox1.Enabled = false;
        }
    }
}
