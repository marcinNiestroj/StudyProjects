using System;
using System.Collections.Generic;

namespace SimpleGeneticAlgorithm
{
    public class Roulette
    {
        private Random random = new Random();

        public List<RatingObject> CreateFxRatingList(List<FxObject> fxValuesList)
        {
            List<RatingObject> ratingObjects = new List<RatingObject>();

            double fxRateSum = GetFxRateSum(fxValuesList);

            foreach (FxObject fxObject in fxValuesList)
            {
                double fxRating = fxObject.FxRate / fxRateSum;
                ratingObjects.Add(new RatingObject(fxObject.FxValue, fxObject.FxRate, fxRating));
            }

            return ratingObjects;
        }

        public List<FxObject> GetRandomSubjectsList(List<RatingObject> ratingObjects)
        {
            List<FxObject> finalSubjects = new List<FxObject>();

            double sectionRangeMin = 0;
            double sectionRangeMax = ratingObjects[0].SubjectRating;
            int i = 0;
            int listLength = ratingObjects.Count - 1;
            bool isAssign;
            double randomValue;

            do
            {
                isAssign = false;
                randomValue = random.NextDouble();

                do
                {
                    if (randomValue > sectionRangeMin && randomValue <= sectionRangeMax)
                    {
                        finalSubjects.Add(new FxObject(ratingObjects[i].FxValue, ratingObjects[i].FxRate));
                        isAssign = true;
                    }

                    sectionRangeMin += ratingObjects[i].SubjectRating; 
                    i++;

                    if (i >= listLength)
                    {
                        i = 0;
                        sectionRangeMin = 0;
                        sectionRangeMax = ratingObjects[0].SubjectRating;
                        isAssign = true;
                    }
                    else
                    {
                        sectionRangeMax += ratingObjects[i].SubjectRating;
                    }
                    

                } while (isAssign == false);

            } while (finalSubjects.Count <= listLength);

            return finalSubjects;
        }

        private double GetFxRateSum(List<FxObject> fxValuesList)
        {
            double fxRateSum = 0;

            foreach (FxObject fxValue in fxValuesList)
            {
                fxRateSum += fxValue.FxRate;
            }

            return fxRateSum;
        }
    }
}