using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccmid
{
    internal class LL1Parser
    {
        private string[] tokens;
        private int index;

        public LL1Parser(string input)
        {
            // Tokenize the input string (split by comma)
            tokens = input.Split(',');
            index = 0;
        }

        public void Parse()
        {
            if (List())
            {
                if (index == tokens.Length)
                {
                    Console.WriteLine("Parsing successful!");
                }
                else
                {
                    Console.WriteLine("Parsing error. Unexpected tokens.");
                }
            }
            else
            {
                Console.WriteLine("Parsing error.");
            }
        }

        private bool List()
        {
            if (Item())
            {
                return Rest();
            }
            return false;
        }

        private bool Rest()
        {
            if (index < tokens.Length && tokens[index] == ",")
            {
                index++;
                if (Item())
                {
                    return Rest();
                }
                return false;
            }
            return true; // ε (empty string)
        }

        private bool Item()
        {
            if (index < tokens.Length && (tokens[index] == "id" || tokens[index] == "num" || tokens[index] == "string"))
            {
                index++;
                return true;
            }
            return false;
        }


    }
}
