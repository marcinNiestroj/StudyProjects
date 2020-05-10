using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeneticAlgorithm
{
    public class Crossing
    {
        private Random random = new Random();

        public Crossing()
        {
        }

        public List<StringBuilder> CrossingSubjects(List<StringBuilder> subjectsToCross, double crossRate)
        {
            List<StringBuilder> crossedSubcjects = new List<StringBuilder>();

            do
            {
                double isCrossing = random.NextDouble();

                if (isCrossing <= crossRate)
                {
                    int cutPoint = random.Next(6 + 1);
                    int index = subjectsToCross.Count - 1;

                    StringBuilder firstSubject = subjectsToCross[index];
                    StringBuilder secondSubject = subjectsToCross[index - 1];

                    string temp1 = firstSubject.ToString().Substring(0, cutPoint);
                    string temp2 = secondSubject.ToString().Substring(cutPoint, 8 - cutPoint);
                    string temp3 = secondSubject.ToString().Substring(0, cutPoint);
                    string temp4 = firstSubject.ToString().Substring(cutPoint, 8 - cutPoint);

                    StringBuilder firstCrossedSubcject = new StringBuilder(temp1 + temp2);
                    StringBuilder secondCrossedSubject = new StringBuilder(temp3 + temp4);

                    crossedSubcjects.Add(firstCrossedSubcject);
                    crossedSubcjects.Add(secondCrossedSubject);
                    subjectsToCross.RemoveAt(index);
                    subjectsToCross.RemoveAt(index - 1);
                }
                else
                {
                    int index = subjectsToCross.Count - 1;

                    crossedSubcjects.Add(subjectsToCross[index]);
                    crossedSubcjects.Add(subjectsToCross[index - 1]);

                    subjectsToCross.RemoveAt(index);
                    subjectsToCross.RemoveAt(index - 1);
                }

            } while (subjectsToCross.Count > 0);

            return crossedSubcjects;
        }
    }
}