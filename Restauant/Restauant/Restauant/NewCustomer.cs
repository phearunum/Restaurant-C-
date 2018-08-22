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
namespace Restauant
{
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
        }
        public string table = "";
        main_function cM = new main_function();
        cCustomer cCus = new cCustomer();
        private void NewCustomer_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            

            if (MessageBox.Show("Do you want to save ?", " Application Request", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cCus.Insert(txtName.Text, txtSex.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, txtStatus.Text);
                cBooking book = new cBooking();
                book.booking(1,date,Convert.ToInt32(table), Convert.ToInt32(table));
                cM.ClearTextBoxes(this);
                txtStatus.Clear();

            }
            else
            {

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
