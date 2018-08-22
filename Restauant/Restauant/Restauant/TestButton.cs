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
    public partial class TestButton : Form
    {
        public TestButton()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();

        protected void data()
        {
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("Listcategory", null, null, null, null);
            for (int x = 0; x < Dot.Rows.Count; x++)
            {


                Label lab = new Label();
                lab.Text = Dot.Rows[x][1].ToString();
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel1.Controls.Add(lab);



            }

        }
        private void TestButton_Load(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Clear();


            data();
            int top = 50;
            int left = 100;
            Button button = new Button();
            for (int i = 0; i < 20; i++)
            {
                button = new Button();
                button.Left = left;
                button.Top = top;
                button.Size = new Size(100, 60);
                flowLayoutPanel1.Controls.Add(button);
            }
           

        }
        void b_Click(object sender, EventArgs e)
        {
            var b = sender as Button;
            if (b != null)
                MessageBox.Show(string.Format("{0} Clicked", b.Text));
        }
    }
}
