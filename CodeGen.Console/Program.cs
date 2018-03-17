﻿using System.Linq;
using CodeGen.Compiler;
using Plotty.VirtualMachine;

namespace CodeGen.Console
{
    internal static class Program
    {
        private static void Main()
        {
            var result = new PlottyCompiler().Compile("{ a=1; b=2; }");

            var machine = new PlottyMachine();
            machine.Load(result.Code.ToList());

            while (machine.CanExecute)
            {
                machine.Execute();
            }              
        }
    }
}