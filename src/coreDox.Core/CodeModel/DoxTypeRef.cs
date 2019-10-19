using Mono.Cecil;

namespace coreDox.Core.CodeModel
{
    public sealed class DoxTypeRef
    {
        public DoxTypeRef(TypeReference typeReference)
        {
            TypeReference = typeReference;
            if(typeReference is ArrayType arrayType)
            {
                IsArrayType = true;
                ArrayDimension = 1;

                var elementType = arrayType.ElementType;
                while (elementType is ArrayType)
                {
                    elementType = ((ArrayType)elementType).ElementType;
                    ArrayDimension++;
                }
            }
            else if(typeReference is PointerType)
            {
                IsPointerType = true;
            }
        }

        public bool IsPointerType { get; set; }
        public bool IsArrayType { get; set; }
        public int ArrayDimension { get; set; }

        public TypeReference TypeReference { get; set; }
    }
}
