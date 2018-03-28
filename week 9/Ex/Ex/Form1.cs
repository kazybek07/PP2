using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex
{
    public partial class Form1 : Form
    {
        double firstNumber = 0, secondNumber = 0, result = 0;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void numbers_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            

            if(display.Text == "0")
            {
                display.Text = display.Text.Remove(0);
            }
            display.Text += btn.Text;

        }
        private void operation_Click(object sender, EventArgs e)
        {
             Button btn = sender as Button;
             
            firstNumber = double.Parse(display.Text);
            
            operation = btn.Text;

            display.Text = "";
        }

        private void display_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            result = 0;
            display.Text = result.ToString();
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            result = Math.Pow(10, double.Parse(display.Text));
            display.Text = result.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            result = Math.Pow(double.Parse(display.Text),2);
            display.Text = result.ToString();
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            result = 1 / double.Parse(display.Text);
            if(double.Parse(display.Text) == 0)
            {
                MessageBox.Show("division by zero!");
            }
            display.Text = result.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            result = Math.Sqrt(double.Parse(display.Text));
            display.Text = result.ToString();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            
        }

        private void button21_Click(object sender, EventArgs e)
        {

            double n = (double.Parse(display.Text) * Math.PI) / 180;
            result = Math.Sin(n);
            display.Text = result.ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            double n = (double.Parse(display.Text) * Math.PI) / 180;
            result = Math.Cos(n);
            display.Text = result.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            double n = (double.Parse(display.Text) * Math.PI) / 180;
            result = Math.Tan(n);
            display.Text = result.ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            result = Math.Abs(double.Parse(display.Text));
            display.Text = result.ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            result = Math.Exp(double.Parse(display.Text));
            display.Text = result.ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 9\Ex\ms.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(display.Text);
            sw.Close();
            fs.Close();

        }

        private void button27_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\local\Desktop\PP\week 9\Ex\ms.txt", string.Empty);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 9\Ex\ms.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            result = double.Parse(s);
            display.Text = result.ToString();
            sr.Close();
            fs.Close();

        }

        private void button29_Click(object sender, EventArgs e)
        {
                FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 9\Ex\ms.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string s = sr.ReadLine();
                result = double.Parse(display.Text) + double.Parse(s);
                display.Text = result.ToString();

        }

        private void button30_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\local\Desktop\PP\week 9\Ex\ms.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            result = double.Parse(display.Text) - double.Parse(s);
            display.Text = result.ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            result = double.Parse(display.Text) * (-1);
            display.Text = result.ToString();
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            string s = display.Text.Remove(display.Text.Length - 1);

            if (display.Text.Length == 1)
            {
                result = 0;

            }
            else result = double.Parse(s);
            display.Text = result.ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            result = Math.Log10(double.Parse(display.Text));
            display.Text = result.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (display.Text == "")

                display.Text = "0,";
            else if (display.Text.Contains(","))
                display.Text = display.Text;
            else
                display.Text = display.Text + ",";
            

        }

        private void result_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(display.Text);
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    if(secondNumber == 0)
                    {
                        MessageBox.Show("Division by zero!");
                    }
                    break;
                case "x^y":
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
            }
            display.Text = result.ToString();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            display.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = "";
        }
    }
}