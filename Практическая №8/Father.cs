using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практичекая__8
{
    internal class Father : Iprint
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public Father(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Print()
        {
            return Name;
        }
    }
}
