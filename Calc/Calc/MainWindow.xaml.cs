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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num1 = 0;
        int num2;
        string op = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();
            int num = Int32.Parse(str);
            if (op == "")
            {
                num1 = num1 * 10 + num;
                txtValue.Text = num1.ToString(); 
            }
            else
            {
                num2 = num2 * 10 + num;
                txtValue.Text = num2.ToString();
            }

        }

        private void btn_option_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            txtValue.Text = op;
        }

        private void btn_equals_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
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
            txtValue.Text = result.ToString();
            op = "";
            num1 = result;
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            op = "";
            txtValue.Text = "0";
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
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

        private void btn_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 = num1 / 10; txtValue.Text = num1.ToString();
            }
            else
            {
                num2 = num2 / 10; txtValue.Text = num2.ToString();
            }

        }

        private void btn_plusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 *= -1; txtValue.Text = num1.ToString();
            }
            else
            {
                num2 *= -1; txtValue.Text = num2.ToString();
            }
        }
    }
}
