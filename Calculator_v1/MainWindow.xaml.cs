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

namespace Calculator_v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            button_ac.Click += button_ac_Click;
            button_negative.Click += button_negative_Click;
            button_prctg.Click += button_prctg_Click;
            button_equal.Click += button_equal_Click;
        }

        void button_equal_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(label_result.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
            }

            label_result.Content = result.ToString();
        }


        void button_prctg_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(label_result.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                label_result.Content = lastNumber.ToString();
            }
        }

        private void button_negative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(label_result.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                label_result.Content = lastNumber.ToString();
            }
        }

        private void button_ac_Click(object sender, RoutedEventArgs e)
        {
            label_result.Content = "0";
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Number_Click(object sender, RoutedEventArgs e)
        {
            String selectedValue = "0";

            if (sender == button_0) selectedValue = "0";
            if (sender == button_1) selectedValue = "1";
            if (sender == button_2) selectedValue = "2";
            if (sender == button_3) selectedValue = "3";
            if (sender == button_4) selectedValue = "4";
            if (sender == button_5) selectedValue = "5";
            if (sender == button_6) selectedValue = "6";
            if (sender == button_7) selectedValue = "7";
            if (sender == button_8) selectedValue = "8";
            if (sender == button_9) selectedValue = "9";


            if (label_result.Content.ToString() == "0")
            {
                label_result.Content = selectedValue;
            }
            else
            {
                label_result.Content += selectedValue;
            }
        }

        private void button_Operation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(label_result.Content.ToString(), out lastNumber))
            {
                label_result.Content = "0";
            }

            if (sender == button_divide) selectedOperator = SelectedOperator.Division;
            if (sender == button_multip) selectedOperator = SelectedOperator.Multiplication;
            if (sender == button_subs) selectedOperator = SelectedOperator.Substraction;
            if (sender == button_sum) selectedOperator = SelectedOperator.Addition;

        }

        private void button_decimal_Click(object sender, RoutedEventArgs e)
        {
            if (label_result.Content.ToString().Contains("."))
            {
                // do nothing
            }
            else
            {
                label_result.Content += ".";
            }
        }

        public enum SelectedOperator
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        }

        public class SimpleMath
        {
            public static double Add(double n1, double n2)
            {
                return n1 + n2;
            }
            public static double Substract(double n1, double n2)
            {
                return n1 - n2;
            }
            public static double Multiply(double n1, double n2)
            {
                return n1 * n2;
            }
            public static double Divide(double n1, double n2)
            {
                if (n2 == 0) 
                {
                    MessageBox.Show("Division by zero is not supported!!!", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }
                
                return n1 / n2;
            }
        }

    }
}
