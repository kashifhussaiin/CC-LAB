﻿using CodeGen.Core;
using CodeGen.Intermediate.Codes.Common;

namespace CodeGen.Intermediate.Codes
{
    public abstract class IntermediateCode
    {
        public abstract void Accept(IIntermediateCodeVisitor visitor);
      
        public static class Emit
        {
            public static IntermediateCode Add(Reference destination, Reference left, Reference right)
            {
                return new ArithmeticAssignment(ArithmeticOperator.Add, destination, left, right);
            }

            public static IntermediateCode Substract(Reference destination, Reference left, Reference right)
            {
                return new ArithmeticAssignment(ArithmeticOperator.Substract, destination, left, right);
            }

            public static IntermediateCode IsEqual(Reference destination, Reference left, Reference right)
            {
                return new BoolExpressionAssignment(BooleanOperation.IsEqual, destination, left, right);
            }

            public static IntermediateCode Boolean(Reference destination, Reference left, Reference right)
            {
                return new BoolExpressionAssignment(BooleanOperation.IsEqual, destination, left, right);
            }

            public static IntermediateCode Mult(Reference destination, Reference left, Reference right)
            {
                return new ArithmeticAssignment(ArithmeticOperator.Mult, destination, left, right);
            }

            public static IntermediateCode JumpIfFalse(Reference reference, Label label)
            {
                return new JumpIfFalse(reference, label);
            }

            public static IntermediateCode Label(Label label)
            {
                return new LabelCode(label);
            }

            public static IntermediateCode Set(Reference destination, Reference left)
            {
                return new ReferenceAssignment(destination, left);
            }

            public static IntermediateCode Set(Reference destination, int value)
            {
                return new IntegerConstantAssignment(destination, value);
            }

            public static IntermediateCode Set(Reference destination, bool value)
            {
                return new BoolConstantAssignment(destination, value);
            }
        }             
    }
}