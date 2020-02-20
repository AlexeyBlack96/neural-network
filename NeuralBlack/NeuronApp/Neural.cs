using System;
using System.Collections.Generic;
using System.Threading;
using NeuralBlack.Interface;

namespace NeuralBlack
{
    public class Neuron : INeuron
    {
        //private readonly NeuronDbContext _neuronModelDb;

        public Neuron()
        {
            //_neuronModelDb = neuronModelDb;
        }
        public NeuronModel Base(NeuronModel input)
        {
            for (var item = 0; item < input.Weights.Count; item++)
            {
                input.Weights[item].Out = input.Weights[item].Weights * input.In;
            }

            return input;
        }

        private double Sigmoid(ActivationFunction input)
        {
            var result = 1.0 / (1.0 + Math.Exp(-1.0 * input.Alpha * input.X));
            return result;
        }

        public List<NeuronModel> GetNeuronOut (List<NeuronModel> input)
        {
            List<NeuronModel> neuralOut = new List<NeuronModel>();
            for (var item = 0; item < input.Count; item++)
            {
                neuralOut.Add(Base(input[item]));
            }
            return neuralOut;
        }

        public List<Perceptron> Go(List<Perceptron> input, double alpha)
        {
            List<Perceptron> result = new List<Perceptron>();

            for (int itemPerceptron = 0; itemPerceptron < input.Count; itemPerceptron++)
            {
                List<NeuronModel> listNeuronOut = new List<NeuronModel>();
                input[itemPerceptron].Neurons = GetNeuronOut(input[itemPerceptron].Neurons);

                for (var itemNeuron = 0; itemNeuron < input[itemPerceptron].Neurons.Count; itemNeuron++)
                {
                    if (itemNeuron == 0)
                    {
                        listNeuronOut.Add(new NeuronModel()
                        {
                            In = input[itemPerceptron].Neurons[itemNeuron].In,
                            Weights = new List<WeightForNeuron>()
                        });
                    }
                    for (var itemWeight = 0; itemWeight < input[itemPerceptron].Neurons[itemNeuron].Weights.Count; itemWeight++)
                    {
                        if (itemNeuron == 0)
                        {
                            listNeuronOut[0].Weights.Add(new WeightForNeuron()
                            {
                                Weights = input[itemPerceptron].Neurons[itemNeuron].Weights[itemWeight].Weights,
                                Out = input[itemPerceptron].Neurons[itemNeuron].Weights[itemWeight].Out
                            });
                        }
                        else
                        {
                            listNeuronOut[0].Weights[itemWeight].Out += (double)input[itemPerceptron].Neurons[itemNeuron].Weights[itemWeight].Out;
                        }
                    }
                }
                for (var itemWeight = 0; itemWeight < listNeuronOut[0].Weights.Count; itemWeight++)
                {
                    listNeuronOut[0].Weights[itemWeight].Out = Sigmoid(new ActivationFunction()
                    {
                        Alpha = alpha,
                        X = (double)listNeuronOut[0].Weights[itemWeight].Out
                    });
                }
                for (var itemNeuron = 1; itemNeuron < input[itemPerceptron].Neurons.Count; itemNeuron++)
                {
                    listNeuronOut.Add(new NeuronModel()
                    {
                        In = input[itemPerceptron].Neurons[itemNeuron].In,
                        Weights = new List<WeightForNeuron>()
                    });
                    for (var itemWeight = 0; itemWeight < input[itemPerceptron].Neurons[itemNeuron].Weights.Count; itemWeight++)
                    {
                        listNeuronOut[itemNeuron].Weights.Add(new WeightForNeuron()
                        {
                            Out = listNeuronOut[0].Weights[itemWeight].Out,
                            Weights = input[itemPerceptron].Neurons[itemNeuron].Weights[itemWeight].Weights
                        });
                    }
                }
                result.Add(new Perceptron() { Neurons = listNeuronOut });
                if(input.Count - 1 != itemPerceptron){
                    for (var itemNeuron = 0; itemNeuron < input[itemPerceptron].Neurons.Count; itemNeuron++)
                    {
                        for (var itemWeight = 0; itemWeight < input[itemPerceptron].Neurons[itemNeuron].Weights.Count; itemWeight++)
                        {
                            input[itemPerceptron + 1].Neurons[itemWeight].In = listNeuronOut[itemNeuron].Weights[itemWeight].Out;
                        }
                    }
                }
            }
                
            return result;
        }

        public List<NeuronModel> GetRandomWeight(List<NeuronModel> neurons, int count)
        {
            for (var itemNeuron = 0; itemNeuron < neurons.Count; itemNeuron++)
            {
                for (var item = 0; item < count; item++)
                {
                    Random rand = new Random();
                    double temp;
                    temp = (rand.Next(10) - 5.0) / 10.0;
                    neurons[itemNeuron].Weights.Add(new WeightForNeuron()
                    {
                        Weights = temp
                    });
                }
            }
            return neurons;
        }

        public List<Perceptron> SetInputs(List<Perceptron> neuron, List<double> ListIn)
        {
            for(var itemNeuron = 0; itemNeuron < neuron[0].Neurons.Count; itemNeuron++)
            {
                neuron[0].Neurons[itemNeuron].In = ListIn[itemNeuron];
            }
            List<Perceptron> result = new List<Perceptron>();
            result = neuron;
            return result;
        }

        public NormalizationModel Normalization(List<TeachModel> teach){
            double[,] rangeIn = new double[teach[0].ListIn.Count, 2];
            double[,] rangeOut = new double[teach[0].ListIn.Count, 2];

            for (var itemTeach = 0; itemTeach < teach.Count; itemTeach++){
                for (var itemIn = 0; itemIn < teach[itemTeach].ListIn.Count; itemIn++)
                {
                    if(itemTeach == 0)
                    {
                        rangeIn[itemIn, 0] = teach[itemTeach].ListIn[itemIn];
                        rangeIn[itemIn, 1] = teach[itemTeach].ListIn[itemIn];
                    }
                    else
                    {
                        if(teach[itemTeach].ListIn[itemIn] < rangeIn[itemIn, 0])
                        {
                            rangeIn[itemIn, 0] = teach[itemTeach].ListIn[itemIn];
                        }
                        else if (teach[itemTeach].ListIn[itemIn] > rangeIn[itemIn, 1])
                        {
                            rangeIn[itemIn, 1] = teach[itemTeach].ListIn[itemIn];
                        }
                    }
                }
            }
            for (var itemTeach = 0; itemTeach < teach.Count; itemTeach++)
            {
                for (var itemIn = 0; itemIn < teach[itemTeach].ListOut.Count; itemIn++)
                {
                    if (itemTeach == 0)
                    {
                        rangeOut[itemIn, 0] = teach[itemTeach].ListOut[itemIn];
                        rangeOut[itemIn, 1] = teach[itemTeach].ListOut[itemIn];
                    }
                    else
                    {
                        if (teach[itemTeach].ListOut[itemIn] < rangeOut[itemIn, 0])
                        {
                            rangeOut[itemIn, 0] = teach[itemTeach].ListOut[itemIn];
                        }
                        else if (teach[itemTeach].ListOut[itemIn] > rangeOut[itemIn, 1])
                        {
                            rangeOut[itemIn, 1] = teach[itemTeach].ListOut[itemIn];
                        }
                    }
                }
            }
            for (var itemTeach = 0; itemTeach < teach.Count; itemTeach++)
            {
                for (var itemIn = 0; itemIn < teach[itemTeach].ListIn.Count; itemIn++)
                {
                    teach[itemTeach].ListIn[itemIn] = (teach[itemTeach].ListIn[itemIn] - rangeIn[itemIn, 0]) / (rangeIn[itemIn, 1] - rangeIn[itemIn, 0]);
                }
            }
            for (var itemTeach = 0; itemTeach < teach.Count; itemTeach++)
            {
                for (var itemIn = 0; itemIn < teach[itemTeach].ListOut.Count; itemIn++)
                {
                    teach[itemTeach].ListOut[itemIn] = (teach[itemTeach].ListOut[itemIn] - rangeOut[itemIn, 0]) / (rangeOut[itemIn, 1] - rangeOut[itemIn, 0]);
                }
            }
            return new NormalizationModel(){
                Teach = teach,
                RangeIn = rangeIn,
                RangeOut = rangeOut
            };
        }


        public List<double> NormalizationOne(List<double> input, double[,] normalization)
        {
            for (var item = 0; item < input.Count; item++)
            {
                input[item] = (input[item] - normalization[item, 0]) / (normalization[item, 1] - normalization[item, 0]);
            }
            return input;
        }
        public List<double> DeNormalization(List<double> input, double[,] normalization)
        {
            for (var item = 0; item < input.Count; item++)
            {
                input[item] = normalization[item, 0] + input[item] * (normalization[item, 1] - normalization[item, 0]);
            }
            return input;
        }




    }
}
