﻿namespace CodeGen.Plotty.Model
{
    public class SourceTarget : JumpTarget
    {
        public Source Target { get; }

        public SourceTarget(Source target)
        {
            Target = target;
        }
    }
}