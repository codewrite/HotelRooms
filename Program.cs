using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input");
            string numberStr = Console.ReadLine();
            long number;
            if (Int64.TryParse(numberStr, out number))
            {
                Console.WriteLine("Output");
                RoomDigitCalculator digitCalc = new RoomDigitCalculator();
                digitCalc.InitializeDigitCounts();
                //digitCalc.SlowPrintDigitCounts(number);
                digitCalc.PrintDigitCounts(number);

            }
            else
            {
                Console.WriteLine("Error parsing input, only digits are allowed");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
