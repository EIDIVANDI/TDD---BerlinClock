using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDBerlinClockBL;

namespace TDD___BerlinClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The BerlinClock Algo");
            Console.WriteLine("To achieve more information abot the Berlin Clock Follow the link in below");
            Console.WriteLine("http://agilekatas.co.uk/katas/BerlinClock-Kata");

            Console.WriteLine("Enter Time in the format HH:MM:SS ");
            var tm = Console.ReadLine();

            Console.WriteLine("\nYour result IS");
            Console.ReadLine();

            var tmp = tm.Split(':');

            TDDBerlinClock clock = new TDDBerlinClock();

            clock.GenerateBerlinTime(
                   new DateTime(2017, 10, 10, int.Parse(tmp[0]), int.Parse(tmp[1]), int.Parse(tmp[2]), 0, DateTimeKind.Utc)
                    );

            Console.WriteLine(clock.ToString());

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
