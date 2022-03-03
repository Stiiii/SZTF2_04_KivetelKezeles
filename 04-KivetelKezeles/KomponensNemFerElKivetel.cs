using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class KomponensNemFerElKivetel : System.Exception
    {
        IKomponens komponens { get; }

        public KomponensNemFerElKivetel(string hibauzenet, IKomponens komponens) : base (hibauzenet)
        {
            this.komponens = komponens;
        }

    }
}
