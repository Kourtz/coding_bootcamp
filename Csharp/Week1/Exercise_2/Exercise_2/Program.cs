using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    class Program
    {
        public class Coffee
        {
            //enumerations
            public enum CoffeeType
            {
                Small = 100,
                Normal = 150,
                Double = 300
            }

            public CoffeeType Type { get; private set; }

            //Constructor
            public Coffee(CoffeeType t)
            {
                Type = t;
            }
           
            public string Print()
            {
                return $"{Type} coffee is {(int)Type} ml.";
            }
        }

        public class Order
        {
            //List containing items of type Coffee
            private List<Coffee> items = new List<Coffee>();

            //add coffees
            public void Add(Coffee c)
            {
                items.Add(c);
            }

            //cost
            public double CalculateCost()
            {
                double cost = 0;
                foreach (Coffee c in items)
                {
                    switch (c.Type)
                    {
                        case Coffee.CoffeeType.Small:
                            cost += 0.5;
                            break;
                        case Coffee.CoffeeType.Normal:
                            cost += 1.5;
                            break;
                        case Coffee.CoffeeType.Double:
                            cost += 2.5;
                            break;
                        default:
                            break;
                    }
                }
                return cost;
            }
        }

        static void Main(string[] args)
        {
            Coffee c1 = new Coffee(Coffee.CoffeeType.Small);
            Console.WriteLine(c1.Print());

            Order order = new Order();
            order.Add(c1);
            order.Add(new Coffee(Coffee.CoffeeType.Double));
            order.Add(new Coffee(Coffee.CoffeeType.Small));
            order.Add(new Coffee(Coffee.CoffeeType.Normal));
            order.Add(new Coffee(Coffee.CoffeeType.Double));
            order.Add(new Coffee(Coffee.CoffeeType.Double));
            Console.WriteLine(order.CalculateCost());
            Console.ReadKey();

        }
    }
}
