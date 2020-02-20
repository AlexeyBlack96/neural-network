using System;
using System.Collections.Generic;
using Neuron.Models;

namespace NeuralBlack
{
    public interface INeuron
    {
        //
        // Summary:
        //   Get result for one neuron.
        NeuronModel Base(NeuronModel input);

        //
        // Summary:
        //   Get result for all neurons.
        List<NeuronModel> GetNeuronOut(List<NeuronModel> input);

        //
        // Summary:
        //   Get summary result all neuron.
        List<Perceptron> Go(List<Perceptron> input, double alpha);

        //
        // Summary:
        //   Get random weight.
        List<NeuronModel> GetRandomWeight(List<NeuronModel> neurons, int count);

        //
        // Summary:
        //   Get result for one neuron.
        List<Perceptron> SetInputs(List<Perceptron> neuron, List<double> ListIn);

        //
        // Summary:
        //   Get result for one neuron.
        NormalizationModel Normalization(List<TeachModel> teach);

        //
        // Summary:
        //   Get result for one neuron.
        List<double> NormalizationOne(List<double> input, double[,] normalization);

        //
        // Summary:
        //   Get result for one neuron.
        List<double> DeNormalization(List<double> input, double[,] normalization);

    }
}
