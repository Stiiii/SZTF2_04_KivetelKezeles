using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    enum UrhajoKategoria
    {
        Yacht = 2, Korvette = 4, Fregatt = 6, Rombolo = 8, Teher = 8, Allomas = 20
    }

    class Urhajo
    {
        public Urhajo(string nev, int uresTomeg, UrhajoKategoria kategoria)
        {
            if (nev == null)
            {
                Console.WriteLine("[KIVETEL] " + new ArgumentNullException(Convert.ToString(nameof(nev))).Message);
                //Console.WriteLine($"[KIVÉTEL] Value cannot be null.\nParameter name: {nameof(nev)}");
            }

            else if (uresTomeg <= 0)
            {
                Console.WriteLine("[KIVETEL]" + new ArgumentOutOfRangeException(Convert.ToString(nameof(uresTomeg))).Message);
                //Console.WriteLine($"[KIVÉTEL] Az üres tömeg nem lehet negatív!\nParameter name: {nameof(uresTomeg)}");
            }
            else
            {
                this.nev = nev;
                this.uresTomeg = uresTomeg;
                this.kategoria = kategoria;
                this.komponensek = new IKomponens[(int)kategoria];
                Console.WriteLine($"{nev} letrehozva!");
            }
        }

        string nev { get; }
        int uresTomeg { get; }
        UrhajoKategoria kategoria { get; }
        int aktualisTeljesitmeny { get; set; }
        IKomponens[] komponensek { get; }
        int IKomponensCounter = 0;

        public void KomponensFelszerel(IKomponens k)
        {
            if (IKomponensCounter == komponensek.Length)
            {
                Console.WriteLine(new KomponensNemFerElKivetel("[KIVETEL] A komponens nem fér el!", k).Message);
            }
            else
            {
                Console.Write("[Hozzaadas] ");
                if (k is Hajtomu)
                {
                    Console.WriteLine("Hajtomu hozzaadva a(z) " + nev + " hajohoz");
                }
                if (k is Reaktor)
                {
                    Console.WriteLine("Reaktor hozzaadva a(z) " + nev + " hajohoz");
                }
                komponensek[IKomponensCounter] = k;
                IKomponensCounter++;
            }
        }
        public void KomponensLeszerel(int index)
        {
            if (komponensek[index] == null)
            {
                Console.WriteLine(new KomponensNemTalalhatoKivetel("[KIVETEL] A törölni kívánt komponens nem található!").Message);
                //Console.WriteLine("[KIVÉTEL] A törölni kívánt komponens nem található!");
            }
            else
            {
                Console.WriteLine($"[Leszereles] A(z) {index} indexu komponens leszerelve a(z) {nev} hajorol");
                komponensek[index] = null;
            }
        }
        public void Padlogaz()
        {
            int tmp = aktualisTeljesitmeny;
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Hajtomu && komponensek[i].Allapot == false)
                {
                    komponensek[i].Aktival();
                    aktualisTeljesitmeny -= komponensek[i].Teljesitmeny;
                }
            }
            if (aktualisTeljesitmeny < 0)
            {
                //Console.WriteLine(new NincsElegEnergiaKivetel( aktualisTeljesitmeny * (-1) ));
                Console.WriteLine($"[KIVETEL] Nincs elég teljesítmény, {aktualisTeljesitmeny * (-1)} MW hiányzik");
            }
            if (aktualisTeljesitmeny < 0)
            {
                for (int i = 0; i < komponensek.Length; i++)
                {
                    if (komponensek[i] is Hajtomu)
                    {
                        komponensek[i].Deaktival();
                    }
                }
                aktualisTeljesitmeny = tmp;
            }
            else
            {
                Console.WriteLine($"[Padlogaz] A(z) {nev} urhajo padlogazon megy");
            }
        }
        public void Beindit()
        {
            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Reaktor)
                {
                    try
                    {
                        if (komponensek[i].Allapot == false)
                        {
                            komponensek[i].Aktival();
                            
                            aktualisTeljesitmeny -= komponensek[i].Teljesitmeny;
                        }
                        else
                        {
                            Console.WriteLine("[HIBA] Egy reaktor már fut!");
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (NotSupportedException)
                    {
                        KomponensLeszerel(i);
                    }
                }
            }
            Console.WriteLine($"[Beinditas] A(z) {nev} urhajo beinditva");
        }

        public void Leallit()
        {
            Console.WriteLine($"[Leallitas] A(z) {nev} urhajo leallitasa meghivva");

            for (int i = 0; i < komponensek.Length; i++)
            {
                if (komponensek[i] is Reaktor)
                {
                    try
                    {
                        komponensek[i].Deaktival();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("[KIVETEL] Egy komponens nem deaktiválható!" + new NemDeaktivalhatoKivetel("",e).Message);
                    }
                }
            }
        }
    }
}
