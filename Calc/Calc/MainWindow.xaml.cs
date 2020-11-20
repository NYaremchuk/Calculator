using System;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            
            if (op == "")
            {
                if (txtValue.Text == "0")
                    txtValue.Text = num;
                else
                    txtValue.Text += num;
                num1 = double.Parse(txtValue.Text);
            }
            else
            {
                if (txtValue.Text == op)
                    txtValue.Text = num;
                else
                    txtValue.Text += num;
                num2 = double.Parse(txtValue.Text);
                txtValue.Text = num2.ToString();
            }
        }

        private void Btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            txtValue.Text = op;
        }

        private void Btn_equals_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = num1 / num2; break;
                case "min": result = Math.Min(num1, num2); break;
                case "max": result = Math.Max(num1, num2); break;
                case "avg": result = (num1 + num2) / 2; break;
                case "x^y": result = Convert.ToInt32(Math.Pow(num1, num2)); break;
            }
            txtValue.Text = Math.Round(result, 3).ToString();
            op = "";
            num1 = result;
            num2 = 0;
        }

        private void Btn_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            op = "";
            txtValue.Text = "0";
        }

        private void Btn_CE_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 = 0; txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = 0; txtValue.Text = num2.ToString();
            }
        }

        private void Btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (txtValue.Text.Length == 1) txtValue.Text = "0";

            else
                txtValue.Text = txtValue.Text.Remove(txtValue.Text.Length - 1, 1);

            if (txtValue.Text[txtValue.Text.Length - 1] == ',')
                txtValue.Text = txtValue.Text.Remove(txtValue.Text.Length - 1, 1);
            if (op == "")
                num1 = double.Parse(txtValue.Text);
            else
                num2 = double.Parse(txtValue.Text);
        }

        private void Btn_plusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1;
                txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txtValue.Text = num2.ToString();
            }
        }

        private void Btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (txtValue.Text.Contains(","))
                return;
            txtValue.Text += ',';
        }
    }
}
