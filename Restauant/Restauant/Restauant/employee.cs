using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Restauant
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        Class.cUser user = new Class.cUser();
        byte[] img_data = null;
        string user_id;
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        protected void getData()
        {
            DataTable Dot = new DataTable();
            dataGridView1.DataSource = cM.getAllData("select_employee", null,null,null,null);
            cM.refresh_address(position, "select * from tbl_position");
            cM.refresh_address(accesstype, "select * from user_role");
            cM.ClearTextBoxes(this);
            picBox.Image = null;
            user_id = "";

        }
        private void employee_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void position_SelectedIndexChanged(object sender, EventArgs e)
        {
           // cM.refresh_address(position ,"select * from tbl_position");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // byte[] img = null;
            if (picBox.Image == null)
            {
                picBox.BorderStyle = BorderStyle.FixedSingle;
                picBox.BackColor = Color.Tomato;

            }
            else
            {
                MemoryStream ms = new MemoryStream();
                picBox.Image.Save(ms, picBox.Image.RawFormat);
                byte[] image = ms.ToArray();

                user.Insert(fname.Text, lname.Text, sex.Text, address.Text, phone.Text, image, loginname.Text, password.Text, Convert.ToInt32(position.SelectedValue.ToString()), Convert.ToInt32(accesstype.SelectedValue.ToString()));
                getData();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImagefileDialog = new OpenFileDialog();
            ImagefileDialog.Filter = "Image |*.JPG; *.PNG; *.GIF";
            ImagefileDialog.Title = "Consumer Photo ";
            if (ImagefileDialog.ShowDialog() == DialogResult.OK)
            {

                picBox.Image = Image.FromFile(ImagefileDialog.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cM.refresh_address(position, "select * from tbl_position");
            cM.refresh_address(accesstype, "select * from user_role");
            cM.ClearTextBoxes(this);
            picBox.Image = null;
            user_id = "";
        }

        protected void getuser_Totexbox(string id)
        {
            DataTable dOT = new DataTable();
            SqlParameter par = new SqlParameter();
            par.Value = id;
            par.ParameterName = "@id";
            dOT = cM.getAllData("select_employee_by_ID", par,null,null,null);

            user_id = dOT.Rows[0]["id"].ToString();
            fname.Text = dOT.Rows[0]["fname"].ToString();
            lname.Text = dOT.Rows[0]["lname"].ToString();
            sex.Text = dOT.Rows[0]["sex"].ToString();
            address.Text = dOT.Rows[0]["address"].ToString();
            phone.Text = dOT.Rows[0]["phone"].ToString();
            loginname.Text = dOT.Rows[0]["IQName"].ToString();
            position.Text = dOT.Rows[0][13].ToString();
            accesstype.Text = dOT.Rows[0][15].ToString();
            img_data = (byte[])(dOT.Rows[0]["photo"]);
            MemoryStream ms = new MemoryStream(img_data);
            picBox.Image = Image.FromStream(ms);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getuser_Totexbox(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                if (user_id!="")
                {
                if (MessageBox.Show("Do you want to update ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    MemoryStream ms = new MemoryStream();
                    picBox.Image.Save(ms, picBox.Image.RawFormat);
                    byte[] image = ms.ToArray();

                    user.Update(Convert.ToInt32(user_id), fname.Text, lname.Text, sex.Text, address.Text, phone.Text, image, Convert.ToInt32(position.SelectedValue.ToString()), Convert.ToInt32(accesstype.SelectedValue.ToString()));
                    getData();
                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user_id != "")
            {
                if (MessageBox.Show("Do you want to remove ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    MemoryStream ms = new MemoryStream();
                    picBox.Image.Save(ms, picBox.Image.RawFormat);
                    byte[] image = ms.ToArray();

                    user.Remove(Convert.ToInt32(user_id));
                    getData();
                }



            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
