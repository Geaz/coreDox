using coreDox.Core.Model.Code.Base;
using coreDox.Core.Model.Code.Members;
using System;
using System.Collections.Generic;

namespace coreDox.Core.Model.Code
{
    public class DoxType : DoxCodeModel
    {
        public DoxType(Type type)
        {
            Type = type;
            Name = type.Name;
            FullName = type.FullName;
        }

        /// <summary>
        /// The reflection type for this code model type.
        /// </summary>
        public Type Type { get; }
    }
}
