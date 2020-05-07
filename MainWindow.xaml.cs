using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "0";
            this.textBox.Text += input;
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "1";
            this.textBox.Text += input;
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "2";
            this.textBox.Text += input;
        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "3";
            this.textBox.Text += input;
        }

        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "4";
            this.textBox.Text += input;
        }

        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "5";
            this.textBox.Text += input;
        }

        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "6";
            this.textBox.Text += input;
        }

        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "7";
            this.textBox.Text += input;
        }

        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "8";
            this.textBox.Text += input;
        }

        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += "9";
            this.textBox.Text += input;
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            input += ".";
            this.textBox.Text += input;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            operand1 = input;
            operation = '/';
            input = string.Empty;
            this.textBox.Text += '/';
        }

        private void mult_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            operand1 = input;
            operation = '*';
            input = string.Empty;
            this.textBox.Text += '*';
        }

        private void addb_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            operand1 = input;
            operation = '+';
            input = string.Empty;
            this.textBox.Text += '+' ;
        }

        private void subb_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            operand1 = input;
            operation = '-';
            input = string.Empty;
            this.textBox.Text += '-';
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            this.textBox.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;

            if (operation == '+')
            {
                result = num1 + num2;
                textBox.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = num1 - num2;
                textBox.Text = result.ToString();
            }
            else if (operation == '*')
            {
                result = num1 * num2;
                textBox.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                    textBox.Text = result.ToString();
                }
                else
                {
                    textBox.Text = "DIV/Zero!";
                }
            }
        }

        private void clearb_Click(object sender, RoutedEventArgs e)
        {
            this.textBox.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
