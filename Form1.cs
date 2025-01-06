using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public bool isNumber = false;
        public double number1 = 0;
        public string operation = "";
        public double result;
        public Form1()
        {
            InitializeComponent();
            if (isNumber == false)
            {
                textBox1.Text = "0";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //Klik na cyfry
            if (textBox1.Text == "0" || isNumber)
            {
                textBox1.Text = button.Text;
                isNumber = false;
            }
            else
            {
                textBox1.Text += button.Text;
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Klik na +,-,/,x
            Button button = (Button)sender;
            string nextOperation = button.Text;
            do_operation(nextOperation);
        }
            public void do_operation(string nextOperation)
            {
            number1 = double.Parse(textBox1.Text);
            if (isNumber || operation == "")
        {
            result = number1;
        }
            else
            {
                switch (operation)
                {
                    case "/":
                        if (number1 != 0)
                        {
                            result /= number1;
                        }else {
                            MessageBox.Show("Nie wolno dzielić przez zero");
                        }
                        break;
                    case "+":
                        result += number1;
                        break;
                    case "-":
                        result -= number1;                        
                        break;
                    case "x":
                        result *= number1;
                        break;
                }
            }
                isNumber = true;
                operation = nextOperation;
            }

        
        

        private void button2_Click(object sender, EventArgs e)
        {
            //c,ce,,,+/-,=
            Button button = (Button)sender;
            if (button == null) return;
            switch (button.Text)
            {
                case "=":
                    do_operation("");
                    textBox1.Text = result.ToString();
                    operation = "";                  
                    break;
                case ",":
                    if (!textBox1.Text.Contains(","))
                    {
                            textBox1.Text += ",";
                    }
                    break;
                case "C":
                    textBox1.Text = "0";
                    break;
                case "CE":
                    textBox1.Text = "0";

                    break;
                case "X":
                    if (textBox1.Text.Length > 0)
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                        if (textBox1.Text.Length == 0)
                        {
                            textBox1.Text = "0";
                        }
                    }
                    break;
                case "+/-":
                    if (textBox1.Text[0] == '-')
                    {
                        string num = textBox1.Text;
                        num = num.Substring(1);
                        textBox1.Text = num;
                    }
                    else
                    {
                        string num = textBox1.Text;
                        string num_ = "-" + num;
                        textBox1.Text = num_;
                    }
                    break;
            }
        }
    }
}
