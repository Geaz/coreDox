// Took from: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/processing-the-xml-file

namespace coreDox.TestProject
{
    /// <summary>
    /// Class with to generics
    /// </summary>
    /// <typeparam name="T">Test T</typeparam>
    /// <typeparam name="V">Test V</typeparam>
    public class CodeIds<T, V>
    {
        public string Test { get; set; }
    }

    /// <summary>
    /// Enter description here for class CodeIds. 
    /// ID string generated is "T:coreDox.TestDataProject.CodeIds". 
    /// </summary>
    public unsafe class CodeIds
    {
        /// <summary>
        /// Enter description here for the first constructor.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.#ctor".
        /// </summary>
        public CodeIds() { }


        /// <summary>
        /// Enter description here for the second constructor.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.#ctor(System.Int32)".
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public CodeIds(int i) { }


        /// <summary>
        /// Enter description here for field q.
        /// ID string generated is "F:coreDox.TestDataProject.CodeIds.q".
        /// </summary>
        public string q;


        /// <summary>
        /// Enter description for constant PI.
        /// ID string generated is "F:coreDox.TestDataProject.CodeIds.PI".
        /// </summary>
        public const double PI = 3.14;


        /// <summary>
        /// Enter description for method f.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.f".
        /// </summary>
        /// <returns>Describe return value.</returns>
        public int f() { return 1; }


        /// <summary>
        /// Enter description for method bb.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.bb(System.String,System.Int32@,System.Void*)".
        /// </summary>
        /// <param name="s">Describe parameter.</param>
        /// <param name="y">Describe parameter.</param>
        /// <param name="z">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int bb(string s, ref int y, void* z) { return 1; }


        /// <summary>
        /// Enter description for method gg.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.gg(System.Int16[],System.Int32[0:,0:])". 
        /// </summary>
        /// <param name="array1">Describe parameter.</param>
        /// <param name="array">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public int gg(short[] array1, int[,] array) { return 0; }


        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.op_Addition(coreDox.TestDataProject.CodeIds,coreDox.TestDataProject.CodeIds)". 
        /// </summary>
        /// <param name="CodeIds">Describe parameter.</param>
        /// <param name="CodeIdsCodeIds">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static CodeIds operator +(CodeIds CodeIds, CodeIds CodeIdsCodeIds) { return CodeIds; }


        /// <summary>
        /// Enter description for property.
        /// ID string generated is "P:coreDox.TestDataProject.CodeIds.prop".
        /// </summary>
        public int prop { get { return 1; } set { } }


        /// <summary>
        /// Enter description for event.
        /// ID string generated is "E:coreDox.TestDataProject.CodeIds.d".
        /// </summary>
        public event D d;


        /// <summary>
        /// Enter description for property.
        /// ID string generated is "P:coreDox.TestDataProject.CodeIds.Item(System.String)".
        /// </summary>
        /// <param name="s">Describe parameter.</param>
        /// <returns></returns>
        public int this[string s] { get { return 1; } }


        /// <summary>
        /// Enter description for class Nested.
        /// ID string generated is "T:coreDox.TestDataProject.CodeIds.Nested".
        /// </summary>
        public class Nested { }


        /// <summary>
        /// Enter description for delegate.
        /// ID string generated is "T:coreDox.TestDataProject.CodeIds.D". 
        /// </summary>
        /// <param name="i">Describe parameter.</param>
        public delegate void D(int i);


        /// <summary>
        /// Enter description for operator.
        /// ID string generated is "M:coreDox.TestDataProject.CodeIds.op_ECodeIdsplicit(coreDox.TestDataProject.CodeIds)~System.Int32".
        /// </summary>
        /// <param name="CodeIds">Describe parameter.</param>
        /// <returns>Describe return value.</returns>
        public static explicit operator int(CodeIds CodeIds) { return 1; }
    }
}
