using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Program
    {
        class Fraction: IComparable<Fraction>
        {
            private int numerator;
            private int denominator;
            public decimal result //6
            {
                get { return (decimal)numerator / (decimal)denominator; }
            }

            public int Numerator
            {
                get { return numerator; }
                set { numerator = value; }
            }

            public int Denominator
            {
                get { return denominator; }
                set
                {
                    if (value == 0) { }
                    else { denominator = value; }
                }
            }

            //constructor
            public Fraction(int x,int y)
            {
                numerator = x;
                denominator = y;
            }

            //3
            public override string ToString()
            {
                return $"{this.Numerator}/{this.Denominator}";
            }

            //4
            public static Fraction operator *(Fraction x,Fraction y)
            {
                return new Fraction(x.numerator * y.numerator, x.denominator * y.denominator);
            }

            //5
            public static Fraction Parse(string str)
            {
                string[] split = str.Split('/');
                if (split.Length != 2) { }

                int x;
                if (!Int32.TryParse(split[0],out x)) { }
                                            
                int y;
                if (!Int32.TryParse(split[1], out y)) { }

                return new Fraction(x, y);
            }


            //7
            public int CompareTo(Fraction x)
            {
                if (this.result < x.result) { return -1; }
                else if (this.result > x.result) { return 1; }
                else { return 0; }
            }

            //8

            public void Cancel()
            {
                int min = Math.Min(this.numerator, this.denominator);
                for (int i = min; i >= 2; i--)
                {
                    if((this.numerator%i)==0 && (this.denominator % i) == 0)
                    {
                        this.numerator /= i;
                        this.denominator /= i;
                    }
                }
            }         
        }



        static void Main(string[] args)
        {
            //1-4,6
            Fraction a = new Fraction(1, 4);
            Fraction b = new Fraction(7, 8);
            Fraction c = a * b;
            Console.WriteLine(a);
            Console.WriteLine(a.result);
            Console.WriteLine(c);

            //5
            Fraction d = Fraction.Parse("21/33");
            Console.WriteLine(d);
            Console.WriteLine();

            //7
            List<Fraction> list= new List<Fraction>() { a, b, c, d };
            foreach(Fraction x in list) { Console.Write(x+(" ")); }
            Console.WriteLine();

            list.Sort();
            Console.WriteLine("Sort: ");
            foreach(Fraction x in list) { Console.Write(x + (" ")); }
            Console.WriteLine();
            Console.WriteLine();

            //8
            Fraction f = new Fraction(40, 60);
            Console.Write(f + "->");
            f.Cancel();
            Console.WriteLine(f);




            Console.ReadKey();

        }
    }
}
