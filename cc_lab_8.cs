using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Compile_Click(object sender, EventArgs e)
        {
            string Initial_State = "S0";
            string Final_State = "S2";
            var dict = new Dictionary<string, Dictionary<char, object>>();

            dict.Add("S0", new Dictionary<char, object>()
            {
                { 'a', "S1" },
                { 'b', "Se" },
                { 'c', "Se" },
                // Add more transitions as needed
            });

            dict.Add("S1", new Dictionary<char, object>()
            {
                { 'a', "S2" },
                { 'b', "S2" },
                { 'c', "S2" },
                // Add more transitions as needed
            });

            dict.Add("S2", new Dictionary<char, object>()
            {
                { 'a', "S2" },
                { 'b', "S2" },
                { 'c', "S2" },
                // Add more transitions as needed
            });

            dict.Add("Se", new Dictionary<char, object>()
            {
                { 'a', "Se" },
                { 'b', "Se" },
                { 'c', "Se" },
                // Add more transitions as needed
            });

            char check;
            string state;
            string strinput = Input.Text;
            char[] charinput = strinput.ToCharArray();
            check = charinput[0];
            state = Initial_State;
            int j = 0;

            while (check != '\\' && state != "Se")
            {
                if (dict[state].ContainsKey(check))
                {
                    state = dict[state][check] + "";
                }
                else
                {
                    state = "Se"; // Transition to error state if the input is not in the dictionary
                }

                j++;

                if (j < charinput.Length)
                {
                    check = charinput[j];
                }
                else
                {
                    break;
                }
            }

            if (state.Equals(Final_State))
            {
                Output.Text = "RESULT OKAY";
            }
            else
            {
                Output.Text = "ERROR";
            }
        }
    }
}
