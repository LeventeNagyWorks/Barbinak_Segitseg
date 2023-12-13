using System;

namespace Tombok
{
    internal class Program
    {
        const int TOMBHOSSZ = 3;
        public static bool nyert = false;

        static void Kiiras(int[,] tabla)
        {
            Console.WriteLine();
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool Nyert(int[,] tabla, int jatekos)
        {
            for (int i = 0; i < TOMBHOSSZ; i++)
            {
                if (tabla[i, 0] == jatekos && tabla[i, 1] == jatekos && tabla[i, 2] == jatekos)
                    return true;

                if (tabla[0, i] == jatekos && tabla[1, i] == jatekos && tabla[2, i] == jatekos)
                    return true;
            }

            if (tabla[0, 0] == jatekos && tabla[1, 1] == jatekos && tabla[2, 2] == jatekos)
                return true;

            if (tabla[0, 2] == jatekos && tabla[1, 1] == jatekos && tabla[2, 0] == jatekos)
                return true;

            return false;
        }

        static void Lepes(int[,] tabla, int sor, int oszlop, int jatekosSzam, string jatekosNev)
        {
            if (tabla[sor, oszlop] == 0)
            {
                tabla[sor, oszlop] = jatekosSzam;
            }
            else
            {
                Console.WriteLine("\n*****A hely már foglalt. Próbálkozz újra!*****");
                Kiiras(tabla);
                LepesBeker(jatekosNev, out sor, out oszlop);
                Lepes(tabla, sor, oszlop, jatekosSzam, jatekosNev);
            }
        }

        private static bool MaradtEHely(int[,] ticTacToeTabla)
        {
            bool vanHely = false;
            for (int i = 0; i < TOMBHOSSZ; i++)
            {
                for (int j = 0; j < TOMBHOSSZ; j++)
                {
                    if (ticTacToeTabla[i, j] == 0)
                    {
                        vanHely = true;
                        break;
                    }
                }
                if (vanHely)
                {
                    break;
                }
            }

            return vanHely;
        }

        private static void LepesBeker(string jatekos, out int sor, out int oszlop)
        {
            Console.WriteLine();
            Console.WriteLine($"Játékos {jatekos} lépése (sor oszlop): ");
            sor = Convert.ToInt32(Console.ReadLine()) - 1;
            oszlop = Convert.ToInt32(Console.ReadLine()) - 1;
        }

        private static void JatekosokBeker(string[] jatekos)
        {
            Console.WriteLine("Első játékos neve:");
            jatekos[0] = Console.ReadLine();

            Console.WriteLine("Második játékos neve:");
            jatekos[1] = Console.ReadLine();

            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            bool vanHely = true;
            int[,] ticTacToeTabla = new int[TOMBHOSSZ, TOMBHOSSZ];
            string[] jatekos = new string[2];

            JatekosokBeker(jatekos);

            while (!nyert && vanHely)
            {
                Kiiras(ticTacToeTabla);

                int sor, oszlop;
                LepesBeker(jatekos[0], out sor, out oszlop);

                Lepes(ticTacToeTabla, sor, oszlop, 1, jatekos[0]);

                if (Nyert(ticTacToeTabla, 1))
                {
                    Console.WriteLine($"Gratulálok, {jatekos[0]} nyert!");
                    break;
                }

                vanHely = MaradtEHely(ticTacToeTabla);

                if (!vanHely)
                {
                    Console.WriteLine("Döntetlen!");
                    break;
                }

                Kiiras(ticTacToeTabla);

                LepesBeker(jatekos[1], out sor, out oszlop);

                Lepes(ticTacToeTabla, sor, oszlop, 2, jatekos[1]);

                if (Nyert(ticTacToeTabla, 2))
                {
                    Console.WriteLine($"Gratulálok, {jatekos[1]} nyert!");
                    break;
                }
            }
        }
    }
}