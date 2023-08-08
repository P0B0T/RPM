using Practos_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__7
{
    internal class RightAngled : Pair
    {
        double _onecathet;
        double _twocathet;

        public double Onecathet
        {
            get => _onecathet;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Свойство должно быть больше или равно 0");
                }
                _onecathet = value;
            }
        }

        public double Twocathet
        {
            get => _twocathet;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Свойство должно быть больше или равно 0");
                }
                _twocathet = value;
            }
        }

        public RightAngled(int oneValue, int twoValue) : base (oneValue, twoValue)
        {
            Onecathet = oneValue;
            Twocathet = twoValue;
        }

        public double Hypothesis(RightAngled triangle)
        {
            return Math.Sqrt(Math.Pow(triangle.Onecathet, 2) + Math.Pow(triangle.Twocathet, 2));
        }

        public double Area(RightAngled triangle)
        {
            return (triangle.Onecathet * triangle.Twocathet) / 2;
        }
    }
}
