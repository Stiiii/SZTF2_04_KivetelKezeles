using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class Reaktor : IKomponens
    {
        public int Teljesitmeny { get; set; }
        public bool Allapot { get; set; }

        int teljesitmeny;
        public Reaktor(int teljesitmeny)
        {
            this.teljesitmeny = teljesitmeny;
        }

        public void Aktival()
        {
            if (Allapot == true)
            {
                Console.WriteLine(new InvalidOperationException());
            }
            else
            {
                Teljesitmeny = teljesitmeny * -1;
                Allapot = true;
                if (teljesitmeny == 0)
                {
                    Console.WriteLine(new NotSupportedException().Message);
                }
            }
        }

        public void Deaktival()
        {
            if (Allapot == false)
            {
                throw new InvalidOperationException();
                
            }
            else
            {
                Teljesitmeny = 0;
                Allapot = false;
            }
        }
    }
}
