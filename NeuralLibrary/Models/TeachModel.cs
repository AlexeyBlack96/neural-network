using System;
using System.Collections.Generic;

namespace NeuralLibrary.Models
{
    public class TeachModel
    {
        public List<double> ListIn { get; set; }
        public List<double> ListOut { get; set; }
    }
    public class NormalizationModel
    {
        public List<TeachModel> Teach { get; set; }
        public double[,] RangeIn { get; set; }
        public double[,] RangeOut { get; set; }
    }
}
