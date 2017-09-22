using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Program
    {
			static string[,] plocha = new string[10, 10]; // X and Y
			static string[,] lode = new string[10, 10];
			static string hor = "";
			static string rada = "";

		static void Plocha()
		{
			
			int shipcounter = 0;
						
			for (int i = 0; i < plocha.GetLength(0); i++)
			{
				for (int p = 0; p < plocha.GetLength(1); p++)
				{
					Console.Write(plocha[i, p]);

					if (i == 0)
					{
						hor += " " + (p) + " ";
					}

					plocha[i, p] = " O ";
					lode[i, p] = " X ";

					rada += plocha[i, p];

				}

				if (i == 0)
				{
					Console.WriteLine(" " + hor);
				}

				Console.Write(i);
				Console.WriteLine(rada);
				Console.WriteLine();
				rada = "";

			}
		}

		static void Pozice(int x, int y, int typ)
		{

		}

		static void Main(string[] args)
		{
			Plocha();

        }
    }
}
