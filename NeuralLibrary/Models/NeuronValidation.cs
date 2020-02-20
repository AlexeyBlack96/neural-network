using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuralLibrary.Models
{
    public class NeuronValidationException : ApplicationException
    {
        public NeuronValidationException() { }
        public NeuronValidationException(string message) : base(message) { }
        public NeuronValidationException(string message, Exception inner) : base(message, inner) { }
        protected NeuronValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
