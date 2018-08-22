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
    public partial class calulator : Form
    {
        public calulator()
        {
            InitializeComponent();
        }
        public string pay="0";
        double val1;
        double val2;
        double result;
        string equal;
        private void calulator_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            pay = "0";
           
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button6.Text;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + button10.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                val1 = double.Parse(textBox1.Text);
                textBox1.Text = "";
                equal = "+";
            }
           
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val1 = double.Parse(textBox1.Text);
                textBox1.Text = "";
                equal = "-";
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val1 = double.Parse(textBox1.Text);
                textBox1.Text = "";
                equal = "*";
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            switch (equal)
            {
                case ("+"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 + val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("-"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 - val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("*"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 * val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("/"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 / val2;
                    textBox1.Text = result.ToString();
                    break;
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                val1 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                equal = "/";
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            switch (equal)
            {
                case ("+"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 + val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("-"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 - val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("*"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 * val2;
                    textBox1.Text = result.ToString();
                    break;

                case ("/"):
                    val2 = Convert.ToDouble(textBox1.Text);
                    result = val1 / val2;
                    textBox1.Text = result.ToString();
                    break;
            }

            pay = textBox1.Text;
            this.Close();
        }
    }
}
