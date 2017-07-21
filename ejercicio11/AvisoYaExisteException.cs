using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class AvisoYaExisteException : Exception
    {
        public AvisoYaExisteException()
        {
        }

        public AvisoYaExisteException(string message) : base(message)
        {
        }

        public AvisoYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AvisoYaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}