using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleGeneticAlgorithm
{
    public class SqareFunction
    {

        public List<FxObject> CreateFxValuesList(List<int> nextpopulationIntValues, List<int> fxValues)
        {
            List<FxObject> fxObjects = new List<FxObject>();
            int listLength = nextpopulationIntValues.Count;
            double fxRate;
            int a = fxValues[0];
            int b = fxValues[1];
            int c = fxValues[2];
            int x;

            for (int i = 0; i < listLength; i++)
            {
                x = nextpopulationIntValues[i];
                fxRate = (a * Math.Pow(Convert.ToDouble(x), 2)) + (b * x) + c;
                fxObjects.Add(new FxObject(nextpopulationIntValues[i], fxRate));
            }

            return fxObjects;
        }
    }
}