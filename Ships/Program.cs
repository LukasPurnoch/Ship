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
		static int[,] LimitPlocha = new int[11, 11];

		static string Horni = "";
		static string Rada = "";

		static void Main(string[] args)
		{
			bool on = true;
			bool pos = true;
			bool smer = true;

			VytvoreniPole();

			while (on)
			{
				Console.WriteLine("Typ lodě (1-3)");
				string Typp = Console.ReadLine();

				if (int.TryParse(Typp, out int Typ) && Typ >= 1 && Typ <= 3)
				{
					pos = true;

					while (pos)
					{
						Console.WriteLine("Zadej souřadnice X a Y (0-9)");
						string X = Console.ReadLine();
						string Y = Console.ReadLine();

						if (int.TryParse(Y, out int y) && int.TryParse(X, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
						{
							smer = true;

							while (smer)
							{
								Console.WriteLine("Směr (1 - Vodorovně, 2 - Svisle)");
								string Smerr = Console.ReadLine();

								if (int.TryParse(Smerr, out int Smer) && Smer >= 1 && Smer <= 2)
								{
									Console.Clear();
									Lode(x, y, Smer, Typ);

									pos = false;
									smer = false;

									//shipctr += 1;
									//Test();
								}
							}
						}
					}
				}


			}
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
					LodePlocha[i, p] = " - ";

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

		static void Test()
		{
			for (int i = 0; i < LimitPlocha.GetLength(0); i++)
			{
				for (int f = 0; f < LimitPlocha.GetLength(1); f++)
				{
					Console.Write(LimitPlocha[i, f]);
				}
				Console.WriteLine();
			}
		}

		static void Lode(int x, int y, int Smer, int Typ)
		{
			if(LimitPlocha[x, y] == 0)
			{
				for(int m = 0; m < Typ + 1; m++) // m < 3 + 1 ->
				{
					//Console.Write(m);
					switch (Smer)
					{
						case 1:									// VODOROVNE
							if(LimitPlocha[x, y - m] == 0)
							{
								LodePlocha[x, y - m] = " O ";
								LimitPlocha[x, y - m] = 1;
								LimitPlocha[x - 1, y - m] = 1;
								LimitPlocha[x + 1, y - m] = 1;

								if (m < 1)
								{
									LimitPlocha[x, y + 1] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha[x, y - m - 1] = 1;
								}
							}

							else if (LimitPlocha[x, y + m] == 0)
							{
								LodePlocha[x, y + m] = " O ";
								LimitPlocha[x, y + m] = 1;
								LimitPlocha[x - 1, y + m] = 1;
								LimitPlocha[x + 1, y + m] = 1;

								if (m < 1)
								{
									LimitPlocha[x, y - 1] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha[x, y + m + 1] = 1;
								}
							}
							else
							{
								Console.WriteLine("Pozice je zabraná.");
							}
							break;

						case 2:
							if (x + Typ > 9 && LimitPlocha[x - m, y] == 0)
							{
								LodePlocha[x - m, y] = " O ";
								LimitPlocha[x - m, y] = 1;
								LimitPlocha[x - m, y + 1] = 1;
								LimitPlocha[x - m, y - 1] = 1;

								if (m < 1)
								{
									LimitPlocha[x + 1, y] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha[x - m - 1, y] = 1;
								}
							}
							else if (LimitPlocha[x + m, y] == 0)
							{
								LodePlocha[x + m, y] = " O ";
								LimitPlocha[x + m, y] = 1;
								LimitPlocha[x + m, y + 1] = 1;
								LimitPlocha[x + m, y - 1] = 1;

								if (m < 1)
								{
									LimitPlocha[x - 1, y] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha[x + m + 1, y] = 1;
								}
							}
							else
							{
								Console.WriteLine("Pozice je zabraná.");
							}
							break;
					}
				}
			}

			for (int i = 0; i < LodePlocha.GetLength(0); i++)
			{
				for (int j = 0; j < LodePlocha.GetLength(1); j++)
				{
					Rada += LodePlocha[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
				}
				if (i == 0)
				{
					Console.WriteLine(" " + Horni);
				}

				Console.Write(i);           // i -> Sloupec; hor -> Vodorovne
				Console.WriteLine(Rada);
				Rada = "";
			}
		}
    }
}
