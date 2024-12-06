using System;
using System.Windows;

namespace MyCalculatorApp
{
    public partial class MainWindow : Window
    {
        private double _firstNumber = 0;
        private double _secondNumber = 0;
        private string _operator = string.Empty;
        private bool _isOperatorClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string number = (sender as System.Windows.Controls.Button).Content.ToString();

            if (_isOperatorClicked)
            {
                Display.Text = string.Empty;
                _isOperatorClicked = false;
            }

            Display.Text += number;
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            _firstNumber = Convert.ToDouble(Display.Text);
            _operator = (sender as System.Windows.Controls.Button).Content.ToString();
            _isOperatorClicked = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _secondNumber = Convert.ToDouble(Display.Text);

                double result = _operator switch
                {
                    "+" => _firstNumber + _secondNumber,
                    "-" => _firstNumber - _secondNumber,
                    "*" => _firstNumber * _secondNumber,
                    "/" => _secondNumber != 0 ? _firstNumber / _secondNumber : throw new DivideByZeroException(),
                    _ => 0
                };

                Display.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Display.Text = "Error";
                MessageBox.Show(ex.Message, "Calculation Error");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
            _firstNumber = 0;
            _secondNumber = 0;
            _operator = string.Empty;
        }
    }
}
