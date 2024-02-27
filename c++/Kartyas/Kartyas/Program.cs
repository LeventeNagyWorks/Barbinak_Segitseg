using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Készítsen C# konzol alkalmazást, amely a magyar kártya és érték osztállyal dolgozik. Generálja le a pakli-t (4*8 kártyát) LINQ JOIN NEW kifejezéssel.
Húzzon véletlenszerűen N db kártyát és adja meg az összesített értéket -LINQ JOIN SUM.
Adja meg egyesével a kihúzott kártyák értékét is! LINQ JOIN NEW
Számolja meg, hogy hány Sz színű kártya van a pakliban - LINQ WHERE COUNT
Számolja meg, hány É értékűnél magasabb kártya van a kihúzottak között.
 */


namespace Kartyas
{
    public class Kartya
    {
        public string Szin { get; set; }
        public string Ertek { get; set; }
    }


    internal class Program
    {
        private static int ErtekSzamma(string ertek)
        {
            switch (ertek)
            {
                case "VII": return 7;
                case "VIII": return 8;
                case "IX": return 9;
                case "X": return 10;
                case "Alsó": return 2;
                case "Felső": return 3;
                case "Király": return 4;
                case "Ász": return 11;
                default: return 0;
            }
        }

        static void Main(string[] args)
        {
            var szinek = new List<string> { "Tök", "Makk", "Zöld", "Piros" };
            var ertekek = new List<string> { "VII", "VIII", "IX", "X", "Alsó", "Felső", "Király", "Ász" };

            var pakli = (from szin in szinek
                         from ertek in ertekek
                         select new Kartya { Szin = szin, Ertek = ertek }).ToList();

            var random = new Random();
            int N = 5; // Véletlenszerűen húzott kártyák száma
            var kihuzottKartyak = pakli.OrderBy(x => random.Next()).Take(N).ToList();

            var osszesitettErtek = kihuzottKartyak.Sum(kartya =>
            {
                switch (kartya.Ertek)
                {
                    case "VII": return 7;
                    case "VIII": return 8;
                    case "IX": return 9;
                    case "X": return 10;
                    case "Alsó": return 2;
                    case "Felső": return 3;
                    case "Király": return 4;
                    case "Ász": return 11;
                    default: return 0;
                }
            });

            Console.WriteLine($"Összesített érték: {osszesitettErtek}\n");

            //Kiíratjuk az összes kihúzott kártyát és azok tulajdonságai
            foreach (var kartya in kihuzottKartyak)
            {
                Console.WriteLine($"Kihúzott kártya: {kartya.Szin} {kartya.Ertek}");
            }
            Console.WriteLine("\n");

            //Megszámoljuk és kiíratjuk az "SZ" színű kártyák számát a pakliban
            var SZ = "Zöld";
            var szKartyakSzama = pakli.Count(kartya => kartya.Szin == SZ);
            Console.WriteLine($"'{SZ}' színű kártyák száma a pakliban: {szKartyakSzama}");

            //Megszámoljuk és kiíratjuk, hogy hány az "É" értékű kártyáknál nagyobb kártya van a kihúzottak között
            var É = "VII";
            var eErtekuKartyakSzama = kihuzottKartyak.Count(kartya => ErtekSzamma(kartya.Ertek) > ErtekSzamma(É));
            Console.WriteLine($"'{É}' értékűnél magasabb kártyák száma: {eErtekuKartyakSzama}\n");
        }
    }
}
