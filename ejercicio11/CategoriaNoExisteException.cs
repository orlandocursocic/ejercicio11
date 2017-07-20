using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class CategoriaNoExisteException : Exception
    {
        public CategoriaNoExisteException()
        {
        }

        public CategoriaNoExisteException(string message) : base(message)
        {
        }

        public CategoriaNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CategoriaNoExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}