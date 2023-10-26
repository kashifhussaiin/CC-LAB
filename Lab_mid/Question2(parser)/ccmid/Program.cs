using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccmid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input string to parse
            string input = "id, num, string, id, num";

            // Create the parser
            LL1Parser parser = new LL1Parser(input);

            // Start parsing
            parser.Parse();
        }
    }
}
