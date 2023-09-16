using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace cc_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Regex regex1 = new Regex(@"&&|\|\||!");
        //esign regular expression for relational operators:  
        // Regex regex1 = new Regex(@"==|!=|<|<=|>|>=");

        private void button1_Click(object sender, EventArgs e)
        {
            // Take input from a richtextbox/textbox
            string input = text1.Text;

            // Define the regular expression pattern for relational operators
            Regex regex1 = new Regex(@"==|!=|<|<=|>|>=");

            // Find all matches in the input text
            MatchCollection matches = regex1.Matches(input);

            // Output the matched relational operators
            foreach (Match match in matches)
            {
                text2.Text += match.Value + " ";
            }
        }


        private RichTextBox text1;
        private RichTextBox text2;
        private Button button1;

        private void InitializeComponent()
        {
            this.text1 = new System.Windows.Forms.RichTextBox();
            this.text2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(348, 100);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(100, 96);
            this.text1.TabIndex = 0;
            this.text1.Text = "";
            // 
            // text2
            // 
            this.text2.Location = new System.Drawing.Point(488, 100);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(100, 96);
            this.text2.TabIndex = 1;
            this.text2.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(878, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }

    
    }
