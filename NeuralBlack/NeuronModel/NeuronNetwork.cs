using System.Collections.Generic;

namespace NeuralBlack
{
    public class NeuronNetwork
    {
        public List<Perceptron> Perceptrons { get; set; }
        public List<ErrorObject> Errors { get; set; }
    }
    public class ErrorObject
    {
        public List<double?> ErrorsInOne { get; set; }
    }
}
