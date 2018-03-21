﻿using CodeGen.Ast.Units.Statements;
using CodeGen.Core;
using Superpower;
using Superpower.Parsers;

namespace CodeGen.Ast.Parsers
{
    public class Statements
    {
        public static readonly TokenListParser<LangToken, Statement> AssignmentExpression =
            from identifier in Basics.Identifier
            from eq in Token.EqualTo(LangToken.Equal)
            from expr in Expressions.Expr
            select (Statement) new AssignmentStatement(new Reference(identifier), expr);

        public static readonly TokenListParser<LangToken, Statement> StatementExpression =
            Parse.Ref(() => Block)
                .Or(
                    from statement in AssignmentExpression
                    from semicolon in Token.EqualTo(LangToken.Semicolon)
                    select statement);

        public static readonly TokenListParser<LangToken, Statement> EmptyBlock =
            from lb in Token.EqualTo(LangToken.LeftBrace)
            from rb in Token.EqualTo(LangToken.RightBrace)
            select (Statement)new Block();

        public static readonly TokenListParser<LangToken, Statement> Block =
            EmptyBlock.Try()
                .Or(from statements in StatementExpression
                        .Many()
                        .Between(Token.EqualTo(LangToken.LeftBrace), Token.EqualTo(LangToken.RightBrace))
                    select (Statement) new Block(statements));

        public static readonly TokenListParser<LangToken, Statement> ConditionalStatement =
            from keywork in Token.EqualTo(LangToken.If)
            from expr in Expressions.Expr.Between(Token.EqualTo(LangToken.LeftParenthesis), Token.EqualTo(LangToken.RightParenthesis))
            from block in Block
            select (Statement) new IfStatement(expr, block);

        public static readonly TokenListParser<LangToken, Statement> SingleStatement =
            ConditionalStatement.Or(AssignmentExpression);

        public static readonly TokenListParser<LangToken, Statement> Statement =
            Block.Or(SingleStatement);
        
        public static readonly TokenListParser<LangToken, Statement[]> ProgramParser =
            Statement.Many();
    }
}