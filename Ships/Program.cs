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
			static string[,] lodeplocha = new string[10, 10];
			static int[,] plochalimit = new int[10, 10]; 
			static string hor = "";
			static string rada = "";

		static void Plocha()
		{
			for (int i = 0; i < plocha.GetLength(0); i++)
			{
				for (int p = 0; p < plocha.GetLength(1); p++)
				{
					Console.Write(plocha[i, p]);

					if (i == 0) //
					{
						hor += " " + (p) + " ";
					}

					plocha[i, p] = " X ";
					lodeplocha[i, p] = " X ";

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

		static void Pozice(int x, int y, int smer, int typ)
		{
			if(plochalimit[x, y] == 0)
			{
				for (int l = 0; l < typ + 1; l++)
				{
					switch (smer)
					{
						case 1:
							if (y + typ > 9 && plochalimit[x, y - l] == 0)
							{
								lodeplocha[x, y - l] = " O ";
								plochalimit[x, y - l] = 1;
								plochalimit[x - 1, y - l] = 1;
								plochalimit[x + 1, y - l] = 1;

								if (l < 1)
								{
									plochalimit[x, y + 1] = 1;
								}
								else if (l > typ - 1)
								{
									plochalimit[x, y - l - 1] = 1;
								}
							}
							else if (plochalimit[x, y + l] == 0)
							{
								lodeplocha[x, y + l] = " O ";
								plochalimit[x, y + l] = 1;
								plochalimit[x - 1, y + l] = 1;
								plochalimit[x + 1, y + l] = 1;

								if (l < 1)
								{
									plochalimit[x, y - 1] = 1;
								}
								else if (l > typ - 1)
								{
									plochalimit[x, y + l + 1] = 1;
								}
							}
							else
							{
								Console.WriteLine("Pozice je zabraná.");
							}
							break;
						case 2:
							if (x + typ > 9 && plochalimit[x - l, y] == 0)
							{
								lodeplocha[x - l, y] = " O ";
								plochalimit[x - l, y] = 1;
								plochalimit[x - l, y + 1] = 1;
								plochalimit[x - l, y - 1] = 1;

								if (l < 1)
								{
									plochalimit[x + 1, y] = 1;
								}
								else if (l > typ - 1)
								{
									plochalimit[x - l - 1, y] = 1;
								}
							}
							else if (plochalimit[x + l, y] == 0)
							{
								lodeplocha[x + l, y] = " O ";
								plochalimit[x + l, y] = 1;
								plochalimit[x + l, y + 1] = 1;
								plochalimit[x + l, y - 1] = 1;

								if (l < 1)
								{
									plochalimit[x - 1, y] = 1;
								}
								else if (l > typ - 1)
								{
									plochalimit[x + l + 1, y] = 1;
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

			for (int i = 0; i < lodeplocha.GetLength(0); i++)
			{
				for (int j = 0; j < lodeplocha.GetLength(1); j++)
				{
					rada += lodeplocha[i, j];
				}
				if (i == 0)
				{
					Console.WriteLine(" " + hor);
				}

				Console.Write(i);
				Console.WriteLine(rada);
				rada = "";
			}

		}
				
		static void Main(string[] args)
		{
			bool on = true;
			bool pos = true;
			bool smer = true;

			Plocha();

			while (on)
			{
				Console.WriteLine("Typ lodě (1-3)");
				string VstupTypLode = Console.ReadLine();
				
				if(int.TryParse(VstupTypLode, out int TypLode) && TypLode >= 1 && TypLode <= 3)
				{
					pos = true;

					while(pos)
					{
						Console.WriteLine("Zadej souřadnice X a Y (0-9)");
						string PoziceY = Console.ReadLine();
						string PoziceX = Console.ReadLine();

						if (int.TryParse(PoziceY, out int y) && int.TryParse(PoziceX, out int x) && y >= 0 && y <= 9 && x >= 0 && x <= 9)
						{
							smer = true;

							while(smer)
							{
								Console.WriteLine("Směr (1 - Vodorovně, 2 - Svisle)");
								string VstupSmer = Console.ReadLine();

								if(int.TryParse(VstupSmer, out int Smer) && Smer >= 1 && Smer <=2)
								{
									Console.Clear();
									Pozice(x, y, Smer, TypLode);

									pos = false;
									smer = false;
								}
							}
						}
					}
				}


			}

			

			
						


        }
    }
}
