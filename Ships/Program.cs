using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 3;

            int[,] plocha = new int[11, 11];
            int[,] lod1 = new int[4, 1];
            int[,] pozice = new int[5, 5];



            for (int i = 0; i < plocha.GetLength(0); i++)
            {
                for (int p = 0; p < plocha.GetLength(1); p++)
                {
                    Console.Write(plocha[i, p]);

                    //plocha[y, x] = 1;
                    //plocha[4, x] = 1;



                }

                Console.WriteLine();

            }

        }
    }
}
