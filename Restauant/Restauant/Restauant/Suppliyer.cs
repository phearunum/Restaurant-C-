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
    public partial class Suppliyer : Form
    {
        public Suppliyer()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        protected void load_suppliyer()
        {
            dataGridView1.DataSource = cM.getAllData("select_suppliyer",null,null,null,null);
        }
        private void Suppliyer_Load(object sender, EventArgs e)
        {
            load_suppliyer();

        }
    }
}
