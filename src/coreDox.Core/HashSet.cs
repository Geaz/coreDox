using coreDox.Core.Model.Code.Base;
using System.Collections.Generic;

namespace coreDox.Core.Model
{
    public static class HashSet
    {
        /// <summary>
        /// A static helper for <see cref="HashSet{T}"/>s of the type <see cref="DoxCodeModel"/>.
        /// This helper tries to add a <see cref="DoxCodeModel"/> or returns the exisiting one, if already added.
        /// </summary>
        /// <typeparam name="T">The type to test against.</typeparam>
        /// <param name="hashSet">The <see cref="HashSet{T}"/> to test.</param> 
        /// <param name="doxCodeModel">The <see cref="DoxCodeModel"/> to test.</param>
        /// <returns>The added or existing <see cref="DoxCodeModel"/>.</returns>
        public static T GetOrAdd<T>(this HashSet<T> hashSet, T doxCodeModel) where T : DoxCodeModel
        {
            var returnDoxCodeModel = doxCodeModel;
            if (!hashSet.Add(doxCodeModel))
            {
                hashSet.TryGetValue(doxCodeModel, out returnDoxCodeModel);
            }
            return returnDoxCodeModel;
        }
    }
}
