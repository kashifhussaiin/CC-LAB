﻿namespace CodeGen.Intermediate.Units.Statements
{
    public abstract class Statement : ICodeUnit
    {
        public abstract void Accept(ICodeVisitor visitor);
    }
}