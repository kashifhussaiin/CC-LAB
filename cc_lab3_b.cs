using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ScientificNotationValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the DataGridView
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Input";
            dataGridView1.Columns[1].Name = "Validation Result";
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            // Clear the DataGridView
            dataGridView1.Rows.Clear();

            // Regular Expression for numbers in scientific notation
            string pattern = @"^[+-]?(\d+(\.\d*)?|\.\d+)([eE][+-]?\d+)?$";
            Regex regex = new Regex(pattern);

            // Input numbers in scientific notation
            string[] inputNumbers = { "8e4", "5e-2", "6e9" };

            foreach (string input in inputNumbers)
            {
                bool isValid = regex.IsMatch(input);
                dataGridView1.Rows.Add(input, isValid ? "Valid" : "Invalid");
            }
        }
    }
}
