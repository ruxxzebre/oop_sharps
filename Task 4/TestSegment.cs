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
            test.privateRun(test.askUser());
        }

        public void privateRun(int n)
        {
            List<Double>[] coords = { };
            switch (n)
            {
                case 1: coords = this.getExampleCoords(); break;
                case 2: coords = this.recieveCoordsFromFile(); break;
                case 3: coords = this.recieveCoordsFromKeyboard(); break;
                default: throw new Exception("Invalid input int");
            }

            Segment segment1 = new Segment(coords[0], coords[1]);
            List<Double> middlePoint = segment1.middlePoint;
            double segmentLength = segment1.segmentLength;
            // segment1.ScaleSegment(3);
            Utils.PrintGenericDoubleArray(coords[0]);
            Utils.PrintGenericDoubleArray(coords[1]);
        }
        public int askUser()
        {
            Console.WriteLine("Please enter preferable option\n1) Coordinates from example\n2) Coordinates from file\n3) Coordinates from keyboard");
            int answer = 0;
            try
            {
                answer = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
            return answer;
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

            Console.WriteLine("Enter starting point coordinates (separated by gap): ");
            temp = Console.ReadLine();
            starting_point = this.FormDoubleListFromString(temp);

            Console.WriteLine("Enter ending point coordinates (separated by gap): ");
            temp = Console.ReadLine();
            ending_point = this.FormDoubleListFromString(temp);


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