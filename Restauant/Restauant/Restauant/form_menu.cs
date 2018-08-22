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
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace Restauant
{
    public partial class form_menu : Form
    {
        public form_menu()
        {
            InitializeComponent();
        }
        main_function cM = new main_function();
        cMenu_Items cM_Item = new cMenu_Items();
        //string imgloc;
        string dvg = "";
        string menu_item_id;
        string code_check;
        byte[] img_data = null;
        public void listCategory()
        {
            cM.refresh_address(txtcat, "SELECT * FROM menu_category;");
        }

        public void loadData()
        {
            dataGridView1.DataSource = cM.getAllData("itemslist", null,null,null,null);
        }

        private void form_menu_Load(object sender, EventArgs e)
        {
            createProduct();
            listCategory();
            loadData();
            buttonSave();
        }

        public void buttonSave()
        {
            btn_save.Enabled = true;
            btn_clear.Enabled = true;
            btn_remove.Enabled = false;
            btn_update.Enabled = false;

        }
        public void buttonUpdate()
        {
            btn_save.Enabled = false;
            btn_clear.Enabled = true;
            btn_remove.Enabled = true;
            btn_update.Enabled = true;

        }
        public void createProduct()
        {

            //flowLayoutPanel1.Controls.Clear();


            //// DataTable dt = new DataTable();
           
            //DataTable Dot = new DataTable();
            //Dot = cM.getAllData("ListMenuItem", null, null, null, null);

            //// da.Fill(Dot);

            //for (int i = 0; i < Dot.Rows.Count; i++)
            //{
                                           
               

            //    // group box item
            //    Panel gbox = new Panel();
            //    gbox.BorderStyle = BorderStyle.FixedSingle;
            //    gbox.Width = 200;
            //    gbox.Height = 80;
            //   // gbox.BackColor = Color.White;
            //    gbox.Cursor = Cursors.Hand;

            //    // for Text List 
            //    FlowLayoutPanel pnlroght = new FlowLayoutPanel();
            //    pnlroght.Dock = DockStyle.Right;
            //   // pnlroght.BackColor = Color.White;
            //    pnlroght.Width = 120;
                
            //    // Panel for Image 
            //    Panel pnl = new Panel();
            //    pnl.Dock = DockStyle.Left;
            //    pnl.Width = 80;
            //    pnl.BackColor = Color.Blue; 
                             
            //    PictureBox pic = new PictureBox();
            //    img_data = (byte[])(Dot.Rows[i][5]);
            //    //Image img = new Image(img_data);
            //    pic.BackgroundImage = Properties.Resources.dust;
            //    MemoryStream ms = new MemoryStream(img_data);
            //    pic.Image = Bitmap.FromStream(ms);
            //    pic.SizeMode = PictureBoxSizeMode.StretchImage;
            //    Size size = new Size(90, 80);
            //    pic.Size = size;
            //    pnl.Controls.Add(pic);
               
            //    // for titel
            //    Label titel = new Label();
            //    titel.Font = new Font("Arial", 10);
            //    titel.Text =Dot.Rows[i][1].ToString();
            //    pnlroght.Controls.Add(titel);

            //    //for price
            //    Label price = new Label();
            //    price.Font = new Font("Arial", 10);
            //    price.Text ="Price :"+ Dot.Rows[i][3].ToString();
            //    pnlroght.Controls.Add(price);

            //    gbox.Controls.Add(pnl);
            //    gbox.Controls.Add(pnlroght);
            //    string evn = Dot.Rows[i][0].ToString();
            //    pic.Click += new EventHandler((sender, e) => Method(sender, e, evn));
            //    flowLayoutPanel1.Controls.Add(gbox);
            //}

        }
        protected void Method(object sender, EventArgs e, string name)
        {
            DataTable oDT = new DataTable();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@id";
            par.Value = name;
            oDT = cM.getAllData("ItemToTextBox", par, null, null, null);
            try
            {

                img_data = (byte[])(oDT.Rows[0]["photo"]);

                if (img_data == null)
                {
                    picBox.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img_data);
                    picBox.Image = Bitmap.FromStream(ms);

                }
               

            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_category fcat = new form_category();
            fcat.ShowDialog();
            listCategory();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImagefileDialog = new OpenFileDialog();
            ImagefileDialog.Filter = "Image |*.JPG; *.PNG; *.GIF";
            ImagefileDialog.Title = "Consumer Photo ";
            if (ImagefileDialog.ShowDialog() == DialogResult.OK)
            {
              
                picBox.Image= Image.FromFile(ImagefileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = cM.getAllData("itemslist",null,null,null,null);
           
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                code_check = Dt.Rows[0][1].ToString();
            }
           

            if (txtcode.Text !=code_check)
                {
                    if (dvg != "")
                    {

                    }
                    else
                    {


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

                            cM_Item.Insert(txtname.Text, txtcode.Text, Convert.ToInt32(txtcat.SelectedValue.ToString()), txtprice.Text, image, info.Text);
                            cM.ClearTextBoxes(this);
                            info.Clear();
                            picBox.Image = null;
                            createProduct();
                            loadData();
                        }

                    }


            }
            else
            {
                MessageBox.Show(" Item Code has already exit ");
                txtcode.Clear();
                txtcode.Focus();
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dvg!="")
            {
            if (MessageBox.Show("Do you want to remove ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cM_Item.RemoveItem(menu_item_id);
                loadData();
                    dvg = "";
                    buttonSave();
                }
            }
        }

        protected void getData_to_textBox( string id)
        {
            DataTable Dt = new DataTable();
            SqlParameter par_id = new SqlParameter();
            par_id.ParameterName = "@id";
            par_id.Value = id;

            Dt = cM.getAllData("select_product_byID", par_id,null,null,null);
            txtname.Text = Dt.Rows[0][1].ToString();
            txtprice.Text = Dt.Rows[0][2].ToString();
            txtcat.Text = Dt.Rows[0][4].ToString();
            menu_item_id = Dt.Rows[0][0].ToString();
            info.Text = Dt.Rows[0]["info"].ToString(); 
            txtcode.Text= Dt.Rows[0]["item_Code"].ToString();
            // img_data = (byte[])(Dt.Rows[0][3]);

            img_data = (byte[])(Dt.Rows[0][3]);
            MemoryStream ms = new MemoryStream(img_data);
            picBox.Image = Image.FromStream(ms);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dvg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dvg != "")
            {
                getData_to_textBox(dvg);
            }
            buttonUpdate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dvg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dvg != "")
            {
                getData_to_textBox(dvg);
            }
            buttonUpdate();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            dvg = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dvg!="")
            {
                getData_to_textBox(dvg);
            }
            buttonUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dvg!="")
            {           
            if (MessageBox.Show("Do you want to update ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                MemoryStream ms = new MemoryStream();
                picBox.Image.Save(ms,picBox.Image.RawFormat);
                byte[] image = ms.ToArray();
                
                  cM_Item.Update(menu_item_id, txtname.Text,txtcode.Text, Convert.ToInt32(txtcat.SelectedValue.ToString()),txtprice.Text,txtprice.Text,image,info.Text,1);
                    cM.ClearTextBoxes(this);
                    info.Clear();
                    picBox.Image = null;
                    createProduct();
                    loadData();
                    MessageBox.Show("Item has been updated");
                    dvg = "";
                    buttonSave();      
             }
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            picBox.Image =null;
            buttonSave();
            cM.ClearTextBoxes(this);
            cM.refresh_address(txtcat, "SELECT * FROM menu_category;");
            info.Clear();
            dvg = "";
        }
    }
}
