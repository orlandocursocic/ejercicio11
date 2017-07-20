using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class CategoriaYaExisteException : Exception
    {
        public CategoriaYaExisteException()
        {
        }

        public CategoriaYaExisteException(string message) : base(message)
        {
        }

        public CategoriaYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CategoriaYaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}