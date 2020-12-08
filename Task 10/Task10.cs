using System;
using System.IO;
using System.Text.RegularExpressions;

// WE GONNA THROW A PARTY
// LET'S RUN IT UP RUN IT UP
// YEAH

// ГРАЄМОСЬ ІЗ ДЕЛЕГАТАМИ ТА ІНТЕРФЕЙСАМИ У ПРЯМОМУ ЄФІРІ О ДРУГІЙ НОЧІ
//  ДИКИЙ ФЛЄКС ТІЛЬКИ ТУТ 


// Я НАДІЮСЬ ЩО ЗДАМ ЦЕ, БО ЧЕРДАК ТЕЧЕ, НУ РОЗУМІЄТЕ ЦІ РЕГЕКСИ
// РЕАЛЬНО ОСЬ ПРЯМО ЗАРАЗ БУДУ НА ПЕРЛІ ПРОГРАМУВАТИ
// ВИ МЕНЕ НЕ ЗУПИНИТЕ

namespace sharpz
{
    
    public class Task10 
    {

        public void SpecialFunction1(string message, MyComplexBase myObj) {
            Console.WriteLine($"1. {message}: {myObj.real} + {myObj.imaginary}*i");
        }

        public void SpecialFunction2(string message, MyComplexBase myObj) {
            Console.WriteLine($"2. {message}: {myObj.real} + {myObj.imaginary}*i");
        }

        public void main() {
            MyComplexChild complex1 = new MyComplexChild();
            MyComplexChild complex2 = new MyComplexChild();

            complex1.mySetFuncOutput = this.SpecialFunction1;
            complex2.mySetFuncOutput = this.SpecialFunction2;
            // complex.InputFromFile(Path.GetFullPath("Task 10/complex.txt"));
            complex1.InputFromTerminal();
        }

        public static void run()
        {
            Task10 task = new Task10();
            task.main();
        }

        public interface IMyComplexIndex
        {
            double this[string type]{get;}
        }

        public interface Iinputable
        {
            void InputFromTerminal();
            void InputFromFile(string pathToFile);
        }

        public class MyComplexBase
        {
            public double real, imaginary;

            public delegate void SpecialOutput(string message, MyComplexBase myObj);
            public SpecialOutput mySetFuncOutput;

            public MyComplexBase(double a=0, double b=0)
            {
                this.real = a;
                this.imaginary = b;
            }

            public static MyComplexBase operator +(MyComplexBase a, MyComplexBase b)
            {
                return new MyComplexBase(a.real + b.real, a.imaginary + b.imaginary);
            }

            public static MyComplexBase operator +(MyComplexBase a, double b)
            {
                return new MyComplexBase(a.real + b, a.imaginary);
            }

            public static MyComplexBase operator +(double a, MyComplexBase b)
            {
                return new MyComplexBase(a + b.real, b.imaginary);
            }

            public static MyComplexBase operator -(MyComplexBase a)
            {
                return new MyComplexBase(a.real * -1, a.imaginary);
            }

            public static MyComplexBase operator -(MyComplexBase a, MyComplexBase b)
            {
                return new MyComplexBase(a.real - b.real, a.imaginary - b.imaginary);
            }
            
            public static MyComplexBase operator *(MyComplexBase a, MyComplexBase b)
            {
                return new MyComplexBase(a.real*b.real-a.imaginary*b.imaginary, a.imaginary*b.real-a.real*b.imaginary);
            }

            public static MyComplexBase operator /(MyComplexBase a, MyComplexBase b)
            {
                //(A+Bi)/(C+Di) = (A*B) + (C*D)i
                // a.real*b.real == (A*B)
                // a.imaginary*b.imaginary == (C*D)i 
                // NOTE (C*D)i == (Ci*Di) 
                return new MyComplexBase(a.real*b.real, a.imaginary*b.imaginary);
            }

            public void ParseComplex(string str) {
                //регекс експрешн що парсить комплексні числа (магічна вещь, я відчув шрами на спині після дебага цьої штуки)
                var complexPattern = @"(\s*[\+\-]?\s*\d+\,?\d*?\s*)([\+\-]\s*\d+\,?\d*?\*?i)";
                var matches = Regex.Match(str, complexPattern);

                if (matches.Groups.Count <= 1) {
                    Console.WriteLine("Passed invalid value or empty string, complex number is set to default - 0 + 0i");
                    this.real = 0;
                    this.imaginary = 0;
                    return;
                }
                if (matches.Groups.Count < 3) throw new Exception("Not a complex number");

                string real = matches.Groups[1].Value;
                string imaginary = matches.Groups[2].Value;
                //видаляємо "і", бо воно нам не треба, другий аргумент і так є уявною частиною, просто це покажник що 
                //що та частина ну типу регекс, так треба
                
                //прибираємо пробіли
                real = Regex.Replace(real, @"\s+", String.Empty);
                //прибираємо сміття
                imaginary = Regex.Replace(imaginary, @"\s+|i|\*", String.Empty);
                 
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

        class MyComplexChild: MyComplexBase, IMyComplexIndex, Iinputable
        {
            public void InputFromTerminal()
            {
                Console.WriteLine("Enter complex number in algebraic notation: ");
                string complexStuff = Console.ReadLine();
                this.ParseComplex(complexStuff);
                MyComplexBase newComplex = new MyComplexBase(this["realValue"], this["imaginaryValue"]);
                this.mySetFuncOutput("Варіант 7", newComplex);
            }

            public void InputFromFile(string pathToFile)
            {
                string data = File.ReadAllText(pathToFile);
                this.ParseComplex(data);
                MyComplexBase newComplex = new MyComplexBase(this["realValue"], this["imageValue"]);
                this.mySetFuncOutput("Варіант 7", newComplex);
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
        }
    }
}