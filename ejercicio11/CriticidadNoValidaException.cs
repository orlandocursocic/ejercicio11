using System;
using System.Runtime.Serialization;

namespace ejercicio11
{
    [Serializable]
    public class CriticidadNoValidaException : Exception
    {
        public CriticidadNoValidaException()
        {
        }

        public CriticidadNoValidaException(string message) : base(message)
        {
        }

        public CriticidadNoValidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CriticidadNoValidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}