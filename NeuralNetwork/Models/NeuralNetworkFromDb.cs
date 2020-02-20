//using System;
//using System.Collections.Generic;
//using Neuron.Interface;
//using System.Linq;

//namespace Neuron.Models
//{
//    public class NeuralNetworkFromDb : INeuralNetworkFromDb
//    {
//        private readonly NeuronDbContext _neuronModelDb;

//        public NeuralNetworkFromDb(NeuronDbContext neuronModelDb)
//        {
//            _neuronModelDb = neuronModelDb;
//        }

//        public GetSmartNeuralNetwork Get(long id)
//        {
//            GetSmartNeuralNetwork output = new GetSmartNeuralNetwork();
//            output.SmartNeuron = new List<NeuronModel>();
//            output.Network = _neuronModelDb.NeuronNetworks.FirstOrDefault(u => u.Id == id);
//            List<NeuronModelDb> neuronModelDb = _neuronModelDb.Neurons.Where(
//                        u => u.NeuronNetworkId == id && u.InId == 0).ToList();
//            int countIn = _neuronModelDb.Neurons.Where(u => u.NeuronNetworkId == id && u.NeuronWeightId == 0).Count();
//            int countWeight = _neuronModelDb.Neurons.Where(u => u.NeuronNetworkId == id && u.InId == 0).Count();


//            for (var itemNeuron = 0; itemNeuron < countIn; itemNeuron++)
//            {
//                var neuron = new NeuronModel();
//                var weights = new List<WeightForNeuron>();
//                for (var itemWeight = 0; itemWeight < countWeight; itemWeight++)
//                {
//                    weights.Add(new WeightForNeuron()
//                    {
//                        Weights = _neuronModelDb.Neurons.FirstOrDefault(
//                            u => u.NeuronNetworkId == id && u.InId == itemNeuron && u.NeuronWeightId == itemWeight).Weight
//                    });
                    
//                }
//                neuron.Weights = weights;
//                output.SmartNeuron.Add(neuron);
//            }
//            return output;
//        }

//        public void CreateOrEdit(GetSmartNeuralNetwork input)
//        {
//            if(input.Network.Id == null)
//            {
//                Create(input);
//            }
//            else
//            {
//                Edit(input);
//            }

            
//        }

//        private void Create(GetSmartNeuralNetwork input)
//        {
//            _neuronModelDb.NeuronNetworks.Add(input.Network);
//            _neuronModelDb.SaveChanges();
//            for (var itemNeuron = 0; itemNeuron < input.SmartNeuron.Count; itemNeuron++)
//            {
//                for (var itemWeight = 0; itemWeight < input.SmartNeuron.Count; itemWeight++)
//                {
//                    _neuronModelDb.Neurons.Add(new NeuronModelDb()
//                    {
//                        NeuronNetworkId = (long)input.Network.Id,
//                        Weight = (double)input.SmartNeuron[itemNeuron].Weights[itemWeight].Weights,
//                        LayerId = 1,
//                        InId = itemNeuron,
//                        NeuronWeightId = itemWeight

//                    });
//                    _neuronModelDb.SaveChanges();
//                }
//            }
//        }
//        private void Edit(GetSmartNeuralNetwork input)
//        {

//        }
//    }
//}
