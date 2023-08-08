using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract22.Database
{
    public class ИнформацияОСтранахGetContext : ИнформацияОСтранахContext
    {
        static ИнформацияОСтранахGetContext context;

        public static ИнформацияОСтранахGetContext GetContext()
        {
            if (context == null) { context = new ИнформацияОСтранахGetContext(); }
            return context;
        }
    }
}
