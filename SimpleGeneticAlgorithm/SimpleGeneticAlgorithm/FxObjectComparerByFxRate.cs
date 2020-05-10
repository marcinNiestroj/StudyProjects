using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGeneticAlgorithm
{
    public class FxObjectComparerByFxRate : IComparer<FxObject>
    {
        public int Compare(FxObject x, FxObject y)
        {
            if (x.FxRate < y.FxRate)
            {
                return -1;
            }
            if (x.FxRate > y.FxRate)
            {
                return 1;
            }
            return 0;
        }
    }
}
