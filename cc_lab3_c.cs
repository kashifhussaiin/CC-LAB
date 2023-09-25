using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordSearchApp
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
            dataGridView1.Columns[0].Name = "Word";
            dataGridView1.Columns[1].Name = "Starts with";

            // Process the document text and populate the DataGridView
            ProcessDocument();
        }

        private void ProcessDocument()
        {
            // Replace this with your document text
            string documentText = "This is a sample text with words starting with t and m. Some words like tiger, monkey, and mango start with t and m.";

            // Regular expression pattern to find words starting with 't' and 'm'
            string pattern = @"\b[tmTM]\w*\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(documentText);

            foreach (Match match in matches)
            {
                string word = match.Value;
                char startsWith = Char.ToUpper(word[0]);

                dataGridView1.Rows.Add(word, startsWith);
            }
        }
    }
}
