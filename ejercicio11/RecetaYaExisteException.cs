using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class RecetaYaExisteException : Exception
    {
        public RecetaYaExisteException()
        {
        }

        public RecetaYaExisteException(string message) : base(message)
        {
        }

        public RecetaYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecetaYaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}