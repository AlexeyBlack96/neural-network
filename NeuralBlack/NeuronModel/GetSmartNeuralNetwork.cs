using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace NeuralBlack
{
    public class GetSmartNeuralNetwork
    {
        public List<NeuronModel> SmartNeuron { get; set; }
        public NeuronNetworkDb Network { get; set; }
    }
}

