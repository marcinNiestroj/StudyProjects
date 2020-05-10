using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
    public class RatingObjectComparerByRating : IComparer<RatingObject>
    {
        public int Compare(RatingObject x, RatingObject y)
        {
            if (x.SubjectRating < y.SubjectRating)
            {
                return -1;
            }
            if (x.SubjectRating > y.SubjectRating)
            {
                return 1;
            }
            return 0;
        }
    }
}
