using System;

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
                this.imaginary = double.Parse(Console.ReadLine());
                this.real = double.Parse(Console.ReadLine());
            }

            public override string ToString()
            {
                return this.real + "+" + this.imaginary + "*i";
            }
        }
    }
}