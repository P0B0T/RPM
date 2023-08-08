using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practos_5
{
    internal class Pair
    {
        private int _oneValue;
        private int _twoValue;

        public Pair(int oneValue, int twoValue)
        {
            OneValue = oneValue;
            TwoValue = twoValue;
        }

        public int OneValue
        {
            get => _oneValue;
            set
            {
                if (value % 2 != 0)
                {
                    throw new ArgumentException("Свойство должно четным");
                }

                _oneValue = value;
            }
        }

        public int TwoValue
        {
            get => _twoValue;
            set
            {
                if (value % 2 != 0)
                {
                    throw new ArgumentException("Свойство должно четным");
                }

                _twoValue = value;
            }
        }

        public Pair Multiplication(Pair FirstPair)
        {
            return new Pair(OneValue * FirstPair.OneValue, TwoValue * FirstPair.TwoValue);
        }

        public static Pair operator ++(Pair FirstPair)
        {
            return new Pair(2 * FirstPair.OneValue, 2 * FirstPair.TwoValue);
        }
    }
}