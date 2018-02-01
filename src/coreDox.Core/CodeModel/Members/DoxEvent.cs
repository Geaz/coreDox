using System.Reflection;
using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxEvent : DoxCodeModel
    {
        public DoxEvent(EventInfo eventInfo)
        {
            EventInfo = eventInfo;
            Name = eventInfo.Name;
            FullName = $"{eventInfo.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="EventInfo"/> for this code model event.
        /// </summary>
        public EventInfo EventInfo { get; }
    }
}
