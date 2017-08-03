using System.Reflection;
using coreDox.Core.Model.Code.Base;

namespace coreDox.Core.Model.Code.Members
{
    public class DoxEvent : DoxCodeModel
    {
        public DoxEvent(EventInfo @event)
        {
            Event = @event;
            Name = @event.Name;
            FullName = $"{@event.DeclaringType.FullName}.{Name}";
        }

        /// <summary>
        /// The reflection <see cref="EventInfo"/> for this code model event.
        /// </summary>
        public EventInfo Event { get; }
    }
}
