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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        Class.main_function cM = new Class.main_function();
        protected void LoadProduct()
        {
            dataGridView1.DataSource = cM.getAllData("select_product", null,null,null,null);
            cM.refresh_address(p_cat,"SELECT * FROM tbl_product_category ");
            cM.refresh_address(qty_type, "Select * from tbl_qty_type");
            cM.refresh_address(suppliyer, "Select * from tbl_suppliyer");
        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadProduct();

        }
    }
}
