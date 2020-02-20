using System;
using System.Collections.Generic;

namespace NeuralLibrary.Models
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
