using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class NemDeaktivalhatoKivetel : System.Exception
    {
        public NemDeaktivalhatoKivetel(string hibauzenet, Exception e) : base(hibauzenet,e)
        {
            Console.WriteLine("[BELSO KIVETEL]: Operation is not valid due to the current state of the object. (ex.InnerException)");
        }
    }
}
