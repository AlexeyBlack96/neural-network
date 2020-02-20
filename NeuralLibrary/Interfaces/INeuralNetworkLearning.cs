using System;
using System.Collections.Generic;
using NeuralLibrary.Models;

namespace NeuralLibrary.Interfaces
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
