using System;
using System.Collections.Generic;
using Neuron.Models;

namespace NeuralBlack
{
    public interface INeuralNetworkLearning
    {

        //
        // Summary:
        //   Edit weight all neurons with help backpropagation a error
        List<WeightForNeuron> BackPropagation(NeuronModel input, List<double> error, double sigma, bool IsFinal);

        //
        // Summary:
        //   Get result for one neuron.
        NeuronNetwork TeachingNeutal(LearningModule learning);


    }
}
