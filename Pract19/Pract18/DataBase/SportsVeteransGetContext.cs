using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract18.DataBase
{
    public class SportsVeteransGetContext : SportsVeteransContext
    {
        private static SportsVeteransGetContext context;

        public static SportsVeteransGetContext GetContext()
        {
            if (context == null) { context = new SportsVeteransGetContext(); }
            return context;
        }
    }
}
