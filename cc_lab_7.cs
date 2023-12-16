using System;
using System.Collections.Generic;

class Parser
{
    private List<string> tokens;
    private int currentTokenIndex;

    public Parser(List<string> tokens)
    {
        this.tokens = tokens;
        this.currentTokenIndex = 0;
    }

    public void Parse()
    {
        try
        {
            ParseStmt();

            if (currentTokenIndex == tokens.Count)
            {
                Console.WriteLine("Parsing successful!");
            }
            else
            {
                throw new Exception($"Unexpected token: {tokens[currentTokenIndex]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parsing error: {ex.Message}");
        }
    }

    private void ParseStmt()
    {
        ParseID();

        if (GetNextToken() != "=")
        {
            throw new Exception("Expected '='");
        }

        ParseExpr();

        if (GetNextToken() != ";")
        {
            throw new Exception("Expected ';'");
        }
    }

    private void ParseExpr()
    {
        ParseTerm();

        while (currentTokenIndex < tokens.Count && (tokens[currentTokenIndex] == "+"))
        {
            GetNextToken(); // Consume '+'
            ParseTerm();
        }
    }

    private void ParseTerm()
    {
        ParseFactor();

        while (currentTokenIndex < tokens.Count && (tokens[currentTokenIndex] == "*"))
        {
            GetNextToken(); // Consume '*'
            ParseFactor();
        }
    }

    private void ParseFactor()
    {
        string currentToken = GetNextToken();

        if (IsID(currentToken) || IsNUM(currentToken))
        {
            // ID or NUM
        }
        else if (currentToken == "(")
        {
            ParseExpr();

            if (GetNextToken() != ")")
            {
                throw new Exception("Expected ')'");
            }
        }
        else
        {
            throw new Exception($"Unexpected token: {currentToken}");
        }
    }

    private string GetNextToken()
    {
        if (currentTokenIndex < tokens.Count)
        {
            return tokens[currentTokenIndex++];
        }
        else
        {
            throw new Exception("Unexpected end of input");
        }
    }

    private bool IsID(string token)
    {
        // Simplified check for ID
        return char.IsLetter(token[0]);
    }

    private bool IsNUM(string token)
    {
        // Simplified check for NUM
        double result;
        return double.TryParse(token, out result);
    }
}

class Program
{
    static void Main()
    {
        // Example tokens representing a simple statement in the grammar
        List<string> tokens = new List<string> { "x", "=", "5", "+", "3", "*", "2", ";" };

        Parser parser = new Parser(tokens);
        parser.Parse();
    }
}
