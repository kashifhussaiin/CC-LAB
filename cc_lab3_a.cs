using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sessional1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Take input from a RichTextBox or TextBox
            string input = richTextBox1.Text;

            // Split the input on the basis of spaces
            string[] words = input.Split(' ');

            // Regular Expression for floating-point numbers with length not greater than 6
            Regex regex1 = new Regex(@"\b\d{1,6}(?:\.\d{1,6})?\b");

            for (int i = 0; i < words.Length; i++)
            {
                // Remove any trailing punctuation (e.g., semicolon)
                string word = words[i].TrimEnd(new char[] { ';', ',', '.', '!', '?' });

                Match match1 = regex1.Match(word);

                if (match1.Success)
                {
                    richTextBox2.Text += word + " ";
                }
                else
                {
                    MessageBox.Show("Invalid: " + word);
                }
            }
        }
    }
}
