using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExInClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            /*Point clickedPoint = e.Location;
            button1.Location = clickedPoint;*/
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point clickedpoint = e.Location;
            button1.Location = clickedpoint;
            
        }
    }
}
