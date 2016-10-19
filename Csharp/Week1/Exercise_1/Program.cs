using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
      
    class Program
    {
        class ComplexNum
        {
            public double a;
            public double b;

            public ComplexNum()
            {
                a = 0;
                b = 0;
            }

            public ComplexNum(double x)
            {
                a = x;
                b = 0;
            }

            public ComplexNum(double x, double y)
            {
                a = x;
                b = y;                
            }

            // Praxeis #1
            public ComplexNum Add(ComplexNum x)
            {
                double r = this.a + x.a;
                double i = this.b + x.b;
                return new ComplexNum(r, i);
            }
            
            //#2
            public static ComplexNum Add(ComplexNum x, ComplexNum y)
            { 
                ComplexNum sum = new ComplexNum(x.a + y.a, x.b + y.b);
                return sum;
            }

            //#3
            public static ComplexNum operator +(ComplexNum x, ComplexNum y)
            {
                return new ComplexNum(x.a + y.a, x.b + y.b);
            }

            public override string ToString()
            {
                return $"({this.a}+ {this.b}i)";

                }
         }


        static void Main(string[] args)

        {


            ComplexNum z1 = new ComplexNum(5, 6);
            ComplexNum z2 = new ComplexNum(7, -3);
            ComplexNum sum1 = z1.Add(z2);
            ComplexNum sum2 = ComplexNum.Add(z1, z2);
            ComplexNum sum3 = z1 + z2;

            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.WriteLine(sum3);
            Console.ReadKey();

        }
    }
}


