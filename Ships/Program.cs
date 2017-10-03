using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Program
    {
		static string[,] HerniPlocha = new string[10, 10];
		static string[,] LodePlocha = new string[10, 10];
		static int[,] LimitPlocha = new int[10, 10];

		static string Horni = "";
		static string Rada = "";

		static void Main(string[] args)
		{
			VytvoreniPole();
		}

		static void VytvoreniPole()
		{
			for (int i = 0; i < HerniPlocha.GetLength(0); i++)
			{
				for (int p = 0; p < HerniPlocha.GetLength(1); p++)
				{
					Console.Write(HerniPlocha[i, p]);

					if (i == 0) //
					{
						Horni += " " + (p) + " ";
					}

					HerniPlocha[i, p] = " - ";
					HerniPlocha[i, p] = " - ";

					Rada += HerniPlocha[i, p];

				}

				if (i == 0)
				{
					Console.WriteLine(" " + Horni);
				}

				Console.Write(i);
				Console.WriteLine(Rada);
				Console.WriteLine();
				Rada = "";

			}
		}

		static void Lode(int X, int Y, int Smer, int Typ)
		{
			if(LimitPlocha[X, Y] == 0)
			{

			}
		}
    }
}
