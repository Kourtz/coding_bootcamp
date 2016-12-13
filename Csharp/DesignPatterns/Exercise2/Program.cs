using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise2
{
    class Program
    {
        public class Utilities
        {
            public string text;
            StreamReader readfile;
            StreamWriter writefile;

            public void Read(StreamReader file)
            {
                readfile = file;
                text = file.ReadLine();
                while (text != null)
                {
                    Console.WriteLine(text);
                    text = file.ReadLine();
                }
                file.Close();
                Console.ReadLine();
            }

            public string GetString(StreamReader file)
            {
                readfile = file;
                text = file.ReadToEnd();
                return text;              
            }

            public void Write(StreamWriter note,string words)
            {
                writefile = note;
                text = words;
                note.WriteLine(words);
                note.Close();
            }

        }

        static void Main(string[] args)
        {
            Utilities test = new Utilities();

            //StreamWriter note2 = new StreamWriter("C:\\Hello.txt", true);
            //test.Write(note2, "Hello");

            //StreamReader note1 = new StreamReader("C:\\Hello.txt");
            //test.Read(note1);

            StreamReader note3 = new StreamReader("C:\\Hello.txt");
            test.GetString(note3);
            Console.WriteLine(test.text);
            Console.ReadLine();

        }
    }
}
