using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    class NincsElegEnergiaKivetel : System.Exception
    {
        int hianyMerteke;


        public NincsElegEnergiaKivetel(int hianyMerteke) : base($"Nincs elég teljesitmény, {hianyMerteke}MW hiányzik")
        {
            hianyMerteke = int.Parse(Console.ReadLine());
        }

        public int HianyMerteke { get => hianyMerteke;}
    }
}
