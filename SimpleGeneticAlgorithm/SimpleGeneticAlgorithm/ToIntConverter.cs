using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeneticAlgorithm
{
    public class ToIntConverter
    {
        public List<int> ConvertByteToItn(List<StringBuilder> nextPopulationInByte)
        {
            List<int> nextPopulationInInt = new List<int>();

            foreach (StringBuilder byteValue in nextPopulationInByte)
            {
                nextPopulationInInt.Add(Convert.ToInt32(Convert.ToByte(byteValue.ToString(), 2)));
            }

            return nextPopulationInInt;
        }
    }
}