using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
    public class FxObject
    {
        public int FxValue { get; set; }
        public double FxRate { get; set; }
        
        public FxObject(int fxValue, double fxRate)
        {
            this.FxValue = fxValue;
            this.FxRate = fxRate;
        }
    }
}
