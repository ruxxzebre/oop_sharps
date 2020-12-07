using System;
using System.IO;
using System.Text.RegularExpressions;

namespace sharpz
{
    public class Task8
    {
        public static void run() 
        {
            MyComplex A = new MyComplex(1,1);
            MyComplex B,D;
            MyComplex C = new MyComplex(1);
            B = A + C;
            Console.WriteLine($"{A} {B} {C}");
            C = A + 10.5;
            Console.WriteLine($"{A} {B} {C}");
            C = 10.5 + A;
            Console.WriteLine($"{A} {B} {C}");
            D = -C;
            Console.WriteLine($"{A} {B} {C} {D}");
            C = A + B + C + D;
            Console.WriteLine($"{A} {B} {C} {D}");
            D.InputFromTerminal();
            Console.WriteLine($"A = {A}, B = {B}, C = {C}, D = {D}");
        }


        public class MyComplex
        {
            private double real, imaginary;

            public MyComplex(double real=0, double imaginary=0)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public static MyComplex operator +(MyComplex a, MyComplex b)
            {
                return new MyComplex(a.real + b.real, a.imaginary + b.imaginary);
            }

            public static MyComplex operator +(MyComplex a, double b)
            {
                return new MyComplex(a.real + b, a.imaginary);
            }

            public static MyComplex operator +(double a, MyComplex b)
            {
                return new MyComplex(a + b.real, b.imaginary);
            }

            public static MyComplex operator -(MyComplex a)
            {
                return new MyComplex(a.real * -1, a.imaginary);
            }

            public static MyComplex operator -(MyComplex a, MyComplex b)
            {
                return new MyComplex(a.real - b.real, a.imaginary - b.imaginary);
            }
            
            public static MyComplex operator *(MyComplex a, MyComplex b)
            {
                return new MyComplex(a.real*b.real-a.imaginary*b.imaginary, a.imaginary*b.real-a.real*b.imaginary);
            }

            public static MyComplex operator /(MyComplex a, MyComplex b)
            {
                // NOTE (C*D)i == (Ci*Di) 
                return new MyComplex(a.real*b.real, a.imaginary*b.imaginary);
            }

            public double this[string type]
            {
                get
                {
                    switch (type)
                    {
                        case "realValue":
                            return this.real;
                        case "imageValue":
                            return this.imaginary;
                        default:
                            return 0;
                    }
                }
            }

            public void InputFromTerminal()
            {
                string complexStuff = Console.ReadLine();
                this.ParseComplex(complexStuff);
            }

            public void InputFromFile(string pathToFile)
            {
                string data = File.ReadAllText(pathToFile);
                this.ParseComplex(data);
            }

            public void ParseComplex(string str) {
                //регекс експрешн що парсить комплексні числа (магічна вещь, я відчув шрами на спині після дебага цьої штуки)
                var complexPattern = @"(\s*[\+\-]?\s*\d+\,?\d*\s*)([\+\-]\s*\d+\,?\d+i)";
                var matches = Regex.Match(str, complexPattern);

                if (matches.Groups.Count < 3) throw new Exception("Not a complex number");

                string real = matches.Groups[1].Value;
                string imaginary = matches.Groups[2].Value;
                //видаляємо "і", бо воно нам не треба, другий аргумент і так є уявною частиною, просто це покажник що 
                //що та частина ну типу регекс, так треба
                real = Regex.Replace(real, @"\s+", String.Empty);
                imaginary = Regex.Replace(imaginary, @"\s+|i", String.Empty);
                 
                //консоль лог щоб ТочНО впевнитись що все ок і конвертація
                Console.WriteLine($"Real: {real} and Imaginary: {imaginary}");
                this.real = Convert.ToDouble(real);
                this.imaginary = Convert.ToDouble(imaginary);
            }

            public override string ToString()
            {
                return this.real + "+" + this.imaginary + "*i";
            }
        }
    }
}