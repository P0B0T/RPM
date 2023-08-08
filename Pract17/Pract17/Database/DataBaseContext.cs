using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract17.Database
{
    public class DataBaseContext : DataBase
    {
        private static DataBaseContext context;

        public static DataBaseContext GetContext()
        {
            if (context == null) { context = new DataBaseContext(); }
            return context;
        }
    }
}
