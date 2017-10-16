using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ships
{
	class Program
	{
		static string[,] HerniPlocha = new string[10, 10];
		static string[,] LodePlocha = new string[10, 10];
		static string[,] LodePlocha2 = new string[10, 10];
		static int[,] LimitPlocha = new int[11, 11];
		static int[,] LimitPlocha2 = new int[11, 11];
		static string[,] HitMap = new string[10, 10];
		static string[,] HitMap2 = new string[10, 10];
		static int Hrac = 1;
		static int HitCTR1 = 0;
		static int HitCTR2 = 0;
		static int Lod4 = 0;
		static int Lod3 = 0;
		static int Lod2 = 0;
		static int ctrlode = 0;
		static int restart = 1;
		static string xx = "";
		static string yy = "";
		static int XX = 0;
		static int YY = 0;

		static string Horni = "";
		static string Rada = "";

		static void Main(string[] args)
		{
			bool on = true;
			bool pos = true;
			bool smer = true;
			bool reset = true;

			while (reset && restart == 1)
			{
				reset = false;
				restart = 0;

				VytvoreniPole();

				while (on)
				{
					Console.WriteLine("Hrac {0} pokládá lodě!", Hrac);
					Console.WriteLine("Lod 1 - {0}/1, Lod 2 - {1}/1, Lod 3 - {2}/1", Lod2, Lod3, Lod4);
					Console.WriteLine("Typ lodě (1-3)");
					string Typp = Console.ReadLine();

					if (int.TryParse(Typp, out int Typ) && Typ >= 1 && Typ <= 3)
					{

						if (Typ == 1)
						{
							if (Lod2 < 1)
							{
								Lod2 += 1;
								ctrlode += 1;
							}
							else
							{
								Console.WriteLine("Maximum lodí tohoto typu!");
								continue;
							}

						}

						if (Typ == 2)
						{
							if (Lod3 < 1)
							{
								Lod3 += 1;
								ctrlode += 1;
							}
							else
							{
								Console.WriteLine("Maximum lodí tohoto typu!");
								continue;
							}

						}

						if (Typ == 3)
						{
							if (Lod4 < 1)
							{
								Lod4 += 1;
								ctrlode += 1;
							}
							else
							{
								Console.WriteLine("Maximum lodí tohoto typu!");
								continue;
							}

						}


						pos = true;

						while (pos == true && Hrac == 1)
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

										

									}
								}
							}
						}

						while (pos == true && Hrac == 2)
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

										Lode2(x, y, Smer, Typ);

										pos = false;
										smer = false;

									}
								}
							}
						}

						if (ctrlode == 3)
						{
							Hrac += 1;
							Lod2 = 0;
							Lod3 = 0;
							Lod4 = 0;

							Console.Clear();

						}

						if (ctrlode == 6 && Hrac == 2)
						{
							bool Hits = true;
							bool Turn = true;
							on = false;

							Console.Clear();

							while (Hits)
							{
								Turn = true;

								while (Turn)
								{
									Console.WriteLine("Hráč 1 střílí na: ");

									for (int i = 0; i < HitMap2.GetLength(0); i++)
									{
										for (int j = 0; j < HitMap2.GetLength(1); j++)
										{
											Rada += HitMap2[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
										}
										if (i == 0)
										{
											Console.WriteLine(" " + Horni);
										}

										Console.Write(i);           // i -> Sloupec; hor -> Vodorovne
										Console.WriteLine(Rada);
										Rada = "";
									}

										xx = Console.ReadLine();
										yy = Console.ReadLine();
								
										if (int.TryParse(yy, out YY) && int.TryParse(xx, out XX) && YY >= 0 && YY <= 9 && XX >= 0 && XX <= 9)
										{
											Console.Clear();
											Hit(XX, YY);
											Turn = false;
										}
								}

								Turn = true;

								while (Turn)
								{
									Console.WriteLine("Hráč 2 střílí na: ");

									for (int i = 0; i < HitMap.GetLength(0); i++)
									{
										for (int j = 0; j < HitMap.GetLength(1); j++)
										{
											Rada += HitMap[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
										}
										if (i == 0)
										{
											Console.WriteLine(" " + Horni);
										}

										Console.Write(i);           // i -> Sloupec; hor -> Vodorovne
										Console.WriteLine(Rada);
										Rada = "";
									}

									xx = Console.ReadLine();
									yy = Console.ReadLine();

									if (int.TryParse(yy, out YY) && int.TryParse(xx, out XX) && YY >= 0 && YY <= 9 && XX >= 0 && XX <= 9)
									{
										Console.Clear();
										Hit2(XX, YY);
										Turn = false;
									}
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
					LodePlocha2[i, p] = " - ";
					HitMap[i, p] = " - ";
					HitMap2[i, p] = " - ";

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

		static void HraciPlocha()
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
			if (LimitPlocha[x, y] == 0)
			{
				for (int m = 0; m < Typ + 1; m++) // m < 3 + 1 ->
				{
					//Console.Write(m);
					switch (Smer)
					{
						case 1:                                 // VODOROVNE
							if (LimitPlocha[x, y - m] == 0)
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

		static void Lode2(int x, int y, int Smer, int Typ)
		{
			if (LimitPlocha2[x, y] == 0)
			{
				for (int m = 0; m < Typ + 1; m++) // m < 3 + 1 ->
				{
					//Console.Write(m);
					switch (Smer)
					{
						case 1:                                 // VODOROVNE
							if (LimitPlocha2[x, y - m] == 0)
							{
								LodePlocha2[x, y - m] = " O ";
								LimitPlocha2[x, y - m] = 1;
								LimitPlocha2[x - 1, y - m] = 1;
								LimitPlocha2[x + 1, y - m] = 1;

								if (m < 1)
								{
									LimitPlocha2[x, y + 1] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha2[x, y - m - 1] = 1;
								}
							}

							else if (LimitPlocha2[x, y + m] == 0)
							{
								LodePlocha2[x, y + m] = " O ";
								LimitPlocha2[x, y + m] = 1;
								LimitPlocha2[x - 1, y + m] = 1;
								LimitPlocha2[x + 1, y + m] = 1;

								if (m < 1)
								{
									LimitPlocha2[x, y - 1] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha2[x, y + m + 1] = 1;
								}
							}
							else
							{
								Console.WriteLine("Pozice je zabraná.");
							}
							break;

						case 2:
							if (x + Typ > 9 && LimitPlocha2[x - m, y] == 0)
							{
								LodePlocha2[x - m, y] = " O ";
								LimitPlocha2[x - m, y] = 1;
								LimitPlocha2[x - m, y + 1] = 1;
								LimitPlocha2[x - m, y - 1] = 1;

								if (m < 1)
								{
									LimitPlocha2[x + 1, y] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha2[x - m - 1, y] = 1;
								}
							}
							else if (LimitPlocha2[x + m, y] == 0)
							{
								LodePlocha2[x + m, y] = " O ";
								LimitPlocha2[x + m, y] = 1;
								LimitPlocha2[x + m, y + 1] = 1;
								LimitPlocha2[x + m, y - 1] = 1;

								if (m < 1)
								{
									LimitPlocha2[x - 1, y] = 1;
								}
								else if (m > Typ - 1)
								{
									LimitPlocha2[x + m + 1, y] = 1;
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

			for (int i = 0; i < LodePlocha2.GetLength(0); i++)
			{
				for (int j = 0; j < LodePlocha2.GetLength(1); j++)
				{
					Rada += LodePlocha2[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
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

		static void Hit(int x, int y)
		{
			if (LodePlocha2[x, y] == " O ")
			{
				HitMap2[x, y] = " 0 ";
				Console.WriteLine("Trefa!");
				HitCTR1 += 1;
			}

			if (LodePlocha2[x, y] != " O ")
			{
				HitMap2[x, y] = " X ";
				Console.WriteLine("Vedle!");
			}


			for (int i = 0; i < HitMap2.GetLength(0); i++)
			{
				for (int j = 0; j < HitMap2.GetLength(1); j++)
				{
					Rada += HitMap2[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
				}
				if (i == 0)
				{
					Console.WriteLine(" " + Horni);
				}

				Console.Write(i);           // i -> Sloupec; hor -> Vodorovne
				Console.WriteLine(Rada);
				Rada = "";
			}

			if (HitCTR1 == 9)
			{
				Thread.Sleep(5000);
				Console.Clear();
				Console.WriteLine("Hráč 1 vyhrál!");
				Console.WriteLine("Hrát znovu? Y/N");
				string rrestart = Console.ReadLine();

				if (rrestart == "Y" || rrestart == "y")
				{
					restart = 1;
				}
				else
				{
					Console.WriteLine("Ukončuji");
					Thread.Sleep(5000);
					Environment.Exit(0);
				}
			}
		}

		static void Hit2(int x, int y)
		{
			if (LodePlocha[x, y] == " O ")
			{
				HitMap[x, y] = " 0 ";
				Console.WriteLine("Trefa!");
				HitCTR2 += 1;
			}

			if (LodePlocha[x, y] != " O ")
			{
				HitMap[x, y] = " X ";
				Console.WriteLine("Vedle!");
			}


			for (int i = 0; i < HitMap.GetLength(0); i++)
			{
				for (int j = 0; j < HitMap.GetLength(1); j++)
				{
					Rada += HitMap[i, j]; //Vypise cele pole -> Zmeny nastaly pri nastavovani limitu
				}
				if (i == 0)
				{
					Console.WriteLine(" " + Horni);
				}

				Console.Write(i);           // i -> Sloupec; hor -> Vodorovne
				Console.WriteLine(Rada);
				Rada = "";
			}

			if (HitCTR2 == 9)
			{
				Thread.Sleep(5000);
				Console.Clear();
				Console.WriteLine("Hráč 2 vyhrál!");
				Console.WriteLine("Hrát znovu? Y/N");
				string rrestart = Console.ReadLine();

				if (rrestart == "Y" || rrestart == "y")
				{
					restart = 1;
				}
				else
				{
					Console.WriteLine("Ukončuji");
					Thread.Sleep(5000);
					Environment.Exit(0);
				}
			}
		}
	}
}