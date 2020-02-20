using System;
using System.Collections.Generic;

namespace NeuralLibrary.Models
{
    public class Perceptron
    {
        public List<NeuronModel> Neurons { get; set; }
    }
    public class NeuronModel
    {
        public double? In { get; set; }
        public List<WeightForNeuron> Weights { get; set; }
    }
    public class WeightForNeuron
    {
        public double? Weights { get; set; }
        public double? Out { get; set; }
    }

    public class NewWeightModel
    {
        public List<WeightForNeuron> WeightForNeuron { get; set; }
    }

    public class NeuronModelDb
    {
        public long Id { get; set; }
        public long NeuronNetworkId { get; set; }
        public double Weight { get; set; }
        public long LayerId { get; set; }
        public long InId { get; set; }
        public long NeuronWeightId { get; set; }

    }
    public class NeuronNetworkDb
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class HiddenLayers
    {
        public List<double> Layer { get; set; }
    }
}
