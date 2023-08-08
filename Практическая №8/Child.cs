using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практичекая__8
{
    internal class Child : Father, Iprint, IComparable, ICloneable
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public Child(string name, string surname, string patronymic) : base (name, surname)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }

        public string Print()
        {
            return $"{Name} {Patronymic}";
        }

        public int CompareTo(object ob)
        {
            Child son = (Child)ob;
            if (Surname == son.Surname) return 1;
            if (Surname != son.Surname) return -1;
            return 0;
        }

        public object Clone()
        {
            return new Child(Name, Surname, Patronymic);
        }
    }
}
