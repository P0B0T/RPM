using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practos_5
{
    internal class Pair
    {
        public Pair(int oneValue, int twoValue)
        {
            OneValue = oneValue;
            TwoValue = twoValue;
        }

        public int OneValue { get; set; }

        public int TwoValue { get; set; }
    }
}