using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint3
{
    public partial class Form1 : Form
    {
        Graphics g;
        GraphicsPath path;
        Pen pen;
        Point prev,cur;
        bool flag_circle_bool;
        int flag_circle_int;
        Bitmap btm;
        Tool tool;
        
        enum Tool
        {
            PEN,
            RECTANGLE,
            CIRCLE,
            LINE,
            ERASE,
            TRIANGLE
        }

        public Form1()
        {
            InitializeComponent();
            flag_circle_bool = true;
            tool = Tool.PEN;
            pen = new Pen(Color.Black, 3);
            path = new GraphicsPath();

            //Main graphics
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;

            //Create graphics from bitmap
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // save clicked position of mouse
            prev = e.Location;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //remove all previous shapes if GraphicPath
            

            //check for mouse left button clicked 
            if(e.Button == MouseButtons.Left)
            {
                path.Reset();
                switch (tool)
                {
                    case Tool.PEN:
                        cur = e.Location;
                        g.DrawLine(pen, prev, cur);
                        prev = cur;
                        break;

                    case Tool.LINE:
                        cur = e.Location;
                        path.AddLine(prev, cur);
                        break;

                    case Tool.RECTANGLE:
                        cur = e.Location;
                        if (cur.X < prev.X && cur.Y < prev.Y)
                            path.AddRectangle(new Rectangle(cur.X, cur.Y, Math.Abs(cur.X - prev.X), Math.Abs(cur.Y - prev.Y)));

                        else if (cur.Y > prev.Y && cur.X < prev.X)
                            path.AddRectangle(new Rectangle(cur.X, prev.Y, prev.X - cur.X, cur.Y - prev.Y));

                        else if (cur.X > prev.X && cur.Y < prev.Y)
                            path.AddRectangle(new Rectangle(prev.X, cur.Y, cur.X - prev.X, prev.Y - cur.Y));

                        else
                            path.AddRectangle(new Rectangle(prev.X, prev.Y, Math.Abs(cur.X - prev.X), Math.Abs(cur.Y - prev.Y)));
                        break;

                    case Tool.CIRCLE:
                        cur = e.Location;
                        if (flag_circle_bool)
                        {
                            flag_circle_int = cur.Y;
                        }
                        path.AddEllipse(new Rectangle(prev.X, cur.Y, cur.X - prev.X, cur.Y - prev.Y));
                        flag_circle_bool = false;
                        break;

                    case Tool.ERASE:
                        cur = e.Location;
                        g.DrawLine(new Pen(Color.White, pen.Width), prev, cur);
                        prev = cur;
                        break;

                    case Tool.TRIANGLE:
                        cur = e.Location;
                        Point[] points = new Point[] { new Point(prev.X, prev.Y), new Point(prev.X - (cur.X - prev.X), cur.Y), cur };
                        path.AddPolygon(points);
                        break;
                }
               
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // if GraphicsPath not empty draw last position of the position of the shape in Main Graphics(Bitmap)
            switch (tool)
            {
                case Tool.LINE:
                    if (path != null)
                    {
                        g.DrawPath(pen, path);
                        path.Reset();
                    }
                    break;

                case Tool.CIRCLE:
                    if (path != null)
                    {
                        g.DrawPath(pen, path);
                        path.Reset();
                        flag_circle_bool = true;
                    }
                    break;

                case Tool.RECTANGLE:
                    if (path != null)
                    {
                        g.DrawPath(pen, path);
                        path.Reset();
                    }
                    break;
                case Tool.TRIANGLE:
                    if (path != null)
                    {
                        g.DrawPath(pen, path);
                        path.Reset();
                    }
                    break;
            }
        }
        private void tools_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Name)
            {
                case "Pen":
                    tool = Tool.PEN;
                    break;
                case "Rect":
                    tool = Tool.RECTANGLE;
                    break;
                case "Line":
                    tool = Tool.LINE;
                    break;
                case "Trian":
                    tool = Tool.TRIANGLE;
                    break;
                case "Erase":
                    tool = Tool.ERASE;
                    break;
                case "Circle":
                    tool = Tool.CIRCLE;
                    break;
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Draw all temporary shapes in Graphics of Picturebox
           
            e.Graphics.DrawPath(pen, path);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.RECTANGLE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.CIRCLE;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.PEN;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool = Tool.LINE;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tool = Tool.ERASE;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Yellow;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Green;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Blue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tool.TRIANGLE;
        }
    }
}
