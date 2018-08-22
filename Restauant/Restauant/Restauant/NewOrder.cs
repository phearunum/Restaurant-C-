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
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
            ListTable();
          // Menu_();
        }
        POS po = new POS();
        Class.main_function cM = new Class.main_function();
        Class.connection conn = new Class.connection();
        SqlConnection cnn = new SqlConnection(Class.connection.conStr);
        //string imgloc;
        //int checkTabl = 0;
        string bg;
        byte[] img_data = null;
        public string ID_USER;
        string item_catID;
        //string pID, pName, pQty, pPrice, pDiscount, pAmount;
        private void NewOrder_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        protected void getTopId()
        {
            DataTable dt = new DataTable();
            dt = cM.getAllData("select_top_inv", null, null, null, null);
            txtInvo.Text = dt.Rows[0][0].ToString();

        }

        protected void get_order_hold(string inv_hold)
        {
            SqlParameter pa = new SqlParameter();          
            pa.ParameterName = "@ID";
            pa.Value = inv_hold;        
            dataGridView2.DataSource = cM.getAllData("select_Order_by_inv",pa,null,null,null);
            getTotal();
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
        }
        protected void gethold_inv(string table)
        {
            SqlParameter pa = new SqlParameter();
            DataTable ODT = new DataTable();
            pa.ParameterName = "@ID";
            pa.Value = table;
            ODT = cM.getAllData("select_inv_by_invID", pa, null, null, null);
            txtInvo.Text = ODT.Rows[0][0].ToString();

        }
        protected void getExchage()
        {
            DataTable DT = new DataTable();
            DT = cM.getAllData("select_exchage_today", null,null,null,null);
            txtexchage.Text = DT.Rows[0][1].ToString();
        }
        private void NewOrder_Load(object sender, EventArgs e)
        {
            getTopId();
            getExchage();
            flowLayoutPanel2.Hide();     
            txt_cash_discount.Text = po.name;
            dataGridView1.AutoGenerateColumns = false;
            pic_alert.Hide();
         slide_left.Size = new System.Drawing.Size(0,0);
            createProduct();
         
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
           // Menu_();
            timer1.Start();
            ListCategory();
            txtAmount.Text = "0";
            txtDiscount.Text = "0";
            txtPay.Text = "0";
            txtTotal.Text = "0";
            txtTotal.Text = "0";
            txtTable.Text = "0";
            txtUSD.Text = "0";
            txtReal.Text = "0";
            txtBack.Text = "0";
          



        }
        protected void ListCategory()
        {
            flowLayoutPanel3.Controls.Clear();


            DataTable Dot = new DataTable();
            Dot = cM.getAllData("Listcategory", null, null, null, null);
            item_catID = Dot.Rows[0][0].ToString();
            for (int i = 0; i < Dot.Rows.Count; i++)
            {
                Button gbox = new Button();
                gbox.Width = 80;
                gbox.Height = 40;
                gbox.Cursor = Cursors.Hand;
                gbox.FlatStyle = FlatStyle.Flat;
                gbox.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.dust));
                gbox.Text = Dot.Rows[i][1].ToString();
                gbox.Font = new Font(Font.Name, Font.Size, FontStyle.Bold);

                string evn = Dot.Rows[i][0].ToString();

                gbox.Click += new EventHandler((sender, e) => menu_cat(sender, e, evn));

                flowLayoutPanel3.Controls.Add(gbox);
            }

        }
        protected void ListTable()
        {
            flowLayoutPanel1.Controls.Clear();


            DataTable Dot = new DataTable();
            Dot = cM.getAllData("ListTable", null, null, null, null);
         
            for (int i = 0; i < Dot.Rows.Count; i++)
            {
                Button gbox = new Button();
                gbox.Width = 140;
                gbox.Height = 60;
                gbox.Cursor = Cursors.Hand;
                gbox.FlatStyle = FlatStyle.Flat;
                gbox.BackColor = Color.White;
              
                gbox.Text =" Table : "+ Dot.Rows[i][0].ToString();
                gbox.Font = new Font(Font.Name,Font.Size, FontStyle.Bold);
                bg = Dot.Rows[i][5].ToString();
            
                
                string evn = Dot.Rows[i][0].ToString();
                if (bg=="1")
                {
                   
                    gbox.BackColor = Color.LightGreen;
                    //gbox.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.strawberries));
                    gbox.Click += new EventHandler((sender, e) => Booking_Table(sender, e, evn));                              
                   
                }
                else
                {
                    //gbox.BackColor = Color.;
                    gbox.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.dust));
                    gbox.Click += new EventHandler((sender, e) => Open_menu(sender, e, evn));
                  
                }
           
                flowLayoutPanel1.Controls.Add(gbox);
            }


        }
        protected void Booking_Table(object sender, EventArgs e, string tableID)
        {
            txtTable.Text = tableID;
          
           
           
            CheckOut out_ = new CheckOut();
            out_.id = tableID;
            out_.Text ="Table : "+ tableID;
            out_.ShowDialog();
            string fine = out_.order_item;
            if (fine=="1")
            {
                flowLayoutPanel1.Hide();
                flowLayoutPanel2.Show();
                Menu_();
                gethold_inv(txtTable.Text);
                get_order_hold(txtInvo.Text);
            }
            else if(fine=="0")
            {
                flowLayoutPanel1.Enabled=false;
                flowLayoutPanel2.Hide();
                gethold_inv(txtTable.Text);
                get_order_hold(txtInvo.Text);
            }
            else
            {

            }
           
            ListTable();

        }
        protected void Open_menu(object sender, EventArgs e,string tableID)
        {
            txtTable.Text = tableID;
            bookTable book = new bookTable();
            book.id = txtTable.Text;
            book.user = ID_USER;
            book.table_order = txtTable.Text;
            book.invID = txtInvo.Text;
            book.Text = "Book Table : " + tableID;
            book.ShowDialog();
            if (book.msg=="1")
            {
                txtTable.Text = txtTable.Text;
                book.Text = txtTable.Text;
                ListTable();
                flowLayoutPanel1.Hide();
                flowLayoutPanel2.Show();
                Menu_();
            }
            else
            {
                ListTable();
            }
           

        }

        protected void menu_category()
        {
            
        }
        protected void Menu_()
        {
            flowLayoutPanel2.Controls.Clear();

            SqlParameter par = new SqlParameter();
            par.ParameterName = "@id";
            par.Value = item_catID;
            DataTable Dot = new DataTable();
            Dot = cM.getAllData("listItemMenu_by_catID", par, null, null, null);
            for (int i = 0; i < Dot.Rows.Count; i++)
            {
               
                Panel gbox = new Panel();
                gbox.Width =120;
                gbox.Height = 160;
              
                gbox.BackColor = Color.White;
                gbox.Cursor = Cursors.Hand;
              
                PictureBox pic = new PictureBox();
                img_data = (byte[])(Dot.Rows[i][5]);
              
                MemoryStream ms = new MemoryStream(img_data);
                pic.Image = Bitmap.FromStream(ms);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                Size size = new Size(120, 120);
                pic.Margin = new Padding(5);
                pic.Size = size;
                pic.Dock = DockStyle.Top;

                Label price = new Label();
               
                price.Font= new Font("Arial",9);
                price.Text = Dot.Rows[i][1].ToString();
                price.AutoSize = true;
                price.ForeColor = Color.Black;
                Panel right = new Panel();
              
                right.Dock = DockStyle.Bottom;
                right.Width = 120;
                right.Height = 30;
                right.Controls.Add(price);
                gbox.Controls.Add(right);
                gbox.Controls.Add(pic);

                string evn = Dot.Rows[i][0].ToString();

                pic.Click += new EventHandler((sender, e) => LoadItem(sender, e,evn));
              
                flowLayoutPanel2.Controls.Add(gbox);
            }
        }
        protected void menu_cat(object sender, EventArgs e, string catID)
        {
            item_catID = catID;
            Menu_();


        }
        protected void LoadItem(object sender, EventArgs e, String name)
        {
            



            DataTable tb = new DataTable();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@Id";
            par.Value = name;
            tb = cM.getAllData("select_product_byID", par, null, null, null);          
            Class.cOrder_detial order = new Class.cOrder_detial();

                    order.Insert(Convert.ToInt32(txtInvo.Text), Convert.ToInt32(tb.Rows[0][0].ToString()), 1, tb.Rows[0][2].ToString(), "00", tb.Rows[0][2].ToString());
                    get_order_hold(txtInvo.Text);
                    getTotal();
              
          

           
        }
        protected void AddOrder()
        {
           
    
        }
        protected void Method(object sender, EventArgs e, String name)
        {
            int index = 0;
            bool isExist = false;
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
           
            DataTable tb = new DataTable();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@Id";
            par.Value = name;
            tb = cM.getAllData("select_product_byID", par, null, null, null);
            string id = tb.Rows[0][0].ToString();
         

            if (dataGridView1.Rows.Count - 1 > 0)
            {
               
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == tb.Rows[0][0].ToString())
                    {
                        isExist = true;
                        index = i;

                    }

                }

                double quantityXprice = Convert.ToDouble(tb.Rows[0][2].ToString()) * Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString());
                // if the product already exist
                // check the stock quantity
                if (isExist)
                {
                    int pqty = Convert.ToInt32(dataGridView1.Rows[index].Cells[2].Value.ToString());
                    dataGridView1.Rows[index].Cells[2].Value = pqty + 1;
                    // dataGridView1.Rows[index].Cells[4].Value = Convert.ToInt32(dataGridView1.Rows[index].Cells[2].Value) *Convert.ToInt32(dataGridView1.Rows[index].Cells[3].Value);
                    double ms = Convert.ToDouble(dataGridView1.Rows[index].Cells[2].Value);
                    double s=Convert.ToDouble(dataGridView1.Rows[index].Cells[3].Value);
                    dataGridView1.Rows[index].Cells[5].Value = Convert.ToDouble(ms * s)+".000";
                    // MessageBox.Show(ms+" * "+s);
                     getTotal();

                }
                else
                {

                    dataGridView1.Rows.Add(tb.Rows[0][0].ToString(), tb.Rows[0][1].ToString(), 1, tb.Rows[0][2].ToString(),
                            "0.0%" ,tb.Rows[0][2].ToString(),false);
                    getTotal();
                }
                  
        } else if(dataGridView1.Rows.Count - 1 ==0)
            {

                dataGridView1.Rows.Add(tb.Rows[0][0].ToString(), tb.Rows[0][1].ToString(), 1, tb.Rows[0][2].ToString()
                             ,"0.0 %", tb.Rows[0][2].ToString(),false);
                getTotal();
            }



}
        private void btn_table_Click(object sender, EventArgs e)
        {

            
        }
        public void getTotal()
        {
            txtTotal.Text = (from DataGridViewRow row in dataGridView2.Rows
                             where row.Cells[5].FormattedValue.ToString() != string.Empty
                             select Convert.ToDouble(row.Cells[5].FormattedValue)).Sum().ToString();
            double ttT = Convert.ToDouble(txtTotal.Text);
            double ttDic = 0;
            if (txtDiscount.Text!="")
            {
               ttDic = Convert.ToDouble(txtDiscount.Text);
            }
            else
            {
                ttDic = 0;
            }
           

            txtAmount.Text = ((ttT)-(ttDic * ttT / 100)).ToString();
            txtUSD.Text = txtAmount.Text;
            double tt_cash_disc = ttT - Convert.ToDouble(txtAmount.Text);
            txt_cash_discount.Text = tt_cash_disc.ToString();
           double r = 4000;
            if (txtUSD.Text!="")
            {
                double usd = Convert.ToDouble(txtUSD.Text);
                txtReal.Text = (usd * r).ToString();
            }
                
            
           
           
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "0")
            {
            }
            else{
                try
                {               

                    fPayment fpay = new fPayment();
                    //fpay.txtGetReal = "0";
                    //fpay.txtGetUsd = "0";
                    fpay.ShowDialog();
                    if (fpay.txtGetUsd != "")
                    {
                        if (exUSD.Text != "")
                        { exUSD.Text = (Convert.ToDouble(exUSD.Text) + Convert.ToDouble(fpay.txtGetUsd)).ToString(); }
                        else { exUSD.Text = fpay.txtGetUsd; }

                        double usd = Convert.ToDouble(exUSD.Text);
                        double ex = Convert.ToDouble(txtexchage.Text);
                        exReal.Text = (usd * ex).ToString();

                    }
                    else if (fpay.txtGetReal != "")
                    {
                        if (exReal.Text != "")
                        { exReal.Text = (Convert.ToDouble(exReal.Text) + Convert.ToDouble(fpay.txtGetReal)).ToString(); }
                        else { exReal.Text = fpay.txtGetReal; }
                        double real = Convert.ToDouble(exReal.Text);
                        double ex = Convert.ToDouble(txtexchage.Text);
                        exUSD.Text = (real / ex).ToString();

                    }
                    else
                    {
                        txtPay.Text = "0";
                    }
                    txtPay.Text = exUSD.Text;

                    if (txtPay.Text != "")
                    {
                        double pp = Convert.ToDouble(txtPay.Text);
                        double tt = Convert.ToDouble(txtAmount.Text);
                        if (tt > pp)
                        {

                            pic_alert.Show();
                        }
                        else
                        {
                            txtBack.Text = (pp - tt).ToString();
                            pic_alert.Hide();
                        }


                    }
                }
                catch
                {

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {

          addDiscount fm = new addDiscount();           
            fm.ShowDialog();
            if (fm.rate_dis!="")
            {

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                if (this.dataGridView2.SelectedRows.Count > 0)
                {
                   
                        if (this.dataGridView2.SelectedRows.Count > 0)
                        {
                            Class.cOrder_detial order = new Class.cOrder_detial();
                            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                            int id__ = Convert.ToInt32(selectedRow.Cells[0].Value);
                            order.add_discount(Convert.ToInt32(txtInvo.Text), Convert.ToInt32(id__), Convert.ToInt32(fm.rate_dis));
                            gethold_inv(txtTable.Text);
                            get_order_hold(txtInvo.Text);
                        }

                    
                   
                    }
                }
            }

            }
        }
        public void createProduct()
        {

            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    if (this.dataGridView2.SelectedRows.Count > 0)
                    {
                        int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                        int id__ = Convert.ToInt32(selectedRow.Cells[0].Value);
                        Class.cOrder_detial order = new Class.cOrder_detial();
                        order.Adjust(Convert.ToInt32(txtInvo.Text), id__);
                        gethold_inv(txtTable.Text);
                        get_order_hold(txtInvo.Text);
                        getTotal();
                    }
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    if (this.dataGridView2.SelectedRows.Count > 0)
                    {

                        int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                        int id__ = Convert.ToInt32(selectedRow.Cells[0].Value);

                        messange.voidInvoice msg = new messange.voidInvoice();
                        msg.txtMSG.Text = "Do you want to remove Items code =>" + id__;
                        msg.ShowDialog();
                        if (msg.vale == "1")
                        {
                            Class.cOrder_detial order = new Class.cOrder_detial();
                            order.Remove(Convert.ToInt32(txtInvo.Text), id__);
                            gethold_inv(txtTable.Text);
                            get_order_hold(txtInvo.Text);
                            getTotal();
                        }
                        else
                        {

                        }



                    }
                }
            }
           
        }

        protected void Payment_print()
        {
            if (dataGridView2.RowCount > 1)
            {

          
            if (txtPay.Text != "" && txtTotal.Text != "")
            {

                double pp = Convert.ToDouble(txtPay.Text);
                double tt = Convert.ToDouble(txtAmount.Text);
                if (tt > pp)
                {
                    // MessageBox.Show(" Enter payment ");
                    pic_alert.Show();
                }
                else
                {

                    Class.cOrder_detial order = new Class.cOrder_detial();

                    messange.voidInvoice msg = new messange.voidInvoice();
                    msg.txtMSG.Text = " Do you want to print invoice";
                    msg.ShowDialog();
                    if (msg.vale == "1")
                    {
                        DateTime date__ = DateTime.Now; // Or whatever
                        string s = date__.ToString("yyyy-MM-dd");
                        Class.insert_invoice inv = new Class.insert_invoice();
                        inv.Update(Convert.ToInt16(txtInvo.Text), s, ID_USER, txtTotal.Text, txtDiscount.Text, txtPay.Text, txtBack.Text, txtAmount.Text, txtReal.Text, txt_cash_discount.Text);
                        fThankyou thx = new fThankyou();
                        thx.ShowDialog();

                        report.printInvoice print = new report.printInvoice();
                        print.invID = txtInvo.Text;
                        print.Cashier = txtcashier.Text;
                        print.ShowDialog();
                        Class.cTable table = new Class.cTable();
                        table.Checkout(Convert.ToInt32(txtTable.Text));
                        getTopId();
                        dataGridView1.Rows.Clear();
                        txtAmount.Text = "0";
                        txtDiscount.Text = "0";
                        txtPay.Text = "0";
                        txtTotal.Text = "0";
                        txtTotal.Text = "0";
                        txtTable.Text = "0";
                        txtUSD.Text = "0";
                        txtReal.Text = "0";
                        txtBack.Text = "0";
                        ListTable();
                        txtTable.Text = "0";
                        txtInvo.Text = "0";
                        get_order_hold(txtInvo.Text);
                        flowLayoutPanel1.Enabled = true;
                        flowLayoutPanel2.Hide();
                        flowLayoutPanel1.Show();
                        getTopId();
                    }
                    else
                    {

                    }


                }

                }

            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Payment_print();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addDiscount dis = new addDiscount();
            dis.ShowDialog();
            txtDiscount.Text = dis.rate_dis;
            getTotal();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void button7_Click(object sender, EventArgs e)
        {




            try
            {
                //cM.ClearTextBoxes(this);
                Class.cOrder_detial order = new Class.cOrder_detial();
                
                dataGridView1.Rows.Clear();
                exUSD.Text = "0";
                exReal.Text = "0";
                txtReal.Text = "0";
                txtAmount.Text = "0";
                txtDiscount.Text = "0";
                txtPay.Text = "0";
                txtTotal.Text = "0";
                txtTotal.Text = "0";
                txtTable.Text = "0";
                txtUSD.Text = "0";
                txtReal.Text = "0";
                txtBack.Text = "0";
                txtInvo.Text = "0";
                fPayment pay = new fPayment();
                pay.txtGetReal = "0";
                pay.txtGetUsd = "0";

                get_order_hold(txtInvo.Text);
                ListTable();
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel2.Hide();
                flowLayoutPanel1.Show();
                getTopId();
                getExchage();

            }
            catch
            {

            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            fexchange ex = new fexchange();
            ex.ShowDialog();
            getExchage();
        }

        private void txt_date_Click(object sender, EventArgs e)
        {
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            messange.voidInvoice move_inv = new messange.voidInvoice();
            move_inv.txtMSG.Text = "Do you want to remove invoice => "+ txtInvo.Text ;
            move_inv.ShowDialog();
            if (move_inv.vale=="1")
            {
                Class.cOrder_detial order = new Class.cOrder_detial();
                order.Void_Invoice(Convert.ToInt32(txtInvo.Text));
                Class.cTable table = new Class.cTable();
                table.Checkout(Convert.ToInt32(txtTable.Text));
                getTopId();
                txtTable.Text = "0";
                get_order_hold(txtInvo.Text);
            }
            else
            {
                MessageBox.Show("OK");
            }
            
            ListTable();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmCategorylist catlist = new frmCategorylist();
            catlist.ShowDialog();
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }
        
        private const int VerticalStep = 40;
        private void button13_Click(object sender, EventArgs e)
        {

            flowLayoutPanel3.Left -= VerticalStep;
            timer2.Start();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            slide_left.Size = new System.Drawing.Size(0, 0);
            flowLayoutPanel3.Left += VerticalStep;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmCategorylist pre = new frmCategorylist();
                pre.txtsubTotal.Text = txtTotal.Text;
                pre.txtDiscount.Text = txtDiscount.Text;
                pre.txtCashresive.Text = txtPay.Text;
                pre.txtcashReturn.Text = txtBack.Text;
                pre.txtAmount.Text = txtAmount.Text;

                pre.txtsubReal.Text = (Convert.ToDouble(txtTotal.Text) * Convert.ToDouble(txtexchage.Text)).ToString();
                pre.txtdiscountcash.Text = (Convert.ToDouble(txt_cash_discount.Text) * Convert.ToDouble(txtexchage.Text)).ToString();
                pre.txtamountReal.Text = (Convert.ToDouble(txtAmount.Text) * Convert.ToDouble(txtexchage.Text)).ToString();
                pre.txtResivereal.Text = (Convert.ToDouble(txtPay.Text) * Convert.ToDouble(txtexchage.Text)).ToString();
                pre.txtcashreturnReal.Text = (Convert.ToDouble(txtBack.Text) * Convert.ToDouble(txtexchage.Text)).ToString();
                pre.ShowDialog();

                if (pre.print != "1")
                {
                    Payment_print();
                }
                else
                {

                }

            }
            catch
            {

            }
           
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            addDiscount dis = new addDiscount();
            dis.ShowDialog();
            txtDiscount.Text = dis.rate_dis;
            getTotal();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            messange.voidInvoice smg = new messange.voidInvoice();
            smg.txtMSG.Text = " Do you want to exit ?";
            smg.ShowDialog();
            if (smg.vale == "1")
            {
                Close();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //slide_left.Size = new System.Drawing.Size(600, 200);
           //int slide= slide_left.Width = Width + 600;
            if (slide_left.Width ==0)
            {
                slide_left.Size = new System.Drawing.Size(600,200);
                timer2.Stop();
                this.Refresh();
            }
            else
            {
                this.slide_left.Width =0;
                timer2.Stop();
                this.Refresh();
            }
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void slide_left_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            slide_left.Width = 0 ;
        }
    }
       
       

    
}
