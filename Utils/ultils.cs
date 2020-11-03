using System;
using System.Linq;
using System.Collections.Generic;

namespace sharpz
{
    public class Utils
    {
        public static void PrintGenericDoubleArray(List<double> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine("");
        }
    }
}