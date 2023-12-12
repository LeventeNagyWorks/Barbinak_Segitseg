using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Domino dom1 = new Domino(2, 5);
            Domino dom2 = new Domino(3, 4);

            Console.WriteLine(dom1);
            Console.WriteLine(dom2);

            dom2.Forgat();
            Console.WriteLine($"Forgatva: {dom2}");

            dom2.Illeszt(dom1);
            if (dom1.Illeszt(dom2))
            {
                Console.WriteLine("Illeszkedik");
            }
            else {
                Console.WriteLine("Nem illeszkedik");
            }
        }
    }
}
