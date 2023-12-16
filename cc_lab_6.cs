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
            while (currentTokenIndex < tokens.Count)
            {
                ParseStatement();
            }

            Console.WriteLine("Parsing successful!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Parsing error: {ex.Message}");
        }
    }

    private void ParseStatement()
    {
        string currentToken = GetNextToken();

        if (IsDataType(currentToken))
        {
            // Variable declaration
            ParseVariableDeclaration(currentToken);
        }
        else if (IsIdentifier(currentToken))
        {
            // Assignment statement
            ParseAssignmentStatement(currentToken);
        }
        else
        {
            throw new Exception($"Unexpected token: {currentToken}");
        }
    }

    private void ParseVariableDeclaration(string dataType)
    {
        string identifier = GetNextToken();

        if (!IsIdentifier(identifier))
        {
            throw new Exception($"Expected identifier after {dataType}");
        }

        Console.WriteLine($"Variable Declaration: {dataType} {identifier}");

        // Check for semicolon to end the statement
        if (GetNextToken() != ";")
        {
            throw new Exception("Expected semicolon at the end of the statement");
        }
    }

    private void ParseAssignmentStatement(string identifier)
    {
        if (GetNextToken() != "=")
        {
            throw new Exception($"Expected '=' after {identifier}");
        }

        string value = GetNextToken();

        Console.WriteLine($"Assignment: {identifier} = {value}");

        // Check for semicolon to end the statement
        if (GetNextToken() != ";")
        {
            throw new Exception("Expected semicolon at the end of the statement");
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

    private bool IsDataType(string token)
    {
        // Simplified check for data types (int, float, etc.)
        string[] dataTypes = { "int", "float", "double", "char", "boolean" };
        return Array.Exists(dataTypes, t => t == token);
    }

    private bool IsIdentifier(string token)
    {
        // Simplified check for identifiers (variable names)
        return char.IsLetter(token[0]) || token[0] == '_';
    }
}

class Program
{
    static void Main()
    {
        // Example tokens representing a simple Java program
        List<string> tokens = new List<string>
        {
            "int", "x", ";",
            "float", "y", "=", "5.0", ";",
            "double", "z", "=", "10.5", ";"
        };

        Parser parser = new Parser(tokens);
        parser.Parse();
    }
}
