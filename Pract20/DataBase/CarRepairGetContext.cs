using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract20.DataBase
{
    public class CarRepairGetContext : CarRepairContext
    {
        static CarRepairGetContext context;

        public static CarRepairGetContext GetContext()
        {
            if (context == null) { context = new CarRepairGetContext(); }
            return context;
        }   
    }
}
