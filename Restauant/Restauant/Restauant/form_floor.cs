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
    public partial class form_floor : Form
    {
        public form_floor()
        {
            InitializeComponent();
        }
        main_function cM = new main_function();
        Class.cFloor floor = new Class.cFloor();
        string dvg;
        public void getData()
        {
            dataGridView1.DataSource = cM.getAllData("getFloor", null,null,null,null);
        }
        private void form_floor_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfloor.Text != "")
                {
                    floor.Insert(txtfloor.Text, txtdesc.Text);
                    MessageBox.Show(" Floor has been saved ");
                    cM.ClearTextBoxes(this);
                    txtdesc.Clear();
                    getData();

                }
            }
            catch(Exception)
            {
             
            }
           
        }

        protected void gettext_totextBox(string id)
        {
          
                try
                {
                    DataTable Dt = new DataTable();
                    SqlParameter par_id = new SqlParameter();
                    par_id.ParameterName = "@id";
                    par_id.Value = id;

                    Dt = cM.getAllData("select_floor_byId", par_id, null, null, null);
                    dvg = Dt.Rows[0][0].ToString();
                    txtfloor.Text = Dt.Rows[0][1].ToString();
                    txtdesc.Text = Dt.Rows[0][2].ToString();

                }
                catch
                {

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
                txtdesc.Clear();
                txtfloor.Clear();
            }
        
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    floor.Update(Convert.ToInt32(dvg),txtfloor.Text,txtdesc.Text);
                    MessageBox.Show(" Floor has been updated ");
                    dvg = "";
                    getData();
                    cM.ClearTextBoxes(this);
                    txtdesc.Clear();
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
                    floor.Remove(Convert.ToInt32(dvg));
                    MessageBox.Show(" Floor has been remove ");
                    dvg = "";
                    getData();
                    cM.ClearTextBoxes(this);
                    txtdesc.Clear();
                }
                catch
                {

                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
