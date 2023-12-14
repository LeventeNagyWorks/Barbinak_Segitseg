using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Delegalt
{
    // 1) Extension - egész típust bővítsünk ki azzal, hogy prím-e vagy sem

    /*Az IsPrime metódusban a this kulcsszó arra utal, 
    hogy a metódus kiterjeszti az int típust.Ez azt jelenti, 
    hogy az IsPrime metódust közvetlenül hívhatjuk egy int típusú változón,
    mintha az int típusnak lenne ez a metódusa. */

    public static class IntegerExtensions //kiegészítő azaz Extension
    {

        public static bool IsPrime(this int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

    // 2) Delegált logikait ad vissza, két szöveg között működik. (Előrébb, vagy Hátrább)
    public delegate bool ComparisonDelegate(string s1, string s2);

    class Program
    {
        static void Main(string[] args)
        {
            string txt = "szoveg";

            // Próbáljuk ki az Extension-t
            Console.WriteLine(7.IsPrime());  // Igaz
            Console.WriteLine(4.IsPrime());  // Hamis

            //Console.WriteLine(txt.IsPrime());   String esetén értelemszerűen nem működik!

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            /*A ComparisonDelegate egy delegált, amely két sztringet hasonlít össze. 
            Ezt a delegáltat használjuk a Sort metódusban, hogy rendezzük a szavakat hossz szerint.
            A comparison változó egy lambda kifejezés, amely összehasonlítja a sztringek hosszát.
            Ha az első sztring hosszabb, akkor a Sort metódus előrébb helyezi.*/

            // Próbáljuk ki a Delegáltat
            string[] words = { "apple", "bananaaa", "cherry" };
            ComparisonDelegate comparison = (s1, s2) => s1.Length < s2.Length;
            Array.Sort(words, (x, y) => comparison(x, y) ? -1 : 1);
            Console.WriteLine(string.Join(", ", words));  // banana, cherry, apple
        }
    }
}
