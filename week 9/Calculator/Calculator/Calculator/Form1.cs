using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
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
            textBox1.Text += btn.Text;
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            firstNumber = double.Parse(textBox1.Text);
            operation = btn.Text;
            
            textBox1.Text = "";
        }

        private void result_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(textBox1.Text);
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
            }
            textBox1.Text = result.ToString();
        }
        private void clear_Click(object sender, EventArgs e)
        {
            textBox1 .Text = "";
            firstNumber = 0;
            secondNumber = 0;
            result = 0;
            operation = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
