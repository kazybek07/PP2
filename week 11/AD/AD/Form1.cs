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
        List<Label> labels = new List<Label>();
        bool Gameover = false;

        public Form1()
        {
            InitializeComponent();
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);

            
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

            if (Gameover == true) return;
            for (int i = 0; i < labels.Count; ++i)
            {
                labels[i].Location = new Point(labels[i].Location.X, (labels[i].Location.Y + 20) % Height);
            }
            for (int i = 0; i < labels.Count; ++i)
            {
                if (dointersect(button1.Location.X, button1.Location.Y,
                    button1.Location.X + button1.Width, button1.Location.Y + button1.Height,
                    labels[i].Location.X, labels[i].Location.Y,
                    labels[i].Location.X + labels[i].Width,
                    labels[i].Location.Y + labels[i].Height))
                {
                    Gameover = true;

                    MessageBox.Show("Game over");
                    return;
                }
            }
            label1 = labels[0];
            label2 = labels[1];
            label3 = labels[2];
            label4 = labels[3];
            label5 = labels[4];
            label6 = labels[5];
            label7 = labels[6];

            
        }

        public bool dointersect(int x, int y, int x1, int y1, int X, int Y, int X1, int Y1)
        {
            if (x <= X && X <= x1 && y <= Y && Y <= y1)
            {
                return true;
            }
            if (x <= X1 && X1 <= x1 && y <= Y && Y <= y1)
            {
                return true;
            }
            if (x <= X && X <= x1 && y <= Y1 && Y <= y1)
            {
                return true;
            }
            if (x <= X1 && X1 <= x1 && y <= Y1 && Y1 <= y1)
            {
                return true;
            }
            return false;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(label1.Location == button1.Location)
            {
                //score += 10;
                

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if(label1.Location == button1.Location)
            {
                //score += 10;
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
