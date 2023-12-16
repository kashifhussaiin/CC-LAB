using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SLRParser
{
    // Define your grammar rules and actions
    // You need to replace these with your actual grammar and actions
    private Dictionary<string, string> semanticActions = new Dictionary<string, string>
    {
        { "Program_begin ( ) { DecS Decs Decs AssS IffS } end", "SemanticActionForProgram" },
        { "DecS_int Var = Const ;", "SemanticActionForDeclaration" },
        // Add more grammar rules and their semantic actions
    };

    private Stack<string> stack = new Stack<string>();

    public void Parse(List<string> tokens)
    {
        int pointer = 0;

        // Implement your SLR parsing logic here
        while (true)
        {
            // SLR parsing logic goes here

            // Example: shift or reduce based on the grammar rules

            // Example: Perform semantic actions if needed
            if (semanticActions.ContainsKey(stack.Peek()))
            {
                string action = semanticActions[stack.Peek()];
                PerformSemanticAction(action, tokens[pointer]);
            }
        }
    }

    private void PerformSemanticAction(string action, string token)
    {
        // Implement your semantic actions here based on the action and token
        // Example: Use a switch statement to handle different actions
        switch (action)
        {
            case "SemanticActionForProgram":
                // Implement semantic action for Program
                break;

            case "SemanticActionForDeclaration":
                // Implement semantic action for Declaration
                break;

            // Add more cases for other semantic actions

            default:
                // Handle unknown actions
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        List<string> inputTokens = new List<string> { "Program_begin", "(", ")", "{", "DecS", "Decs", "AssS", "}", "end" };
        SLRParser parser = new SLRParser();
        parser.Parse(inputTokens);
    }
}
