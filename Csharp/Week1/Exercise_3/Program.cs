using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Program
    {
        public static class Utilities
        {
            //einai static giati einai san math px
            public static void Swap<T>(ref T a,ref T b)
            {
                T temp = a;
                a =b;
                b =temp;
            }
        }

        static void Main(string[] args)
        {        
            int a = 5;
            int b = 10;
            Utilities.Swap(ref a, ref b);

            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
