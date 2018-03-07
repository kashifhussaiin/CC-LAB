using System.Collections.Generic;
using CodeGen.Intermediate.Codes;
using CodeGen.Units;

namespace CodeGen.Intermediate
{
    public class NamedObjectCollector : IIntermediateCodeVisitor
    {
        private readonly List<Label> labels = new List<Label>();
        private readonly List<Reference> references = new List<Reference>();

        public IEnumerable<Reference> References => references.AsReadOnly();
        public IEnumerable<Label> Labels => labels.AsReadOnly();

        public void Visit(JumpIfFalse code)
        {
            AddReference(code.Reference);
            AddLabel(code.Label);
        }

        public void Visit(BoolConstantAssignment code)
        {
            AddReference(code.Target);
        }

        public void Visit(LabelCode code)
        {
            AddLabel(code.Label);
        }

        public void Visit(IntegerConstantAssignment code)
        {
            AddReference(code.Target);
        }

        public void Visit(OperationAssignment code)
        {
            AddReference(code.Target);
            AddReference(code.Left);
            AddReference(code.Right);
        }

        public void Visit(ReferenceAssignment code)
        {
            AddReference(code.Target);
            AddReference(code.Origin);
        }

        public void Visit(BoolExpressionAssignment boolExpressionAssignment)
        {
            AddReference(boolExpressionAssignment.Target);
            AddReference(boolExpressionAssignment.Left);
            AddReference(boolExpressionAssignment.Right);
        }

        private void AddReference(Reference reference)
        {
            references.Add(reference);
        }

        private void AddLabel(Label label)
        {
            labels.Add(label);
        }
    }
}