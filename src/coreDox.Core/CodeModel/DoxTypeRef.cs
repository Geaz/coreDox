using Mono.Cecil;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxTypeRef
    {
        public DoxTypeRef(TypeReference typeReference)
        {
            TypeFullname = typeReference.FullName;
            if(typeReference is ArrayType arrayType)
            {
                IsArrayType = true;
                ArrayDimension = 1;

                var elementType = arrayType.ElementType;
                while (elementType is ArrayType)
                {
                    elementType = ((ArrayType)elementType).ElementType;

                    // We want to set the fullname to the base type of the array type
                    TypeFullname = elementType.FullName;
                    ArrayDimension++;
                }
            }
            else if(typeReference is PointerType)
            {
                IsPointerType = true;
            }
        }

        public string TypeFullname { get; set; }
        public bool IsPointerType { get; set; }
        public bool IsArrayType { get; set; }
        public int ArrayDimension { get; set; }
    }
}
