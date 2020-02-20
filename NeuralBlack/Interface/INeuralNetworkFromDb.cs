using System;
using Neuron.Models;

namespace NeuralBlack
{
    public interface INeuralNetworkFromDb
    {
        GetSmartNeuralNetwork Get(long id);
        void CreateOrEdit(GetSmartNeuralNetwork input);
    }
}
