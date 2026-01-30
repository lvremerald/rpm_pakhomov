using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Program
    {
        class Building // здание
        {
            string purpose = "Здание";
            int floors = 1;
            double area = 0;
            public Building(string p, int f, double a)
            {
                purpose = p;
                floors = f;
                area = a;
            }
            public void Display_Info()
            {
                Console.WriteLine($"{purpose}, этажей - {floors}, площадь - {area} м^2");
            }
        }
        class House : Building
        {
            double inner_area = 0;
            int rooms = 1;
            public House(string p, int f, double a, double i_a, int r) : base(p, f, a)
            {
                inner_area = i_a;
                rooms = r;
            }
        }

        class ApartmentComplex : Building
        {
            int apartments = 1;
            public ApartmentComplex(string p, int f, double a, int ac) : base(p, f, a)
            {
                apartments = ac;
            }
        }
        static void Main(string[] args)
        {
            House building1 = new House("Частный дом", 2, 121, 100, 3);
            ApartmentComplex building2 = new ApartmentComplex("ЖК", 10, 400, 80);

            building1.Display_Info();
            building2.Display_Info();

            Console.ReadKey();
        }
    }
}
