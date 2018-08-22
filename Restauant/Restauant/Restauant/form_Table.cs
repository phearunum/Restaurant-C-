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
    public partial class form_Table : Form
    {
        public form_Table()
        {
            InitializeComponent();
        }
        main_function cM = new main_function();
        Class.cTable tb = new cTable();
        string dgv="";
        public void getTable()
        {
            dataGridView1.DataSource = cM.getAllData("ListTable", null,null,null,null);
            cM.refresh_address(floor, "SELECT * FROM tbl_floor");
            cM.refresh_address(txtType, "SELECT * FROM tbl_table_type");
            desc.Clear();
        }
        private void form_Table_Load(object sender, EventArgs e)
        {
            getTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv!="")
            {
               
            }
            else
            {
                if (txtname.Text != "")
                {
                    tb.Insert(txtname.Text, Convert.ToInt32(txtType.SelectedValue.ToString()), Convert.ToInt32(floor.SelectedValue.ToString()), desc.Text);
                    MessageBox.Show(" Table has been saved ");
                    getTable();
                    cM.ClearTextBoxes(this);
                }
                else
                {
                    txtname.Focus();
                }
            }
           
        }

        protected void getdata_textbox(string id)
        {
            DataTable Dot = new DataTable();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@id";
            par.Value = id;
            Dot = cM.getAllData("select_table_byID",par,null,null,null);
            txtname.Text = Dot.Rows[0][1].ToString();
            txtType.Text = Dot.Rows[0][3].ToString();
            floor.Text = Dot.Rows[0][2].ToString();
            desc.Text = Dot.Rows[0][4].ToString();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dgv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dgv!="")
            {
                getdata_textbox(dgv);
            }
            else
            {
                cM.ClearTextBoxes(this);
                desc.Clear();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            if (dgv != "")
            {
                if (txtname.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("DO you want to update this table ", "POS Request ", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tb.Update(Convert.ToInt32(dgv), txtname.Text, Convert.ToInt32(txtType.SelectedValue.ToString()), Convert.ToInt32(floor.SelectedValue.ToString()), desc.Text);
                        MessageBox.Show(" Table has been updated ");
                        getTable();
                        cM.ClearTextBoxes(this);
                    }

                }
            }
            else
            {
                cM.ClearTextBoxes(this);
                desc.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (dgv != "")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove this table ", "POS Request ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (txtname.Text != "")
                    {
                        tb.Remove(Convert.ToInt32(dgv));
                        MessageBox.Show(" Table has been removed ");
                        getTable();
                        cM.ClearTextBoxes(this);

                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

               
            }
            else
            {
                cM.ClearTextBoxes(this);
                desc.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            desc.Clear();
            dgv = "";
             
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dgv != "")
            {
                getdata_textbox(dgv);
            }
            else
            {
                cM.ClearTextBoxes(this);
                desc.Clear();
            }
        }
    }
}
