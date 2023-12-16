using System;
using System.Collections.Generic;
using System.IO;

class LexicalAnalyzer
{
    private StreamReader reader;
    private char[] buffer1;
    private char[] buffer2;
    private int currentBuffer;
    private int currentPosition;

    public LexicalAnalyzer(string filePath)
    {
        reader = new StreamReader(filePath);
        buffer1 = new char[1024];
        buffer2 = new char[1024];
        currentBuffer = 1;
        currentPosition = 0;
        FillBuffer();
    }

    private void FillBuffer()
    {
        int bytesRead = reader.Read(currentBuffer == 1 ? buffer1 : buffer2, 0, buffer1.Length);
        currentBuffer = (currentBuffer == 1) ? 2 : 1;
        currentPosition = 0;

        if (bytesRead == 0)
        {
            // End of file reached
            reader.Close();
        }
    }

    private char GetNextChar()
    {
        if (currentPosition >= buffer1.Length)
        {
            FillBuffer();
        }

        return currentBuffer == 1 ? buffer1[currentPosition++] : buffer2[currentPosition++];
    }

    public List<string> Tokenize()
    {
        List<string> tokens = new List<string>();
        char currentChar;

        while ((currentChar = GetNextChar()) != '\0')
        {
            // Ignore whitespaces
            if (char.IsWhiteSpace(currentChar))
            {
                continue;
            }

            // Tokenize digits
            if (char.IsDigit(currentChar))
            {
                string number = currentChar.ToString();

                while (char.IsDigit(currentChar = GetNextChar()))
                {
                    number += currentChar;
                }

                tokens.Add("Number: " + number);
            }

            // Tokenize operators
            else if (IsOperator(currentChar))
            {
                string op = currentChar.ToString();
                tokens.Add("Operator: " + op);
            }

            // Tokenize parentheses
            else if (currentChar == '(' || currentChar == ')')
            {
                tokens.Add("Parenthesis: " + currentChar);
            }

            // Tokenize identifiers
            else if (char.IsLetter(currentChar))
            {
                string identifier = currentChar.ToString();

                while (char.IsLetterOrDigit(currentChar = GetNextChar()))
                {
                    identifier += currentChar;
                }

                tokens.Add("Identifier: " + identifier);
            }
        }

        return tokens;
    }

    private bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }
}

class Program
{
    static void Main()
    {
        string filePath = "path_to_your_source_code_file.txt";
        LexicalAnalyzer lexer = new LexicalAnalyzer(filePath);
        List<string> tokens = lexer.Tokenize();

        Console.WriteLine("Tokens:");
        foreach (string token in tokens)
        {
            Console.WriteLine(token);
        }
    }
}
