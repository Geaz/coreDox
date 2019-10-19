using Mono.Cecil;

namespace coreDox.Core.CodeModel.Base
{
    public static class DoxCodeId
    {
        public static string GetCodeId(EventDefinition eventDefinition)
        {
            return $"E:{GetCodeId(eventDefinition.DeclaringType)}.{eventDefinition.Name}";
        }

        public static string GetCodeId(FieldDefinition fieldDefinition)
        {
            return $"F:{GetCodeId(fieldDefinition.DeclaringType)}.{fieldDefinition.Name}";
        }

        public static string GetCodeId(PropertyDefinition propertyDefinition)
        {

            return $"P:{GetCodeId(propertyDefinition.DeclaringType)}.{propertyDefinition.Name}";
        }

        public static string GetCodeId(MethodDefinition methodDefinition)
        {
            return $"M:{GetCodeId(methodDefinition.DeclaringType)}.{methodDefinition.Name}";
        }

        public static string GetCodeId(TypeReference typeReference)
        {
            var typeDefinition = typeReference.Resolve();
            return typeDefinition != null
                ? GetCodeId(typeDefinition)
                : string.Empty;
        }

        public static string GetCodeId(TypeDefinition typeDefinition)
        {
            return $"T:{typeDefinition.Namespace}.{typeDefinition.Name}";
        }
    }
}
