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
    public partial class bookTable : Form
    {
        public bookTable()
        {
            InitializeComponent();
        }
        public string msg = "0";
       public  string invID;
        public string id;
       public string user;
        public string table_order;
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            Class.cTable table = new Class.cTable();
            table.book(Convert.ToInt32(id));
            Class.insert_invoice inv = new Class.insert_invoice();
                      
            string s = date.ToString("yyyy-MM-dd");
            inv.Insert(s,user,"0","0","0","0","0","0","0", table_order);
            msg = "1";
            this.Close();
        }

        private void bookTable_Load(object sender, EventArgs e)
        {
            //NewOrder order = new NewOrder();
            //od = order.txtTable.Text.ToString();
            //POS po = new POS();
            //user = po.txtID.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            msg = "0";
            this.Close();
        }
    }
}
