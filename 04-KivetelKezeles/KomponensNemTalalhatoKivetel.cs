using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class KomponensNemTalalhatoKivetel : System.Exception
    {
        public KomponensNemTalalhatoKivetel()
        {
        }
        public KomponensNemTalalhatoKivetel(string hibauzenet) : base(hibauzenet)
        {
        }
    }
}
