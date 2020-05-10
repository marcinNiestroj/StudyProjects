﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
    public class RatingObject
    {
        public int FxValue { get; set; }
        public double FxRate { get; set; }
        public double SubjectRating { get; set; }

        public RatingObject(int fxValue, double fxRate, double subcjectRating)
        {
            this.FxValue = fxValue;
            this.FxRate = fxRate;
            this.SubjectRating = subcjectRating;
        }
    }
}