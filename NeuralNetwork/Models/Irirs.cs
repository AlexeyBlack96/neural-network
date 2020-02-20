using System;
using System.Collections.Generic;
using System.IO;

namespace Neuron.Models
{
    public class Iris
    {
        public string ID { get; set; }
        public string SepalLengthCm { get; set; }
        public string SepalWidthCm { get; set; }
        public string PetalLengthCm { get; set; }
        public string PetalWidthCm { get; set; }
        public string Species { get; set; }


        public void Piece(string line)
        {
            string[] parts = line.Split(',');  //Разделитель в CVS файле.
            ID = parts[0];
            SepalLengthCm = parts[1];
            SepalWidthCm = parts[2];
            PetalLengthCm = parts[3];
            PetalWidthCm = parts[4];
            Species = parts[5];
        }

        public static List<Iris> ReadFile(string filename)
        {
            List<Iris> res = new List<Iris>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Iris p = new Iris();
                    p.Piece(line);
                    res.Add(p);
                }
            }
            return res;
        }
    }
}