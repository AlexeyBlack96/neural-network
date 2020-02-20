using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeuralBlack;
using NeuralLibrary.App;
using NeuralLibrary.Interfaces;
using NeuralLibrary.Models;
using Neuron.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Neuron.Controllers
{
    public class NeuronController : Controller
    {
        private readonly INeuron _neural;
        private readonly INeuralNetworkLearning _neuralNetworkLearning;

        public NeuronController(INeuron neural, INeuralNetworkLearning neuralNetworkLearning)
        {
            _neural = neural;
            _neuralNetworkLearning = neuralNetworkLearning;
        }
        public NeuronNetwork Get()
        {
            DateTime time = DateTime.Now;
            string txtIris = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/iris.csv";
            List<Iris> iris = Iris.ReadFile(txtIris);
            Random rand = new Random();
            for (int i = iris.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = iris[j];
                iris[j] = iris[i];
                iris[i] = temp;
            }

            List<List<double>> input = new List<List<double>>();
            List<TeachModel> teach = new List<TeachModel>();
            for (var i = 0; i < iris.Count; i++)
            {
                if(i % 10 != 0)
                {

                    if (iris[i].Species == "Iris-setosa")
                    {
                        teach.Add(new TeachModel()
                        {
                            ListIn = new List<double>()
                        {
                        Convert.ToDouble(iris[i].PetalLengthCm),
                        Convert.ToDouble(iris[i].PetalWidthCm),
                        Convert.ToDouble(iris[i].SepalLengthCm),
                        Convert.ToDouble(iris[i].SepalWidthCm)
                        },
                            ListOut = new List<double>() { 1, 0, 0 }
                        });
                    }
                    else if(iris[i].Species == "Iris-versicolor")
                    {
                        teach.Add(new TeachModel()
                        {
                            ListIn = new List<double>()
                        {
                        Convert.ToDouble(iris[i].PetalLengthCm),
                        Convert.ToDouble(iris[i].PetalWidthCm),
                        Convert.ToDouble(iris[i].SepalLengthCm),
                        Convert.ToDouble(iris[i].SepalWidthCm)
                        },
                            ListOut = new List<double>() { 0, 1, 0 }
                        });
                    }
                    else
                    {
                        teach.Add(new TeachModel()
                        {
                            ListIn = new List<double>()
                        {
                        Convert.ToDouble(iris[i].PetalLengthCm),
                        Convert.ToDouble(iris[i].PetalWidthCm),
                        Convert.ToDouble(iris[i].SepalLengthCm),
                        Convert.ToDouble(iris[i].SepalWidthCm)
                        },
                            ListOut = new List<double>() { 0, 0, 1 }
                        });
                    }
                }

            }
            NormalizationModel normTeachModel = _neural.Normalization(teach);

            var perceptronView = new NeuronNetwork();
            double? error = 1;
            //while (error > 0.7)
            //{
            perceptronView = _neuralNetworkLearning.TeachingNeutal( new LearningModule()
            {
                Teach = normTeachModel.Teach,
                HiddenLayer = new List<int>() { 50 }
            });
            DateTime time1 = DateTime.Now;

            //error = _neural.ErrorNeurons(smartNeuron.Neuron, teachModel);
            //}
            List<List<Perceptron>> result = new List<List<Perceptron>>();
            for (var i = 0; i < iris.Count; i++)
            {
                if (i % 10 == 0)
                {
                    result.Add(
                        _neural.Go(
                            _neural.SetInputs(
                                perceptronView.Perceptrons, _neural.NormalizationOne(new List<double>()
                                {
                                    Convert.ToDouble(iris[i].PetalLengthCm),
                                    Convert.ToDouble(iris[i].PetalWidthCm),
                                    Convert.ToDouble(iris[i].SepalLengthCm),
                                    Convert.ToDouble(iris[i].SepalWidthCm)
                                }, normTeachModel.RangeIn)
                            ), 1
                        )
                    );
                }
            }
            perceptronView.Perceptrons = _neural.SetInputs(perceptronView.Perceptrons, 
                                                           _neural.NormalizationOne(new List<double>() { 
                Convert.ToDouble(iris[1].PetalLengthCm), 
                Convert.ToDouble(iris[1].PetalWidthCm), 
                Convert.ToDouble(iris[1].SepalLengthCm), 
                Convert.ToDouble(iris[1].SepalWidthCm) }, normTeachModel.RangeIn) );
            perceptronView.Perceptrons = _neural.Go(perceptronView.Perceptrons, 1);
            return perceptronView;
        }




        public NeuronNetwork Getget()
        {
            DateTime time = DateTime.Now;
            string txtIris = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/iris.csv";
            List<Iris> iris2 = Iris.ReadFile(txtIris);
            List<Iris> iris = new List<Iris>();
            for(var i = 0; i < 100; i++)
            {
                iris.Add(iris2[i]);
            }
            Random rand = new Random();
            for (int i = iris.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = iris[j];
                iris[j] = iris[i];
                iris[i] = temp;
            }

            List<List<double>> input = new List<List<double>>();
            List<TeachModel> teach = new List<TeachModel>();
            for (var i = 0; i < iris.Count; i++)
            {
                if (i % 10 != 0)
                {

                    if (iris[i].Species == "Iris-setosa")
                    {
                        teach.Add(new TeachModel()
                        {
                            ListIn = new List<double>()
                        {
                        Convert.ToDouble(iris[i].PetalLengthCm),
                        Convert.ToDouble(iris[i].PetalWidthCm),
                        Convert.ToDouble(iris[i].SepalLengthCm),
                        Convert.ToDouble(iris[i].SepalWidthCm)
                        },
                            ListOut = new List<double>() { 1, 0}
                        });
                    }
                    else if (iris[i].Species == "Iris-versicolor")
                    {
                        teach.Add(new TeachModel()
                        {
                            ListIn = new List<double>()
                        {
                        Convert.ToDouble(iris[i].PetalLengthCm),
                        Convert.ToDouble(iris[i].PetalWidthCm),
                        Convert.ToDouble(iris[i].SepalLengthCm),
                        Convert.ToDouble(iris[i].SepalWidthCm)
                        },
                            ListOut = new List<double>() { 0, 1 }
                        });
                    }

                }

            }
            NormalizationModel normTeachModel = _neural.Normalization(teach);

            var perceptronView = new NeuronNetwork();
            double? error = 1;
            //while (error > 0.7)
            //{
            perceptronView = _neuralNetworkLearning.TeachingNeutal(new LearningModule()
            {
                Teach = normTeachModel.Teach,
                HiddenLayer = new List<int>() { 300 }

            });
            DateTime time1 = DateTime.Now;

            //error = _neural.ErrorNeurons(smartNeuron.Neuron, teachModel);
            //}
            List<List<Perceptron>> result = new List<List<Perceptron>>();
            for (var i = 0; i < iris.Count; i++)
            {
                if (i % 10 == 0)
                {
                    result.Add(
                        _neural.Go(
                            _neural.SetInputs(
                                perceptronView.Perceptrons, _neural.NormalizationOne(new List<double>()
                                {
                                    Convert.ToDouble(iris[i].PetalLengthCm),
                                    Convert.ToDouble(iris[i].PetalWidthCm),
                                    Convert.ToDouble(iris[i].SepalLengthCm),
                                    Convert.ToDouble(iris[i].SepalWidthCm)
                                }, normTeachModel.RangeIn)
                            ), 1
                        )
                    );
                }
            }
            perceptronView.Perceptrons = _neural.SetInputs(perceptronView.Perceptrons,
                                                           _neural.NormalizationOne(new List<double>() {
                Convert.ToDouble(iris[1].PetalLengthCm),
                Convert.ToDouble(iris[1].PetalWidthCm),
                Convert.ToDouble(iris[1].SepalLengthCm),
                Convert.ToDouble(iris[1].SepalWidthCm) }, normTeachModel.RangeIn));
            perceptronView.Perceptrons = _neural.Go(perceptronView.Perceptrons, 1);
            return perceptronView;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
