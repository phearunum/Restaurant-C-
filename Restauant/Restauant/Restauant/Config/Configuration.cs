using Restauant.Class;
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

namespace Restauant.Config
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }
        Class.connection conn = new Class.connection();
        public static string sever,port,db,user,pass;
        protected void connect()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(Class.connection.conStr);
                Class.main_function cM = new main_function();
                DataTable Dt = new DataTable();
                Dt = cM.getAllData("sever", null,null,null,null);
                txtServer.Text = Dt.Rows[0]["serverName"].ToString();
                txtDB.Text= Dt.Rows[0]["dbName"].ToString();
                txtPort.Text= Dt.Rows[0]["portName"].ToString();
                txtUser.Text= Dt.Rows[0]["userName"].ToString();
                txtPass.Text= Dt.Rows[0]["password"].ToString();

                sever = txtServer.Text;
                port = txtPort.Text;
                db = txtDB.Text;
                user = txtUser.Text;
                pass = txtPass.Text;
            }
            catch
            {

            }

        }
        protected void load()
        {
            if (txtDB.Text != "" && txtServer.Text != "")
            {
                sever = txtServer.Text;
                port = txtPort.Text;
                db = txtDB.Text;
                user = txtUser.Text;
                pass = txtPass.Text;
                Hide();
                LoginForm log = new LoginForm();
                log.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }
        private void Configuration_Load(object sender, EventArgs e)
        {
            connect();
            // txtServer.Text= System.Windows.Forms.SystemInformation.ComputerName;
            load();
        }
     
        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                string connString = "Data Source=" + txtServer.Text + ",1433;Network Library=DBMSSOCN;Initial Catalog="
                       + txtDB.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPass.Text;

                // string connString = "Data Source=127.0.0.1,1433;Network Library=DBMSSOCN;Initial Catalog=pos;User ID=sa;Password=123;";
                SqlConnection conn = new SqlConnection(connString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand cm = new SqlCommand();
                    cm.Connection = conn;
                    cm.CommandText = "Insert into tbl_server ([serverName],[portName],[dbName],[userName],[password]) Values (@servername ,@port,@dbname,@user,@pass);";
                    var p = cm.Parameters;
                    p.AddWithValue("@servername", sever);
                    p.AddWithValue("@por", port);
                    p.AddWithValue("@dbname", db);
                    p.AddWithValue("@user", user);
                    p.AddWithValue("@pass", pass);
                    try
                    {
                        sever = txtServer.Text;
                        port = txtPort.Text;
                        db = txtDB.Text;
                        user = txtUser.Text;
                        pass = txtPass.Text;
                        load();
                        int recordsAffected = cm.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        conn.Close();
                    }
                    finally
                    {
                        conn.Close();
                        connect();
                    }

                }

                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error");
                Console.WriteLine(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
       
        }
    }
}
