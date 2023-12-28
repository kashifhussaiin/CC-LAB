using System;

// Lexical Analysis
public enum TokenType { Identifier, Number, Plus, Minus, Multiply, Divide, LeftParen, RightParen, EndOfFile, Error }

public class Token
{
    public TokenType Type { get; }
    public string Lexeme { get; }

    // Additional properties for error handling
    public char UnexpectedCharacter { get; }
    public int Position { get; }

    // Constructor for regular tokens
    public Token(TokenType type, string lexeme)
    {
        Type = type;
        Lexeme = lexeme;
    }

    // Constructor for error tokens
    public Token(TokenType type, char unexpectedCharacter, int position)
    {
        Type = type;
        UnexpectedCharacter = unexpectedCharacter;
        Position = position;
    }
}

public class Scanner
{
    private readonly string input;
    private int position = 0;

    public Scanner(string input)
    {
        this.input = input;
    }

    public Token GetNextToken()
    {
        if (position >= input.Length)
            return new Token(TokenType.EndOfFile, "");

        char currentChar = input[position];
        position++;

        switch (currentChar)
        {
            case '+': return new Token(TokenType.Plus, "+");
            case '-': return new Token(TokenType.Minus, "-");
            case '*': return new Token(TokenType.Multiply, "*");
            case '/': return new Token(TokenType.Divide, "/");
            case '(': return new Token(TokenType.LeftParen, "(");
            case ')': return new Token(TokenType.RightParen, ")");
            default:
                if (char.IsDigit(currentChar))
                    return ScanNumber(currentChar);
                else if (char.IsLetter(currentChar))
                    return ScanIdentifier(currentChar);
                else
                    return new Token(TokenType.Error, currentChar, position - 1);
        }
    }

    private Token ScanNumber(char firstDigit)
    {
        string number = firstDigit.ToString();

        while (position < input.Length && char.IsDigit(input[position]))
        {
            number += input[position];
            position++;
        }

        return new Token(TokenType.Number, number);
    }

    private Token ScanIdentifier(char firstLetter)
    {
        string identifier = firstLetter.ToString();

        while (position < input.Length && (char.IsLetterOrDigit(input[position]) || input[position] == '_'))
        {
            identifier += input[position];
            position++;
        }

        return new Token(TokenType.Identifier, identifier);
    }
}

// Syntax Analysis and Code Generation
public class Parser
{
    private readonly Scanner scanner;
    private Token currentToken;

    public Parser(Scanner scanner)
    {
        this.scanner = scanner;
        currentToken = scanner.GetNextToken();
    }

    public void Parse()
    {
        Expression();
        Console.WriteLine("Parsing and Code Generation Successful.");
    }

    private void Expression()
    {
        Term();
        while (currentToken.Type == TokenType.Plus || currentToken.Type == TokenType.Minus)
        {
            Token op = currentToken;
            Match(op.Type);
            Term();

            // Generate Code
            Console.WriteLine($"Perform {op.Type} operation");
        }
    }

    private void Term()
    {
        Factor();
        while (currentToken.Type == TokenType.Multiply || currentToken.Type == TokenType.Divide)
        {
            Token op = currentToken;
            Match(op.Type);
            Factor();

            // Generate Code
            Console.WriteLine($"Perform {op.Type} operation");
        }
    }

    private void Factor()
    {
        if (currentToken.Type == TokenType.Number || currentToken.Type == TokenType.Identifier)
        {
            // Generate Code
            Console.WriteLine($"Load {currentToken.Lexeme} into register");
            Match(currentToken.Type);
        }
        else if (currentToken.Type == TokenType.LeftParen)
        {
            Match(TokenType.LeftParen);
            Expression();
            Match(TokenType.RightParen);
        }
        else if (currentToken.Type == TokenType.Error)
        {
            // Handle the error
            Console.WriteLine($"Unexpected character '{currentToken.UnexpectedCharacter}' at position {currentToken.Position}");
            // Move to the next token
            currentToken = scanner.GetNextToken();
        }
        else
        {
            throw new Exception($"Unexpected token: {currentToken.Type}");
        }
    }

    private void Match(TokenType expectedToken)
    {
        if (currentToken.Type == expectedToken)
            currentToken = scanner.GetNextToken();
        else
            throw new Exception($"Expected {expectedToken}, but got {currentToken.Type}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the source code: ");
        string sourceCode = Console.ReadLine();
        Scanner scanner = new Scanner(sourceCode);
        Parser parser = new Parser(scanner);
        parser.Parse();
    }
}
