using System;
using System.Windows.Forms;

namespace CSHARPLAB
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private char currentOperator = ' ';
        private bool isNewInput = true;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            // Initialize event handlers for numeric buttons
            b0.Click += NumericButton_Click;
            b1.Click += NumericButton_Click;
            b2.Click += NumericButton_Click;
            b3.Click += NumericButton_Click;
            b4.Click += NumericButton_Click;
            b5.Click += NumericButton_Click;
            b6.Click += NumericButton_Click;
            b7.Click += NumericButton_Click;
            b8.Click += NumericButton_Click;
            b9.Click += NumericButton_Click;

            // Initialize event handler for dot button
            dot.Click += DotButton_Click;

            // Initialize event handlers for operator buttons
            add.Click += OperatorButton_Click;
            sub.Click += OperatorButton_Click;
            mul.Click += OperatorButton_Click;
            div.Click += OperatorButton_Click;

            // Initialize event handler for equal button
            equal.Click += EqualButton_Click;

            // Initialize event handler for clear button
            clear.Click += ClearButton_Click;
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isNewInput)
            {
                textBox1.Text = "";
                isNewInput = false;
            }

            textBox1.Text += button.Text;
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (!isNewInput && !textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentOperator = button.Text[0];

            if (!isNewInput)
            {
                firstNumber = double.Parse(textBox1.Text);
                isNewInput = true;
            }
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            if (!isNewInput)
            {
                secondNumber = double.Parse(textBox1.Text);

                switch (currentOperator)
                {
                    case '+':
                        textBox1.Text = (firstNumber + secondNumber).ToString();
                        break;
                    case '-':
                        textBox1.Text = (firstNumber - secondNumber).ToString();
                        break;
                    case '*':
                        textBox1.Text = (firstNumber * secondNumber).ToString();
                        break;
                    case '/':
                        if (secondNumber != 0)
                            textBox1.Text = (firstNumber / secondNumber).ToString();
                        else
                            MessageBox.Show("Division by zero is not allowed.");
                        break;
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            currentOperator = ' ';
            isNewInput = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}