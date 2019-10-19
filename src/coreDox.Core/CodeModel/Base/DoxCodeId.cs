using Mono.Cecil;
using System.Linq;

namespace coreDox.Core.CodeModel.Base
{
    public static class DoxCodeId
    {
        public static string GetCodeId(EventDefinition eventDefinition)
        {
            return $"E:{GetCodeId(eventDefinition.DeclaringType, false)}.{eventDefinition.Name}";
        }

        public static string GetCodeId(FieldDefinition fieldDefinition)
        {
            return $"F:{GetCodeId(fieldDefinition.DeclaringType, false)}.{fieldDefinition.Name}";
        }

        public static string GetCodeId(PropertyDefinition propertyDefinition)
        {
            var parameterIdList = propertyDefinition.Parameters.Select(p => GetRefCodeId(p.ParameterType)).ToList();
            var parameters = parameterIdList.Count > 0
                ? $"({string.Join(",", parameterIdList)})"
                : string.Empty;
            return $"P:{GetCodeId(propertyDefinition.DeclaringType, false)}.{propertyDefinition.Name}{parameters}";
        }

        public static string GetCodeId(MethodDefinition methodDefinition)
        {
            var parameterIdList = methodDefinition.Parameters.Select(p => GetRefCodeId(p.ParameterType)).ToList();
            var parameters = parameterIdList.Count > 0
                ? $"({string.Join(",", parameterIdList)})"
                : string.Empty;
            var name = methodDefinition.IsConstructor
                ? methodDefinition.Name.Replace(".", "#")
                : methodDefinition.Name;
            return $"M:{GetCodeId(methodDefinition.DeclaringType, false)}.{name}{parameters}";
        }

        public static string GetCodeId(TypeDefinition typeDefinition, bool withPrefix = true)
        {
            return GetCodeId((TypeReference)typeDefinition, withPrefix);
        }

        public static string GetCodeId(TypeReference typeReference, bool withPrefix = true)
        {
            var prefix = withPrefix
                ? "T:"
                : string.Empty;
            return $"{prefix}{typeReference.Namespace}.{typeReference.Name}";
        }

        private static string GetRefCodeId(TypeReference typeReference)
        {
            var array = string.Empty;
            if(typeReference is ArrayType arrayType)
            {
                array = arrayType.Dimensions.Count > 1
                    ? $"[{string.Join(",", Enumerable.Repeat("0:", arrayType.Dimensions.Count))}]"
                    : "[]";
            }
            var pointer = typeReference.IsPointer
                ? "*"
                : string.Empty;
            var reference = typeReference.IsByReference
                ? "@"
                : string.Empty;

            return $"{typeReference.Namespace}.{typeReference.GetElementType().Name}{array}{pointer}{reference}";
        }
    }
}
