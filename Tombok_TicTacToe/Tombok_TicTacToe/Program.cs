using System;

namespace Tombok
{
    internal class Program
    {
        static void Kiiras(int[,] tabla)
        {
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
            // Nyerés ellenőrzése sorokban, oszlopokban, átlókban
            for (int i = 0; i < 3; i++)
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

        static void Lepes(int[,] tabla, int sor, int oszlop, int jatekos)
        {
            tabla[sor, oszlop] = jatekos;
        }

        static void Main(string[] args)
        {
            bool vanHely = false;

            int[,] ticTacToeTabla = new int[3, 3]; // Tic-Tac-Toe tábla
            string[] jatekos = new string[2]; // Két játékos neve

            Console.WriteLine("Első játékos neve:");
            jatekos[0] = Console.ReadLine();

            Console.WriteLine("Második játékos neve:");
            jatekos[1] = Console.ReadLine();

            while (true)
            {
                Kiiras(ticTacToeTabla); // Tábla kiírása

                Console.WriteLine($"Játékos {jatekos[0]} lépése (sor oszlop): ");
                int sor = Convert.ToInt32(Console.ReadLine())-1;
                int oszlop = Convert.ToInt32(Console.ReadLine())-1;

                Lepes(ticTacToeTabla, sor, oszlop, 1); // Játékos 1 lépése

                if (Nyert(ticTacToeTabla, 1))
                {
                    Console.WriteLine($"Gratulálok, {jatekos[0]} nyert!");
                    break;
                }

                //van-e hely?
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (ticTacToeTabla[i, j] == 0)
                        {
                            vanHely = true;
                            break;
                        }
                    }
                    if (vanHely)
                        break;
                }

                if (!vanHely)
                {
                    Console.WriteLine("Döntetlen!");
                    break;
                }

                // Második játékos következik
                Kiiras(ticTacToeTabla); // Tábla kiírása

                Console.WriteLine($"Játékos {jatekos[1]} lépése (sor oszlop): ");
                sor = Convert.ToInt32(Console.ReadLine()) - 1;
                oszlop = Convert.ToInt32(Console.ReadLine()) - 1;

                Lepes(ticTacToeTabla, sor, oszlop, 2); // Játékos 2 lépése

                if (Nyert(ticTacToeTabla, 2))
                {
                    Console.WriteLine($"Gratulálok, {jatekos[1]} nyert!");
                    break;
                }
            }
        }
    }
}

