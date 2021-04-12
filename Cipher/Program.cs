using System;
using System.IO.Enumeration;
using System.Linq;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // We geven alle letters een ciifer. We beginnen van rechtst naar links, omdat dit ook de volgoorde is waarin we dit probleem willen oplossen
            //   T A S T E
            //   S I G H T+
            // C I P H E R
            //
            //   1 7 5 1 2
            //   5 8 6 4 1+
            //10 8 9 4 2 3

            Console.WriteLine("Hello World!");

            // We proberen alle mogeliik getallen voor de eerste lekker en vervolgens voor de ander leters.

            for (int i1 = 0; i1 < 10; i1++)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    if (IsBezet(i2, i1))
                    {
                        continue;
                    }

                    for (int i3 = 0; i3 < 10; i3++)
                    {
                        if (IsBezet(i3, i1, i2) || !Colomn1(i1, i2, i3))
                        {
                            continue;
                        }

                        for (int i4 = 0; i4 < 10; i4++)
                        {
                            if (IsBezet(i4, i1, i2, i3) ||! Colmn2(i1, i2, i3, i4))
                            {
                                continue;
                            }

                            for (int i5 = 0; i5 < 10; i5++)
                            {
                                if (IsBezet(i5, i1, i2, i3, i4))
                                {
                                    continue;
                                }

                                for (int i6 = 0; i6 < 10; i6++)
                                {
                                    if (IsBezet(i6, i1, i2, i3, i4, i5)|| !Colmn3(i1, i2, i3, i4, i5, i6))
                                    {
                                        continue;
                                    }

                                    for (int i7 = 0; i7 < 10; i7++)
                                    {
                                        if (IsBezet(i7, i1, i2, i3, i4, i5, i6))
                                        {
                                            continue;
                                        }

                                        for (int i8 = 0; i8 < 10; i8++)
                                        {
                                            if (IsBezet(i8, i1, i2, i3, i4, i5, i6, i7))
                                            {
                                                continue;
                                            }

                                            for (int i9 = 0; i9 < 10; i9++)
                                            {
                                                if (IsBezet(i9, i1, i2, i3, i4, i5, i6, i7, i8))
                                                {
                                                    continue;
                                                }

                                                if (DeUitkomst(i1, i2, i3, i4, i5, i6, i7, i8, i9))
                                                {
                                                    Console.WriteLine($"  {i1} {i7} {i5} {i1} {i2}");
                                                    Console.WriteLine($"  {i5} {i8} {i6} {i4} {i1}");
                                                    Console.WriteLine($"1 {i8} {i9} {i4} {i2} {i3}");
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


            bool DeUitkomst(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9)
            {
                return i1 + i2 - i3 + 10 * (i1 + i4 - i2) + 100 * (i5 + i6 - i4) + 1000 * (i7 + i8 - i9) +
                    10000 * (i1 + i5 - i8) + 100000 * (-1) == 0;
            }

            bool Colmn3(int i1, int i2, int i3, int i4, int i5, int i6)
            {
                return i1 + i2 - i3 + 10 * (i1 + i4 - i2) + 100 * (i5 + i6 - i4) == 0 ||
                       i1 + i2 - i3 + 10 * (i1 + i4 - i2) + 100 * (i5 + i6 - i4) == 1000;
            }

            bool Colmn2(int i1, int i2, int i3, int i4)
            {
                return i1 + i2 - i3 + 10 * (i1 + i4 - i2) == 0 ||
                       i1 + i2 - i3 + 10 * (i1 + i4 - i2) == 100;
            }


            bool Colomn1(int i1, int i2, int i3)
            {
                return i1 + i2 - i3 == 0 ||
                       i1 + i2 - i3 == 10;
            }

            bool IsBezet(int i, params int[] voorgangers)
            {
                return i == 1 || voorgangers.Contains(i);
            }
        }
    }
}