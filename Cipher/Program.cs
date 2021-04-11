using System;
using System.IO.Enumeration;
using System.Linq;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // We geven alle letters een cijfer. We beginnen van rechtst naar links, omdat dit ook de volgoorde is waarin we dit probleem willen oplossen
            //   1 7 5 1 1
            //   6 8 6 4 2
            //10 8 9 4 2 3

            Console.WriteLine("Hello World!");

            // We proberen alle mogelijk getallen voor de eerste lekker en vervolgens voor de ander leters.

            int[] alles = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            for (int i1 = 1; i1 < 9; i1++)
            {
                int j1 = i1;
                for (int i2 = 1; i2 < 8; i2++)
                {
                    int j2 = FindIndex(i2, j1);
                    for (int i3 = 1; i3 < 8; i3++)
                    {
                        int j3 = FindIndex(i3, j1, j2);
                        if (Colomn1(j1, j2, j3))
                        {
                            for (int i4 = 1; i4 < 7; i4++)
                            {
                                int j4 = FindIndex(i4, j1, j2, j3);
                                if (Colmn2(j1, j2, j3, j4))
                                {
                                    for (int i5 = 1; i5 < 6; i5++)
                                    {
                                        int j5 = FindIndex(i5, j1, j2, j3, j4);
                                        for (int i6 = 1; i6 < 5; i6++)
                                        {
                                            int j6 = FindIndex(i6, j1, j2, j3, j4, j5);
                                            if (Colmn3(j1, j2, j3, j4, j5, j6))
                                            {
                                                for (int i7 = 1; i7 < 4; i7++)
                                                {
                                                    int j7 = FindIndex(i7, j1, j2, j3, j4, j5, j6);
                                                    for (int i8 = 1; i8 < 3; i8++)
                                                    {
                                                        int j8 = FindIndex(i8, j1, j2, j3, j4, j5, j6, j7);
                                                        int j9 = FindIndex(1, j1, j2, j3, j4, j5, j6, j7, j8);
                                                        if (DeUitkomst(j1, j2, j3, j4, j5, j6, j7, j8, j9))
                                                        {
                                                            Console.WriteLine($"  {j1} {j7} {j5} {j1} {j1}");
                                                            Console.WriteLine($"  {j6} {j8} {j6} {j4} {j2}");
                                                            Console.WriteLine($"1 {j8} {j9} {j4} {j2} {j3}");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("geen uitkomst gevonden");


            bool DeUitkomst(int j1, int j2, int j3, int j4, int j5, int j6, int j7, int j8, int j9)
            {
                return j1 + j2 + 10 * j1 + 10 * j4 + j5 * 100 + j6 * 100 
                       + j7 + 1000 + j8 * 1000 + j1 * 10000 + j6 * 10000
                       == j3 + 10 * j2 + j4 * 100 + j9 * 1000 + j8 * 10000 + 100000;
            }

            bool Colmn3(int j1, int j2, int j3, int j4, int j5, int j6)
            {
                return j1 + j2 + 10 * j1 + 10 * j4 + j5 * 100 + j6 * 100 == j3 + 10 * j2 + j4 * 100 ||
                       j1 + j2 + 10 * j1 + 10 * j4 + j5 * 100 + j6 * 100 == j3 + 10 * j2 + j4 * 100 + 100;
            }

            bool Colmn2(int j1, int j2, int j3, int j4)
            {
                return j1 + j2 + 10 * j1 + 10 * j4 == j3 + 10 * j2 ||
                       j1 + j2 + 10 * j1 + 10 * j4 == j3 + 10 * j2 + 100;
            }


            bool Colomn1(int j1, int j2, int j3)
            {
                return j1 + j2 == j3 ||
                       j1 + j2 == j3 + 10;
            }

            int FindIndex(int i, params int[] voorgangers)
            {
                int index = i;
                while (voorgangers.Contains(index))
                {
                    index += 1;
                }

                return index;
            }
        }
    }
}