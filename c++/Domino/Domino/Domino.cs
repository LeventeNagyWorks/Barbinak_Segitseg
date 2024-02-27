using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    public class Domino
    {
        private int oldal1;
        private int oldal2;

        public Domino(int oldal1, int oldal2)
        {
            this.oldal1 = oldal1;
            this.oldal2 = oldal2;
        }

        public int Oldal1
        {
            get { return oldal1; }
        }

        public int Oldal2
        {
            get { return oldal2; }
        }

        public void Forgat()
        {
            int temp = oldal1;
            oldal1 = oldal2;
            oldal2 = temp;
        }

        public bool Illeszt(Domino d)
        {
            return oldal1 == d.oldal1 || oldal1 == d.oldal2 || oldal2 == d.oldal1 || oldal2 == d.oldal2;
        }

        public override string ToString()
        {
            return String.Format($"[{oldal1}|{oldal2}]");
        }
    }


    public class DominoJatek
    {
        private List<Domino> dominok;

        public DominoJatek(int maxPont)
        {
            dominok = new List<Domino>();
            for (int i = 0; i <= maxPont; i++)
            {
                for (int j = i; j <= maxPont; j++)
                {
                    dominok.Add(new Domino(i, j));
                }
            }
        }

        public void Keveres()
        {
            Random rnd = new Random();
            dominok = dominok.OrderBy(x => rnd.Next()).ToList();
        }

        public Domino Huzas()
        {
            Domino huzott = dominok[0];
            dominok.RemoveAt(0);
            return huzott;
        }

        public void Lepes(Domino d)
        {
            dominok.Add(d);
        }

        public void Kiiras()
        {
            foreach (Domino d in dominok)
            {
                Console.WriteLine(d);
            }
        }
    }

}
