using System;
using System.Collections.Generic;

namespace NeuralBlack
{
    public class LearningModule
    {
        public List<TeachModel> Teach { get; set; }
        public List<int> HiddenLayer { get; set; } = new List<int>();
        public int? Cycle { get; set; } = null;
        public double Sigma { get; set; } = 0.5;
        public double Alpha { get; set; } = 1;
    }
}
//TeachModel teach, List<int> hide, int? cycle, double sigma = 0.5, double alpha = 1