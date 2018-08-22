using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restauant.Class;
using System.Data.SqlClient;

namespace Restauant
{
    public partial class form_category : Form
    {
        public form_category()
        {
            InitializeComponent();
        }

        main_function cM = new main_function();
        cCategory cCat = new cCategory();
        string dvg;
        public void getList()
        {
            dataGridView1.DataSource = cM.getAllData("Listcategory",null,null,null,null);
        }
        private void form_category_Load(object sender, EventArgs e)
        {
            getList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (category.TextLength > 2 )
            {
                cCat.Insert(category.Text);
                MessageBox.Show("Inserted ");
                getList();
                cM.ClearTextBoxes(this);
                category.Focus();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Remove ?", " POS System Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cCat.Remove(Convert.ToInt32(dvg));

                MessageBox.Show("Item has been removed");
                dvg = "";
                category.Clear();
                getList();

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dvg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dvg != "")
            {
                getData_to_textBox(dvg);
            }
            else
            {
                category.Clear();

                
            }
        }
        protected void getData_to_textBox(string id)
        {
            DataTable Dt = new DataTable();
            SqlParameter par_id = new SqlParameter();
            par_id.ParameterName = "@id";
            par_id.Value = id;

            Dt = cM.getAllData("select_Category_byID", par_id, null, null, null);
            category.Text = Dt.Rows[0][1].ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update ?", " POS System Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cCat.Update(Convert.ToInt32(dvg),category.Text);
               
                MessageBox.Show("Item has been updated");
                dvg = "";
                category.Clear();
                getList();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 