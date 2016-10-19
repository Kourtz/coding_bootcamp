using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    class Program
    {
        public abstract class Animals
        {
            public string Name {get; set;}
            public int Age { get; protected set; }
            public int Gender { get; set; }
            protected string Sound;

            public Animals(string name,int age,int gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }

            public abstract string MakeSound();   
        }


        public class Dog : Animals
        {
            public Dog(string name, int age, int gender): base(name,age,gender)
            {
            }
            public override string MakeSound()
            {
                return "Wuf";
            }
          
        }

        public class Cat : Animals
        {
            public Cat(string name, int age, int gender): base(name,age,gender)
            {
            }
            public override string MakeSound()
            {
                return "Niaou";
            }
        }

        public class Lion : Animals
        {
            public Lion(string name, int age, int gender): base(name,age,gender)
            {
            }
            public override string MakeSound()
            {
                return "grrrr";
            }
        }

        static void Main(string[] args)
        {
            Animals[] animals = new Animals[]
            {
                new Dog("Lucy",5,1),
                new Cat("Aron",1,0),
                new Lion("Simpa",1,0)
            };

            for (int i=0; i< animals.Length; i++)
            {
                Console.WriteLine(animals[i].Name + " says\" " + animals[i].MakeSound() + "\"");
            }

            Console.ReadKey();


        }
    }
}
