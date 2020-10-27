using System;
using System.Linq;
using System.Collections.Generic;

namespace sharpz
{
    public class TestSegment
    {
        public static void run()
        {
            TestSegment test = new TestSegment();
            test.privateRun();
        }

        public void privateRun()
        {
            // double[][] coords = getExampleCoords();
            // double[][] coords = recieveCoordsFromKeyboard();
            List<Double>[] coords = this.recieveCoordsFromFile();

            Segment segment1 = new Segment(coords[0], coords[1]);
            List<Double> middlePoint = segment1.middlePoint;
            double segmentLength = segment1.segmentLength;
            // segment1.ScaleSegment(3);
            for (int i = 0; i < coords[0].Count; i++)
            {
                Console.Write($"{coords[0][i]} ");
            }
            Console.WriteLine("");
            for (int i = 0; i < coords[1].Count; i++)
            {
                Console.Write($"{coords[1][i]} ");
            }
            Console.WriteLine("");
        }

        public List<Double>[] getExampleCoords()
        {
            List<Double> starting_point = new List<Double>() { 0.1, 0.6, 1 };
            List<Double> ending_point = new List<Double>() { 5.1, 12.3, 31.1 };
            List<Double>[] example = { starting_point, ending_point };
            return example;
        }

        public List<Double>[] recieveCoordsFromKeyboard()
        {
            List<Double> starting_point = new List<Double>();
            List<Double> ending_point = new List<Double>();
            string temp = "";

            while (temp.Trim() != "stop")
            {
                Console.WriteLine("Enter starting point coordinates (separated by gap): ");
                temp = Console.ReadLine();
                starting_point = this.FormDoubleListFromString(temp);
            }

            while (temp.Trim() != "stop")
            {
                Console.WriteLine("Enter ending point coordinates (separated by gap): ");
                temp = Console.ReadLine();
                ending_point = this.FormDoubleListFromString(temp);
            }

            if (starting_point.Count == ending_point.Count)
            {
                return new List<Double>[] { starting_point, ending_point };
            }
            throw new Exception("Invalid coords amount");
        }

        public List<double>[] recieveCoordsFromFile()
        {
            string[] text = System.IO.File.ReadAllLines("./Task 4/recieved.txt");

            List<Double>[] a = { this.FormDoubleListFromString(text[0]), this.FormDoubleListFromString(text[1]) };
            Console.WriteLine(a.Length);
            return a;
        }

        private List<double> FormDoubleListFromString(string items)
        {
            List<double> result = new List<double>();
            foreach (string item in items.Split(' '))
            {
                result.Add(Convert.ToDouble(item.Trim()));
            }
            return result;
        }


    }
}