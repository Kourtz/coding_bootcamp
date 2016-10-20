using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    enum OsType
    {
        Android,
        iOS,
        Windows
    }

    class Device
    {
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
        public decimal Price { get; private set; }
        public Screen Screen { get; private set; }
        public Battery Battery { get; private set; }
        public OsType OS { get; private set; }
        public Usage Usage { get; private set; }

   
    public Device(string model,string manufacturer,decimal price,OsType os, Screen screen,Battery battery)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            OS = os;
            Screen = screen;
            Battery = battery;
            Usage = new Usage();
        }

        public static Device Samsung_S7()
        {
            string Model ="S7";
            string Manufacturer = "Samsung";
            decimal Price = 600;
            OsType OS = OsType.Android;
            Screen Screen = new Screen(new Resolution(1440,2560), 577);
            Battery Battery = new Battery(" Li-Ion", 3000);

            return new Device( Model,  Manufacturer, Price, OS, Screen, Battery);
        }

        public static Device Iphone7()
        {
            string Model = "Iphone7";
            string Manufacturer = "Apple";
            decimal Price = 1000;
            OsType OS = OsType.iOS;
            Screen Screen = new Screen(new Resolution(750, 1334), 326);
            Battery Battery = new Battery(" Li-Ion", 1960);

            return new Device(Model, Manufacturer, Price, OS, Screen, Battery);
        }




    }
}
