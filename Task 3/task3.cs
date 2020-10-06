using System;

namespace sharpz
{
    class Task3
    {
        public static void run()
        {
            string temp;
            int a;
            double b;
            long c;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter int var");
                    temp = Console.ReadLine();
                    a = Convert.ToInt32(temp);
                    break;
                }
                catch
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {

                try
                {
                    Console.WriteLine("Enter double var");
                    temp = Console.ReadLine();
                    b = Convert.ToDouble(temp);
                    break;
                }
                catch
                {
                    Console.WriteLine("Try again");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter long var");
                    temp = Console.ReadLine();
                    c = Convert.ToInt64(temp);
                    break;
                }
                catch
                {
                    Console.WriteLine("Try again");
                }
            }

            Console.WriteLine($"a = {a}; b = {b}; c = {c}");
        }
    }
}
