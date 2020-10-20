using System;
using System.Linq;

namespace sharpz
{
    public class TestSegment
    {
        public static void run()
        {
            //runs Example
        }

        public double[][] getExampleCoords()
        {
            double[] starting_point = { 0.1, 0.6, 1 };
            double[] ending_point = { 5.1, 12.3, 31.1 };
            double[][] example = { starting_point, ending_point };
            return example;
        }

        public static string recieveCoordsFromKeyboard()
        {
            double[] starting_point;
            double[] ending_point;
            string temp = "";

            while (temp.Trim() != "stop")
            {
                Console.WriteLine("Enter starting point coordinates (separated by gap): ");
                temp = Console.ReadLine();
                string[] temp_arr = temp.Split(' ');
                starting_point = (from coord in temp_arr select Convert.ToDouble(coord)).ToArray();
            }

            while (temp.Trim() != "stop")
            {
                Console.WriteLine("Enter ending point coordinates (separated by gap): ");
                temp = Console.ReadLine();
                string[] temp_arr = temp.Split(' ');


            }

            if (true)
            {
                double[][] a = { starting_point, ending_point };
                double[][] a = { new { 3522.52 }, new Array<Int16>};
                return "a";
            }
            throw new Exception("Invalid coords amount");
        }
    }
}