﻿using CodeGen.Parsing.Ast;

namespace CodeGen.Parsing
{
    public class Program : ICodeUnit
    {
        public Unit[] Units { get; }

        public Program(Unit[] units)
        {
            Units = units;
        }

        public void Accept(ICodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}