using System;
using System.IO;
using System.Text.RegularExpressions;

// WE GONNA THROW A PARTY
// LET'S RUN IT UP RUN IT UP
// YEAH

// ГРАЄМОСЬ ІЗ ДЕЛЕГАТАМИ ТА ІНТЕРФЕЙСАМИ У ПРЯМОМУ ЄФІРІ О ДРУГІЙ НОЧІ
//  ДИКИЙ ФЛЄКС ТІЛЬКИ ТУТ 

namespace sharpz
{
    public class Task10 
    {
        public static void run()
        {
            MyComplex complex = new MyComplex();
            // complex.InputFromFile(Path.GetFullPath("Task 10/complex.txt"));
            complex.InputFromTerminal();
        }

        // public interface IMyComplexIndex
        // {
        //     double this[string index];
        // }

        // public public interface Iinputable
        // {
        //     void InputFromTerminal();
        //     void InputFromFile(pathToFile);
        // }

        public class MyComplex
        {
            private double real, imaginary;

            public MyComplex(double a=0, double b=0)
            {
                this.real = a;
                this.imaginary = b;
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
                //(A+Bi)/(C+Di) = (A*B) + (C*D)i
                // a.real*b.real == (A*B)
                // a.imaginary*b.imaginary == (C*D)i 
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
                var complexPattern = @"(\s*[\+\-]?\s*\d+\,?\d*\s*)([\+\-]\s*\d+\,?\d+i)";
                var matches = Regex.Match(str, complexPattern);

                if (matches.Groups.Count < 3) throw new Exception("Not a complex number");

                string real = matches.Groups[1].Value;
                string imaginary = matches.Groups[2].Value;
                //remove 'i' from imaginary part
                real = Regex.Replace(real, @"\s+", String.Empty);
                imaginary = Regex.Replace(imaginary, @"\s+|i", String.Empty);
                
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