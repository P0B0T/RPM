using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая__9
{
    struct BaggageInformation
    {
        int _numbers_of_items;
        double _weight_in_kilograms;

        public int Numbers_of_items
        {
            get => _numbers_of_items;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Свойство не может быть отрицательным");
                }
                _numbers_of_items = value;
            }
        }

        public double Weight_in_kilograms
        {
            get => _weight_in_kilograms;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Свойство не может быть отрицательным");
                }
                _weight_in_kilograms = value;
            }
        }

        public BaggageInformation(int numbers_of_items, double weight_in_kilograms)
        {
            Numbers_of_items = numbers_of_items;
            Weight_in_kilograms = weight_in_kilograms;
        }
    }
}
