using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class RecetaNoExisteException : Exception
    {
        public RecetaNoExisteException()
        {
        }

        public RecetaNoExisteException(string message) : base(message)
        {
        }

        public RecetaNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecetaNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}