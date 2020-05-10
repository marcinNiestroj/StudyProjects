using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeneticAlgorithm
{
    public class Mutation
    {
        private Random random = new Random();
        public List<StringBuilder> Mutating(List<StringBuilder> nextPopulationInByte, double mutationRate)
        {
            foreach (StringBuilder byteValue in nextPopulationInByte)
            {
                for (int i = 0; i < byteValue.Length; i++)
                {
                    double isMutating = random.NextDouble();

                    if (isMutating <= mutationRate)
                    {
                        char currentByte = byteValue[i];

                        if (currentByte.Equals('0'))
                        {
                            currentByte = '1';
                        }
                        else
                        {
                            currentByte = '0';
                        }

                        byteValue[i] = currentByte;
                    }
                }
            }
            return nextPopulationInByte;
        }
    }
}