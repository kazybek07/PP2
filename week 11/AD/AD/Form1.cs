using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD
{
    public partial class Form1 : Form
    {
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    button1.Location = new Point(button1.Location.X - 20, button1.Location.Y);
                    break;
                case Keys.D:
                    button1.Location = new Point(button1.Location.X + 20, button1.Location.Y);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = label1.Location;
            p.Y += 20;
            if(p.Y > Height)
            
                p.Y = 0;

            label1.Location = p;

            Point p2 = label2.Location;
            p2.Y += 20;
            if (p2.Y > Height)
                p2.Y = 0;
            label2.Location = p2;

            Point p3 = label3.Location;
            p3.Y += 20;
            if (p3.Y > Height)
                p3.Y = 0;
            label3.Location = p3;

            Point p4 = label4.Location;
            p4.Y += 20;
            if (p4.Y > Height)
                p4.Y = 0;
            label4.Location = p4;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(label1.Location == button1.Location)
            {
                score += 10;
                

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if(label1.Location == button1.Location)
            {
                score += 10;
                
            }
        }
    }
}
