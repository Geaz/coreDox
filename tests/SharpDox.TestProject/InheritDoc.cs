using System;

namespace SharpDox.TestProject
{
    /// <summary>
    /// Description of IInheritDoc.
    /// </summary>
    public interface IInheritDoc
    {
        /// <summary>
        /// Description of Method1
        /// </summary>
        void Method1();

        // 
        // var test = DocCommentId.GetDocCommentId(doxAssembly.AssemblyDefinition.Types.F
        // var test = MethodDefinition.Body?.Instructions.Select(i => i.Operand).OfType<MethodReference>();
    }

    public class InheritDoc : IInheritDoc
    {
        /// <inheritdoc />
        public void Method1()
        {
            throw new NotImplementedException();
        }
    }
}
