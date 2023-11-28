using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public bool isNumber = false;
        public string number = "";
        public double number1 = 0;
        public double number2 = 0;
        public string operation = "";
        public string nextOperation = "";
        public bool isOperation = false;
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
            if (isNumber==false)
            {
                textBox1.Text = button.Text;
                number = textBox1.Text;
                isNumber = true;
            }
            else
            {
                textBox1.Text += button.Text;
                number = textBox1.Text;
            }
            number1 = double.Parse(textBox1.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Klik na +,-,/,x
            //do_operation();
            Button button = (Button)sender;
            operation = button.Text;
            do_operation();
        }
            public void do_operation()
            {
               /* if (number1+number2 == 0) {
                number1 = double.Parse(number);
                number = "";
            }
            else {
                result = number1;
                number1 = double.Parse(number); 
            }
              */
              //  number1 = double.Parse(textBox1.Text);
              result = number1;
            if ((number1==0) || operation == "")
        {
            // Якщо це перше число або після '='
            result = number1;
        }
            else
            {
                switch (operation)
                {
                    case "/":
                        textBox1.Text = "/";
                        if (number1 != 0)
                        {
                            result /= number1;
                           // number1 = result;
                        }else {
                            MessageBox.Show("Nie wolno dzielić przez zero");
                        }
                        
                        break;
                    case "+":
                        textBox1.Text = "+";
                        result += number1;
                        //number1 = result;
                        break;
                    case "-":
                        textBox1.Text = "-";
                        result = number1 - number2;
                        number1 = result;
                        
                        break;
                    case "x":
                        textBox1.Text = "x";
                        result = number2 * number1;
                        number1 = result;
                        break;
                }

            }
                isNumber = false;
                operation = nextOperation;
                operation = "";
            }

        
        

        private void button2_Click(object sender, EventArgs e)
        {
            //c,ce,,,+/-,=
            Button button = (Button)sender;
            if (button == null) return;
            //double dn1, dn2, result;
            //result = 0;

            switch (button.Text)
            {
                case "=":
                    isOperation = true;
                    do_operation();
                    textBox1.Text = result.ToString();
                    number = textBox1.Text;
                    isNumber = true;
                  
                    break;
                case ",":
                    if (!textBox1.Text.Contains(","))
                    {
                        if (isNumber == false)
                        {
                            textBox1.Text = "0" + button.Text;
                            number = textBox1.Text;
                            isNumber = true;
                        }
                        else
                            textBox1.Text += ",";
                            number = textBox1.Text;
                    }
                    break;
                case "C":
                    textBox1.Text = "0";
                    break;
                case "CE":
                    textBox1.Text = "0";

                    break;
                case "X":
                    // Видаляємо останній символ
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
