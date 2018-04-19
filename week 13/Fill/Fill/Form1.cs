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

namespace Fill
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point prev, cur;
        GraphicsPath path;
        Pen pen;
        Tool tool;
        Bitmap btm;
        bool clicked = false;
        bool flag_circle_bool;
        int flag_circle_int;
        Color init_color,fill_color;
        Queue<Point> q = new Queue<Point>();
        

        enum Tool
        {
            PEN,
            FILL,
            RECTANGLE,
            CIRCLE,
            TRIANGLE,
            ERASE,
            LINE,
            CURVE,
            PALLETE
        };
        
        

        public Form1()
        {
            InitializeComponent();
            flag_circle_bool = true;
            tool = Tool.PEN;
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            g = Graphics.FromImage(btm);
            fill_color = Color.Red;
            path = new GraphicsPath();
            g.Clear(Color.White);
            pen = new Pen(Color.Black, 3);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void check(int x, int y)
        {
            if (x < 0 || x > btm.Width || y < 0 || y > btm.Height)
                return;
            if(btm.GetPixel(x,y) == init_color)
            {
                btm.SetPixel(x, y, fill_color);
                q.Enqueue(new Point(x, y));
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
            switch (tool)
            {
                case Tool.FILL:
                    int x = e.X;
                    int y = e.Y;
                    init_color = btm.GetPixel(x, y);
                    q.Enqueue(new Point(x, y));
                    btm.SetPixel(x, y, fill_color);
                    while (q.Count != 0)
                    {
                        Point p = q.Dequeue();
                        check(p.X - 1, p.Y);
                        check(p.X + 1, p.Y);
                        check(p.X, p.Y - 1);
                        check(p.X, p.Y + 1);
                    }
                    pictureBox1.Refresh();
                    break;


                case Tool.PALLETE:
                    Color color = new Color();
                    color = btm.GetPixel(e.X, e.Y);
                    init_color = color;
                    break;
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
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
                    case Tool.FILL:
                        
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
            clicked = false;
            switch (tool)
            {
                case Tool.LINE:
                    if(path != null)
                    {
                        g.DrawPath(pen, path);
                        path.Reset();
                    }
                    break;

                case Tool.CIRCLE:
                    if(path != null)
                    {
                        g.DrawPath(pen, path);  
                        path.Reset();
                        flag_circle_bool = true;
                    }
                    break;

                case Tool.RECTANGLE:
                    if(path != null)
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



        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.PEN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.FILL;
        }

        private void colorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                init_color = colorDialog1.Color;
                pen.Color = colorDialog1.Color;
            }
        }

     

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0: pen.Width = 2; break;
                case 1: pen.Width = 4; break;
                case 2: pen.Width = 6; break;
                case 3: pen.Width = 8; break;
                case 4: pen.Width = 10; break;
            }
        }

        private void color_button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            pen.Color = btn.BackColor;
            init_color = btn.BackColor;
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
                case "Fill":
                    tool = Tool.FILL;
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

        private void button8_Click(object sender, EventArgs e)
        {
            fill_color = Color.Red;
            pen.Color = Color.Red;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fill_color = Color.Green;
            pen.Color = Color.Green;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fill_color = Color.Blue;
            pen.Color = Color.Blue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fill_color = Color.Yellow;
            pen.Color = Color.Yellow;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tool = Tool.CIRCLE;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool = Tool.TRIANGLE;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.LINE;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tool = Tool.ERASE;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fill_color = Color.Black;
            pen.Color = Color.Black;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(pen, path);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tool.RECTANGLE;
        }

        

        
    }
}
