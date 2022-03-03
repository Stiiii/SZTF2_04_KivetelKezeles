using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class Hajtomu : IKomponens
    {
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }

        public int toloero;
        public Hajtomu(int toloero)
        {
            this.toloero = toloero;
        }

        public void Aktival()
        {
            Teljesitmeny = toloero;
            Allapot = true;
        }

        public void Deaktival()
        {
            Teljesitmeny = 0;
            Allapot = false;
        }
    }
}
