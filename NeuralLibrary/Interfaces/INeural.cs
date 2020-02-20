using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeuralLibrary.Models;

namespace NeuralLibrary.Interfaces
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


        Task<ErrorViewModel> CreateNewNetwork(AuthorizationToken token, TeachModel csv);

        Task<object> GoOnOne(AuthorizationToken token, string log);

        Task<object> GoOnSeveralLogs(AuthorizationToken token, string csv);

        Task<object> GoOnSeveralLogs(AuthorizationToken token, bool fromDb);

        Task<NeuronNetwork> GetNeuralNetwork(AuthorizationToken token);

        Task<NeuronNetwork> ReTeach(AuthorizationToken token);

        Task<TeachModel> CreateNewTeachModel(AuthorizationToken token, object csv);

        Task<ErrorViewModel> CreateNewAuthorizationToken(AuthorizationToken token);

        Task<ErrorViewModel> DeleteNeuronNetwork(AuthorizationToken token);




    }
}
