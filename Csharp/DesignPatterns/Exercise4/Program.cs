using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace Exercise4
{
    class Program
    {
        public class TestFile
        {
            public string path;          
            public GetNumeric strategy;

            public TestFile(string file)
            {
                path = file;
            }

            public GetNumeric Count(GetNumeric algorithm)
            {
                strategy = algorithm;
                algorithm.readfile = new StreamReader(path);
                algorithm.text = algorithm.readfile.ReadToEnd();
                algorithm.path = path;
                algorithm.CountLines();
                algorithm.CountClasses();
                algorithm.CountMethods();
                return strategy;
            }
        }
          
        public abstract class GetNumeric
        {
            public string text;
            public string path;
            public StreamReader readfile;
            public StreamWriter writefile;
            public int lines;
            public int classes;
            public int methods;
            public abstract int CountLines();
            public abstract int CountClasses();
            public abstract int CountMethods();    
        }


        public class Method1:GetNumeric  //REGULAR EXPRESSIONS
        {
   
            //LINES
            public override int CountLines()
            {

                lines = 0;
                int start = 0;
                while ((start = text.IndexOf("\n", start)) != -1)
                {
                    lines++;
                    start++;
                }
                return lines;
            }
            //CLASSES
            public override int CountClasses()
            {
                string pattern= @"\sclass\s";
                classes = Regex.Matches(text, pattern).Count;
                return classes;
            }
            //METHODS
            public override int CountMethods()
            {
                string pattern1 = @"public\s+\w*\s+\w*\s+\w*\s*\(";
                string pattern2 = @"public\s+\w*\s+\w*\s*\(";
                string pattern3= @"public\s+\w*\s*\(";
                int pu_methods = Regex.Matches(text, pattern1).Count;
                int pu_methods2 = Regex.Matches(text, pattern2).Count;
                int pu_methods3= Regex.Matches(text, pattern3).Count;
                methods = pu_methods + pu_methods2+pu_methods3;
                return methods;
            }

        }

        public class Method2 : GetNumeric  //STRING COMPARISON
        {
            string codeline;
            //LINES
            public override int CountLines()
            {
                lines = 0;
                readfile = new StreamReader(path);
                while ((codeline=readfile.ReadLine()) != null)
                {
                    lines++;
                }
                return lines;
            }
            //CLASSES
            public override int CountClasses()
            {
                classes = 0;
                readfile = new StreamReader(path);
                while ((codeline = readfile.ReadLine()) != null)
                {
                    if (codeline.Contains("class "))
                    {
                        codeline = readfile.ReadLine();
                        classes++;
                    }
                }
                return classes;
            }
            //METHODS
            public override int CountMethods()
            {
                methods = 0;
                readfile = new StreamReader(path);
                while ((codeline = readfile.ReadLine()) != null)
                {
                    if (codeline.Contains("public") && codeline.Contains("(") && codeline.Contains(")"))
                    {
                        codeline = readfile.ReadLine();
                        methods++;
                    }
                }
                return methods;
            }

        }

        static void Main(string[] args)
        {
            TestFile test = new TestFile(@"C:\Users\xkour\OneDrive\Documents\Visual Studio 2015\Projects\DesignPatterns\Exercise4\Exercise4\Program.cs");

            test.Count(new Method2());

            Console.WriteLine(test.strategy.methods);

            Console.ReadLine();
        }
    }
}
