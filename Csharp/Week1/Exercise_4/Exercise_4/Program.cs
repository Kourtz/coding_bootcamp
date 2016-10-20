using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Program
    {
        public class Student: IComparable<Student>
        {
            public string Name;
            public int Mark;

            public Student()
            {
                Name = "No name";
                Mark = 0;
            }

            public Student(string name,int mark)
            {
                Name = name;
                Mark = mark;
            }

            public int CompareTo(Student s)
            {
                if (this.Mark < s.Mark)
                {
                    return -1;
                }
                else if (this.Mark > s.Mark)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
            new Student("Christos", 10),
            new Student("Giorgos", 7),
            new Student("Giannis", 5),
            new Student("Maria", 6),
            new Student("Kwstas", 7),
        };

            List<Student> students2 = new List<Student>();
            students2.Add(new Student("Christos", 10));
            students2.Add(new Student("Giorgos", 7));
            students2.Add(new Student("Giannis", 5));
            students2.Add(new Student("Maria", 6));
            students2.Add(new Student("Kwstas", 7));

            foreach (Student s in students2)
            {
                Console.WriteLine(s.Name + " got " + s.Mark);
            }
            Console.WriteLine();

            students2.Sort();
            foreach (Student s in students2)
            {
                Console.WriteLine(s.Name + " got " + s.Mark);
            }

            
            Console.ReadKey();
        }
    }
}
