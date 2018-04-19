using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap btm = new Bitmap(@"star.png");
            
            
            SolidBrush brush = new SolidBrush(Color.Blue);
            Rectangle r = new Rectangle(0, 0, Width, Height);
            e.Graphics.FillRectangle(brush, r);

            Pen p = new Pen(Color.Black, 15);
            e.Graphics.DrawRectangle(p, r);
            //STAR 1
            Rectangle r2 = new Rectangle(20, 10, 30, 30);
            SolidBrush brush2 = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(brush2, r2);
            

            Pen p2 = new Pen(Color.White, 2);
            e.Graphics.DrawEllipse(p2, r2);

            //STAR 2
            Rectangle r3 = new Rectangle(200,150, 30, 30);
            SolidBrush brush3 = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(brush3, r3);


            Pen p3 = new Pen(Color.White, 2);
            e.Graphics.DrawEllipse(p3, r3);

            //STAR 3
            Rectangle r4 = new Rectangle(50, 350, 30, 30);
            SolidBrush brush4 = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(brush4, r4);


            Pen p4 = new Pen(Color.White, 2);
            e.Graphics.DrawEllipse(p4, r4);

            //STAR 4
            Rectangle r5 = new Rectangle(500, 250, 30, 30);
            SolidBrush brush5 = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(brush5, r5);


            Pen p5 = new Pen(Color.White, 2);
            e.Graphics.DrawEllipse(p5, r5);

            //STAR 5
            Rectangle r6 = new Rectangle(530, 100, 30, 30);
            SolidBrush brush6 = new SolidBrush(Color.White);
            e.Graphics.FillEllipse(brush6, r6);


            Pen p6 = new Pen(Color.White, 2);
            e.Graphics.DrawEllipse(p6, r6);


            //SPACESHIP
            Point[] arr = {
                new Point(300, 150),
                new Point(350, 200),
                new Point(350, 250),
                new Point(300, 300),
                new Point(250,250),
                new Point(250,200)
            };
            SolidBrush Polbrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillPolygon(Polbrush, arr);
            Pen pen = new Pen(Color.Yellow, 5);
            e.Graphics.DrawPolygon(pen, arr);

            //GUN
            Point[] arr2 =
            {
                new Point(300,165),
                new Point(315,180),
                new Point(305,180),
                new Point(305,210),
                new Point(295,210),
                new Point(295,180),
                new Point(285,180)
                
            };

            SolidBrush Gunbrush = new SolidBrush(Color.Green);
            e.Graphics.FillPolygon(Gunbrush, arr2);
            Pen pen2 = new Pen(Color.Green, 5);
            e.Graphics.DrawPolygon(pen2, arr2);

            //ASTEROIDS
            Point[] arr3 =
            {
                new Point(150,150),
                new Point(160,155),
                new Point(165,155),
                new Point(155,160),
                new Point(165,165),
                new Point(160,165),
                new Point(150,170),
                new Point(140,165),
                new Point(135,165),
                new Point(145,160),
                new Point(135,155),
                new Point(140,155)
            };
            SolidBrush Astbrush = new SolidBrush(Color.Red);
            e.Graphics.FillPolygon(Astbrush, arr3);
            Pen pen3 = new Pen(Color.Red, 5);
            e.Graphics.DrawPolygon(pen3, arr3);


            //BULLET
            Point[] arr4 =
            {
                new Point(300,100),
                new Point(310,110),
                new Point(325,115),
                new Point(310,120),
                new Point(300,130),
                new Point(290,120),
                new Point(275,115),
                new Point(290,110)
            };
            SolidBrush bulbrush = new SolidBrush(Color.Green);
            e.Graphics.FillPolygon(bulbrush, arr4);
            Pen pen4 = new Pen(Color.Green, 5);
            e.Graphics.DrawPolygon(pen4, arr4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    


                    break;
            }
        }
    }
}
