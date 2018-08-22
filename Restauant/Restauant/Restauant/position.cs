using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restauant
{
    public partial class position : Form
    {
        public position()
        {
            InitializeComponent();
        }

        Class.main_function cM = new Class.main_function();
        Class.cPosition pos = new Class.cPosition();
        string dvg;
        protected void getData()
        {
            dataGridView1.DataSource = cM.getAllData("select_position", null,null,null,null);
            cM.ClearTextBoxes(this);
            dvg = "";
        }
        private void position_Load(object sender, EventArgs e)
        {
            getData();
            cM.ClearTextBoxes(this); 
        }
        protected void gettext_totextBox(string id)
        {

            try
            {
                DataTable Dt = new DataTable();
                SqlParameter par_id = new SqlParameter();
                par_id.ParameterName = "@id";
                par_id.Value = id;

                Dt = cM.getAllData("select_position_byID", par_id, null, null, null);
                dvg = Dt.Rows[0][0].ToString();
                txtposition.Text = Dt.Rows[0][1].ToString();
               

            }
            catch
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtposition.Text!="")
            {
                pos.Insert(txtposition.Text);
                MessageBox.Show(" New position has been saved ");
                getData();

            }else
            {
                txtposition.Focus();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dvg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dvg != "")
            {
                try
                {
                    gettext_totextBox(dvg);
                }
                catch
                {

                }
            }
            else
            {
                
                txtposition.Clear();
                dvg = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    pos.update(Convert.ToInt32(dvg),txtposition.Text);
                    MessageBox.Show(" Position has been updated ");
                    dvg = "";
                    getData();
                    cM.ClearTextBoxes(this);
                   
                }
                catch
                {

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    pos.remove(Convert.ToInt32(dvg));
                    MessageBox.Show(" Position has been remove ");
                    dvg = "";
                    getData();
                    cM.ClearTextBoxes(this);
                    
                }
                catch
                {

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
