using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Exercise3
{
    class Program
    {
        public class Utilities
        {
            public string text;
            StreamReader readfile;
            StreamWriter writefile;
            public int count;
            public int classes;
            public int methods;

            public string GetString(StreamReader file)
            {
                readfile = file;
                text = file.ReadToEnd();
                return text;
            }

            //Regular Expressions
            public int CountLines()
            {
                count = 0;
                int start = 0;
                while((start=text.IndexOf("\n",start)) != -1)
                {
                    count++;
                    start++;
                }
                return count;
            }

            public int CountClasses()
            {
                string pattern = @"\sclass\s";
                classes = Regex.Matches(text, pattern).Count;
                return classes;
            }

            public int CountMethods()
            {
                string pattern1 = @"public\s+\w*\s+\w*\s*\(";
                string pattern2= @"private\s+\w*\s+\w*\s*\(";
                int pu_methods = Regex.Matches(text, pattern1).Count;
                int pr_methods= Regex.Matches(text, pattern2).Count;
                methods = pu_methods + pr_methods;
                return methods;
            }


            //String Comparison

            public int CountLinesInFile(StreamReader file)
            {
                count = 0;
                readfile = file;
                while ((text = file.ReadLine()) != null)
                {
                    count++;
                }
                return count;
            }


            public int CountClassesInFile(StreamReader file)
            {
                count = 0;
                readfile = file;
                while ((text = file.ReadLine()) != null)
                {
                    text = file.ReadLine();
                    if (text.Contains("class"))
                    {
                        count++;
                    }                              
                }
                return count;
            }

            public int CountMethodsInFile(StreamReader file)
            {
                count = 0;
                readfile = file;
                while ((text = file.ReadLine()) != null)
                {
                    if (text.Contains("public")&& text.Contains("(")&& text.Contains(")"))
                    {
                        count++;
                    }
                }
                return count;
            }


            //Write

            public void Write(StreamWriter note, string words)
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

            //StreamReader note1 = new StreamReader("C:\Hello.txt");
            //test.Read(note1);

            StreamReader note = new StreamReader(@"C:\Projects\DesignPatterns\Exercise4\Exercise3\Program.cs");
            test.GetString(note);

            //test.CountLines();
            //test.CountClasses();
            test.CountMethods();
            //test.CountClassesInFile(note4);
            //test.CountMethodsInFile(note);
            Console.WriteLine(test.methods);

            Console.ReadLine();

        }
    }
}
