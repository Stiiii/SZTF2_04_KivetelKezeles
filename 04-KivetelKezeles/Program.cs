using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KivetelKezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urhajo starDestroyer = new Urhajo("Star Destroyer #5530", 9000, UrhajoKategoria.Teher);
            Urhajo serenity = new Urhajo("Serenity", 1100, UrhajoKategoria.Fregatt);
            Urhajo oldBessie = new Urhajo("Old Bessie", 5000, UrhajoKategoria.Rombolo);
            Urhajo razerBack = new Urhajo("Razorback", 2000, UrhajoKategoria.Teher);
            Urhajo sulytalan = new Urhajo("SzarYacht", 0, UrhajoKategoria.Yacht);
            Urhajo nevtelen = new Urhajo(null, 5000, UrhajoKategoria.Korvette);

            Hajtomu h = new Hajtomu(200);
            Hajtomu h2 = new Hajtomu(200);
            Reaktor r = new Reaktor(500);

            serenity.KomponensFelszerel(h);
            serenity.KomponensFelszerel(h);

            oldBessie.KomponensFelszerel(h);

            razerBack.KomponensFelszerel(h);
            razerBack.KomponensFelszerel(r);

            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(h2);
            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(h);
            starDestroyer.KomponensFelszerel(r);
            starDestroyer.KomponensFelszerel(h);

            starDestroyer.KomponensLeszerel(0);
            starDestroyer.KomponensLeszerel(0);

            starDestroyer.Padlogaz();
            starDestroyer.Beindit();
            starDestroyer.Beindit();
            starDestroyer.Padlogaz();
            

            starDestroyer.Leallit();
            razerBack.Leallit();


            Console.ReadKey();
        }
    }
}
