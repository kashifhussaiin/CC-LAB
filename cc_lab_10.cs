// Initializations
ArrayList States = new ArrayList();
Stack<String> Stack = new Stack<String>();
String Parser;
String[] Col = { "begin", "(", ")", "{", "int", "a", "b", "c", "=", "5", "10", "0", ";", "if", ">", "print", "else", "$", "}", "+", "end", "Program", "DecS", "AssS", "IffS", "PriS", "Var", "Const" };

// Parsing table
var dict = new Dictionary<string, Dictionary<String, object>>();
// ... (parsing table entries)

// Grammar rules for different states
States.Add("Program_begin ( ) { DecS Decs Decs AssS IffS } end");
States.Add("DecS_int Var = Const ;");
// ... (other grammar rules)

Stack.Push("0");
finalArray.Add("$");
int pointer = 0;
while (true)
{
    if (!Col.Contains(finalArray[pointer]))
    {
        Output.AppendText("Unable to Parse Unknown Input");
        break;
    }

    Parser = dict[Stack.Peek() + ""][finalArray[pointer] + ""] + "";

    if (Parser.Contains("S"))
    {
        Stack.Push(finalArray[pointer] + "");
        Parser = Parser.TrimStart('S');
        Stack.Push(Parser);
        pointer++;
        Print_Stack();
    }

    // ... (other parsing actions)
    
    if (Parser.Contains("Accept"))
    {
        Output.AppendText("Parsed");
        break;
    }

    if (Parser.Equals(""))
    {
        Output.AppendText("Unable to Parse");
        break;
    }
}
