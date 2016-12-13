using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {

        interface IObservable
        {
            void changeTime(DateTime date1,DateTime date2);
            void NotifyAll();
            void AddObserver(Observer observer);
        }

        interface IObserver
        {
            void Update();
        }

        public class Course : IObservable
        {
            public string name;
            public DateTime Startdate;
            public DateTime Enddate;
            public List<Observer> Observers;

            public void changeTime(DateTime date1, DateTime date2)
            {
                Startdate = date1;
                Enddate = date2;
            }

            public void AddObserver(Observer observer)
            {
                Observers.Add(observer);
            }

            public void NotifyAll()
            {
                foreach(IObserver observer in Observers)
                {
                    observer.Update();
                }
            }

        }

        public class Observer: IObserver
        {
            public string Name;
            public int age;
            public void Update()
            {

            }
        }

        public class Student : Observer
        {

        }
        public class Organizer : Observer
        {

        }
        public class Instructor : Observer
        {

        }



        static void Main(string[] args)
        {

            Course CodingBootcamp = new Course();
            Observer student = new Student();
            Instructor instructor = new Instructor();
            Organizer organizer = new Organizer();

            CodingBootcamp.AddObserver(student);
            CodingBootcamp.AddObserver(instructor);
            CodingBootcamp.AddObserver(organizer);

            CodingBootcamp.changeTime(DateTime.Now, DateTime.Now.AddHours(1));

            CodingBootcamp.NotifyAll();
    

        }
    }
}
