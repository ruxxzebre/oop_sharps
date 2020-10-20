using System;
using System.Linq;

namespace sharpz
{
    public class TestSegment
    {
        public static void run()
        {

            double[][] coords = getExampleCoords();
            // double[][] coords = recieveCoordsFromKeyboard();
            // double[][] coords = recieveCoordsFromFile();

            Segment segment1 = new Segment(coords[0], coords[1]);
            double[] middlePoint = segment1.middlePoint;
            double segmentLength = segment1.segmentLength;
            segment1.ScaleSegment(3);

        }

        public static double[][] getExampleCoords()
        {
            double[] starting_point = { 0.1, 0.6, 1 };
            double[] ending_point = { 5.1, 12.3, 31.1 };
            double[][] example = { starting_point, ending_point };
            return example;
        }

        public static double[][] recieveCoordsFromKeyboard()
        {
            double[] starting_point = { };
            double[] ending_point = { };
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
                ending_point = (from coord in temp_arr select Convert.ToDouble(coord)).ToArray();
            }

            if (starting_point.Length == ending_point.Length)
            {
                double[][] a = { starting_point, ending_point };
                return a;
            }
            throw new Exception("Invalid coords amount");
        }

        // public static double[][] recieveCoordsFromFile()
        public static double[][] recieveCoordsFromFile()
        {
            string[] text = System.IO.File.ReadAllLines("./Task 4/recieved.txt");
            double[] starting_point = { };
            double[] ending_point = { };
            starting_point = (from coord in text[0] select Convert.ToDouble(coord)).ToArray();
            ending_point = (from coord in text[1] select Convert.ToDouble(coord)).ToArray();
            double[][] a = { starting_point, ending_point };
            return a;
        }
    }
}