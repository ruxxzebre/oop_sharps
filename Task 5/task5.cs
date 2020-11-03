using System;
using System.Collections.Generic;

namespace sharpz
{
    class Task5
    {
        public static void run()
        {
            Task5 variable = new Task5();
            variable.init();
        }

        public List<Double> transform(List<Double> x, List<Double> y)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] % 2 == 0)
                {
                    x[i] = x[i] - 8;
                }
                result.Add(Math.Round(y[i] * y[i] - x[i] * x[i], 3));
            }
            return result;
        }

        public void checkInput(List<Double> a, List<Double> b)
        {
            if (a.Count != b.Count)
                throw new Exception("Invalid array lengths");
        }
        public void init()
        {
            List<Double> x = readValuesFromFile("./Task 5/x.txt");
            List<Double> y = readValuesFromFile("./Task 5/y.txt");
            this.checkInput(x, y);
            List<Double> z = transform(x, y);
            Utils.PrintGenericDoubleArray(x);
            Utils.PrintGenericDoubleArray(y);
            Utils.PrintGenericDoubleArray(z);
        }

        public List<double> readValuesFromFile(string path)
        {
            string[] text = System.IO.File.ReadAllLines(path);

            List<Double> a = this.FormDoubleListFromString(text[0]);
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
