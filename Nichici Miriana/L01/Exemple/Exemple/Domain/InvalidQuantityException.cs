using System;
using System.Runtime.Serialization;

namespace Exemple.Domain
{
    [Serializable]
    internal class InvalidquantityException : Exception
    {
        public InvalidquantityException()
        {
        }

        public InvalidquantityException(string? message) : base(message)
        {
        }

        public InvalidquantityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidquantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}