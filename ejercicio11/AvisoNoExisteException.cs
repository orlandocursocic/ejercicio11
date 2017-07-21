using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class AvisoNoExisteException : Exception
    {
        public AvisoNoExisteException()
        {
        }

        public AvisoNoExisteException(string message) : base(message)
        {
        }

        public AvisoNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AvisoNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}