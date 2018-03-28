using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            bool res = true;
            for(int i = 2; i <= Math.Sqrt(n); ++i)
            {
               
                if (n % i == 0)
                {
                    res = false;
                    
                }
            }

            if(res == true && n != 1)
            {
                label1.Text="yes";
               // MessageBox.Show("yes");
            }
            else
            {
                label1.Text = "no";
               // MessageBox.Show("no");
            }
        }
    }
}
