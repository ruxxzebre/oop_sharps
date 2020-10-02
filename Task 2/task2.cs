using System;

namespace sharpz
{
    class Task2
    {
        public static void run()
        {
            try
            {
                Console.WriteLine("Enter int var");
                string temp = Console.ReadLine();
                int a = Convert.ToInt32(temp);

                Console.WriteLine("Enter double var");
                temp = Console.ReadLine();
                double b = Convert.ToDouble(temp);

                Console.WriteLine("Enter long var");
                temp = Console.ReadLine();
                long c = Convert.ToInt64(temp);

                Console.WriteLine($"a = {a}; b = {b}; c = {c}");
            }
            catch
            {
                Console.WriteLine("Invalid input... Try again");
            }
        }
    }
}
