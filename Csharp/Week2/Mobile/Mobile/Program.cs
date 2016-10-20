using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    class Program
    {
        static void Main(string[] args)
        {

            Device Ip = Device.Iphone7();
            Device Sam =Device.Samsung_S7();
            Console.WriteLine(Sam.Screen.resolution.Width);

            Device a = new Device("Asus", "Zenfone 2", 300, OsType.Android, new Screen(new Resolution(1920, 1080), 500), new Battery("Li-on", 800));

            a.Usage.NewCall(Calltype.Incoming);
            Console.WriteLine("Call Started...");
            System.Threading.Thread.Sleep(5000);
            a.Usage.EndCall();
            Console.WriteLine("Call Ended");
            Console.WriteLine();

            a.Usage.NewCall(Calltype.Outgoing);
            Console.WriteLine("Call Started...");
            System.Threading.Thread.Sleep(10000);
            a.Usage.EndCall();
            Console.WriteLine("Call Ended");

            Console.WriteLine(a.Usage);




            Console.ReadKey();
        }
    }
}
