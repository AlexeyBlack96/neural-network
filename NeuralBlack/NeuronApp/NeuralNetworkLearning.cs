using System;
using System.Collections.Generic;
using NeuralBlack.Interface;
using NeuralBlack.NeuronModelValidation;

namespace NeuralBlack
{
    public class NeuralNetworkLearning : INeuralNetworkLearning
    {
        private readonly INeuron _neuron;

        public NeuralNetworkLearning(INeuron neuron)
        {
            _neuron = neuron;
        }

        public List<Perceptron> TeachOnOne(List<Perceptron> perceptrons, List<double> trainOn, double sigma, double alpha = 1)
        {

            List<Perceptron> result = new List<Perceptron>();
            result = _neuron.Go(perceptrons, alpha);
            for (var i = 0; i < 3; i++)
            {
                List<double> errors1 = new List<double>();
                for (var itemPerceptron = result.Count - 1; itemPerceptron >= 0; itemPerceptron--)
                {
                    List<NeuronModel> smartNeurons = new List<NeuronModel>();
                    smartNeurons = result[itemPerceptron].Neurons;
                    List<double> errors2 = new List<double>();
                    for (var itemNeuron = 0; itemNeuron < smartNeurons.Count; itemNeuron++)
                    {
                        if (itemPerceptron == result.Count - 1)
                        {
                            List<double> errors0 = ErrorNeuron(smartNeurons[itemNeuron].Weights, trainOn);
                            errors1.Add((double)SumError(errors0, smartNeurons[itemNeuron].Weights));
                            smartNeurons[itemNeuron].Weights = BackPropagation(smartNeurons[itemNeuron], errors0, sigma, true);
                        }
                        else
                        {
                            errors2.Add((double)SumError(errors1, smartNeurons[itemNeuron].Weights));
                            smartNeurons[itemNeuron].Weights = BackPropagation(smartNeurons[itemNeuron], errors1, sigma, true);
                        }
                    }
                    if (errors2.Count > 0) errors1 = errors2;
                    result[itemPerceptron].Neurons = smartNeurons;
                }
                result = _neuron.Go(result, alpha);
            }
            return result;
        }

        private double? SumErrors(List<double?> errors)
        {
            double? result = 0;
            for (int i = 0; i < errors.Count; i++)
            {
                result += errors[i];
            }
            result = result / (double)errors.Count;
            return result;
        }

        private double? SumError(List<double> errors, List<WeightForNeuron> weights)
        {
            double? result = 0;
            for (var i = 0; i < errors.Count; i++)
            {
                result += errors[i] * weights[i].Weights;
            }
            return result;
        }

        public List<double> ErrorNeuron(List<WeightForNeuron> output, List<double> trainOn)
        {
            List<double> result = new List<double>();
            for (var item = 0; item < output.Count; item++)
            {
                result.Add((trainOn[item] - (double)output[item].Out) * (double)output[item].Out * (1.0 - (double)output[item].Out));
            }
            return result;
        }

        public List<WeightForNeuron> BackPropagation(NeuronModel input, List<double> error, double sigma, bool IsFinal)
        {
            List<WeightForNeuron> listNeuronWeight = new List<WeightForNeuron>();
            for (var item = 0; item < input.Weights.Count; item++)
            {
                if (IsFinal)
                {
                    listNeuronWeight.Add(new WeightForNeuron()
                    {
                        Weights = input.Weights[item].Weights + sigma * error[item] * input.In
                    });
                }
                else
                {
                    listNeuronWeight.Add(new WeightForNeuron()
                    {
                        Weights = input.Weights[item].Weights + sigma * error[item] * input.In * (1.0 - input.In)
                    });
                }

            }
            return listNeuronWeight;
        }







        public NeuronNetwork TeachingNeutal(LearningModule learning)
        {
            if (learning.Teach.Count > 200) 
            {
                throw new NeuronValidationException("Errroooor");
            }

            //if(multithreaded){
            //    Thread thread = new Thread(new ParameterizedThreadStart(MultithreadedTeachingNeutal));
            //    thread.Start(learning);
            //}
            NeuronNetwork output = new NeuronNetwork();
            List<NeuronModel> smartNeurons = new List<NeuronModel>();
            List<Perceptron> perceptrons = new List<Perceptron>();
            List<ErrorObject> Errors = new List<ErrorObject>();

            var iter = 0;
            if (learning.Cycle.HasValue)
            {
                while (iter != learning.Cycle)
                {
                    ErrorObject err = new ErrorObject();
                    err.ErrorsInOne = new List<double?>();

                    for (var itemTeach = 0; itemTeach < learning.Teach.Count; itemTeach++)
                    {
                        for (int layer = -1; layer < learning.HiddenLayer.Count; layer++)
                        {
                            if (layer == -1)
                            {
                                if (itemTeach == 0 && iter == 0)
                                {
                                    for (var itemTeachNeuron = 0; itemTeachNeuron < learning.Teach[itemTeach].ListIn.Count; itemTeachNeuron++)
                                    {
                                        smartNeurons.Add(new NeuronModel()
                                        {
                                            In = learning.Teach[itemTeach].ListIn[itemTeachNeuron],
                                            Weights = new List<WeightForNeuron>()
                                        });
                                    }
                                    if (learning.HiddenLayer.Count - 1 == layer)
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.Teach[itemTeach].ListOut.Count);
                                    }
                                    else
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.HiddenLayer[layer + 1]);
                                    }
                                    perceptrons.Add(new Perceptron()
                                    {
                                        Neurons = smartNeurons
                                    });
                                }
                                else
                                {
                                    for (var itemTeachNeuron = 0; itemTeachNeuron < learning.Teach[itemTeach].ListIn.Count; itemTeachNeuron++)
                                    {
                                        perceptrons[layer + 1].Neurons[itemTeachNeuron].In = learning.Teach[itemTeach].ListIn[itemTeachNeuron];
                                    }

                                }

                            }
                            else
                            {
                                if (itemTeach == 0 && iter == 0)
                                {
                                    smartNeurons = new List<NeuronModel>();
                                    for (var hiddenNeuron = 0; hiddenNeuron < learning.HiddenLayer[layer]; hiddenNeuron++)
                                    {
                                        smartNeurons.Add(new NeuronModel()
                                        {
                                            In = new double(),
                                            Weights = new List<WeightForNeuron>()
                                        });
                                    }
                                    if (learning.HiddenLayer.Count - 1 == layer)
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.Teach[itemTeach].ListOut.Count);
                                    }
                                    else
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.HiddenLayer[layer + 1]);
                                    }
                                    perceptrons.Add(new Perceptron()
                                    {
                                        Neurons = smartNeurons
                                    });
                                }
                            }
                        }
                        perceptrons = TeachOnOne(perceptrons, learning.Teach[itemTeach].ListOut, learning.Sigma, learning.Alpha);
                        err.ErrorsInOne.Add(ErrorNeurons(perceptrons, learning.Teach));
                    }
                    Errors.Add(err);
                    iter++;
                }
            }
            else
            {

                double? error1 = 0;

                while (true)
                {
                    ErrorObject err = new ErrorObject();
                    err.ErrorsInOne = new List<double?>();

                    for (var itemTeach = 0; itemTeach < learning.Teach.Count; itemTeach++)
                    {
                        for (int layer = -1; layer < learning.HiddenLayer.Count; layer++)
                        {
                            if (layer == -1)
                            {
                                if (itemTeach == 0 && iter == 0)
                                {
                                    for (var itemTeachNeuron = 0; itemTeachNeuron < learning.Teach[itemTeach].ListIn.Count; itemTeachNeuron++)
                                    {
                                        smartNeurons.Add(new NeuronModel()
                                        {
                                            In = learning.Teach[itemTeach].ListIn[itemTeachNeuron],
                                            Weights = new List<WeightForNeuron>()
                                        });
                                    }
                                    if (learning.HiddenLayer.Count - 1 == layer)
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.Teach[itemTeach].ListOut.Count);
                                    }
                                    else
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.HiddenLayer[layer + 1]);
                                    }
                                    perceptrons.Add(new Perceptron()
                                    {
                                        Neurons = smartNeurons
                                    });
                                }
                                else
                                {
                                    for (var itemTeachNeuron = 0; itemTeachNeuron < learning.Teach[itemTeach].ListIn.Count; itemTeachNeuron++)
                                    {
                                        perceptrons[layer + 1].Neurons[itemTeachNeuron].In = learning.Teach[itemTeach].ListIn[itemTeachNeuron];
                                    }

                                }

                            }
                            else
                            {
                                if (itemTeach == 0 && iter == 0)
                                {
                                    smartNeurons = new List<NeuronModel>();
                                    for (var hiddenNeuron = 0; hiddenNeuron < learning.HiddenLayer[layer]; hiddenNeuron++)
                                    {
                                        smartNeurons.Add(new NeuronModel()
                                        {
                                            In = new double(),
                                            Weights = new List<WeightForNeuron>()
                                        });
                                    }
                                    if (learning.HiddenLayer.Count - 1 == layer)
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.Teach[itemTeach].ListOut.Count);
                                    }
                                    else
                                    {
                                        smartNeurons = _neuron.GetRandomWeight(smartNeurons, learning.HiddenLayer[layer + 1]);
                                    }
                                    perceptrons.Add(new Perceptron()
                                    {
                                        Neurons = smartNeurons
                                    });
                                }
                            }
                        }
                        perceptrons = TeachOnOne(perceptrons, learning.Teach[itemTeach].ListOut, learning.Sigma, learning.Alpha);

                        err.ErrorsInOne.Add(ErrorNeurons(perceptrons, learning.Teach));
                    }
                    double? error2 = SumErrors(err.ErrorsInOne);
                    if (error2 - error1 < 0.001 && error2 - error1 > -0.001)
                    {
                        break;
                    }
                    error1 = error2;
                    Errors.Add(err);
                    iter++;
                }
            }

            output.Errors = Errors;
            output.Perceptrons = perceptrons;
            return output;
        }

        public double? ErrorNeurons(List<Perceptron> smartNeuron, List<TeachModel> teachModel)
        {
            ////Get error Neurons
            List<double?> error = new List<double?>();
            for (var itemTeach = 0; itemTeach < teachModel.Count; itemTeach++)
            {
                smartNeuron = _neuron.SetInputs(smartNeuron, teachModel[itemTeach].ListIn);
                smartNeuron = _neuron.Go(smartNeuron, 1);
                double? errorOnOne = 0;
                for (var itemError = 0; itemError < teachModel[itemTeach].ListOut.Count; itemError++)
                {
                    errorOnOne += Math.Pow((double)(smartNeuron[smartNeuron.Count - 1].Neurons[0].Weights[itemError].Out - teachModel[itemTeach].ListOut[itemError]), 2);
                }
                error.Add(errorOnOne);
            }
            double? errorOnSample = 0;
            for (var item = 0; item < error.Count; item++)
            {
                errorOnSample += error[item];
            }
            errorOnSample = Math.Sqrt((double)(errorOnSample / error.Count));
            return errorOnSample;
        }

    }
}
