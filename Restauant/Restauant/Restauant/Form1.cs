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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        Class.login login = new Class.login();
        Class.main_function cM = new main_function();
        private static string name1;

        public string id;
        public static string Name1
        {
            get
            {
                return name1;
            }

            set
            {
                name1 = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);


        }
        string role = "";
        protected void login_in()
        {
             role = login.GetLogin(txtname.Text, txtpwd.Text);
            if (role!="")
            {
                DataTable Dot = new DataTable();
                SqlParameter par = new SqlParameter();
                par.Value = txtname.Text;
                par.ParameterName = "@id";
                Dot = cM.getAllData("getUserLogin", par, null, null, null);

                POS pos1 = new POS();
                pos1.txtName.Text = Dot.Rows[0][1].ToString();
                pos1.txtID.Text = Dot.Rows[0][0].ToString();
                NewOrder ord = new NewOrder();
                Name1 = txtname.Text;
                //   ord.textBox2.Text = txtname.Text.ToString();
                // Id = Dot.Rows[0][0].ToString();
               pos1.ShowDialog();
                cM.ClearTextBoxes(this);
                role = "";
                this.Hide();
            }
            else
            {
                txtpwd.Clear();
                txtpwd.Focus();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            login_in();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtpwd_Enter(object sender, EventArgs e)
        {
            login_in();
        }

        private void txtpwd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void txtpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_in(); 
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
