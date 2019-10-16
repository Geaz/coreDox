using System;

namespace coreDox.Core.Exceptions
{
    public class CoreDoxException : Exception
    {
        public CoreDoxException() { }
        public CoreDoxException(string message) : base(message) { }
        public CoreDoxException(string message, Exception innerException) : base(message, innerException) { }
    }
}
