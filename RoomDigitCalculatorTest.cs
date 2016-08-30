using System;
using System.Linq;
using NUnit.Framework;

namespace HotelRooms
{
    [TestFixture]
    class RoomDigitCalculatorTest
    {
        [TestCase(1, new long[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase(2, new long[] { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase(5, new long[] { 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 })]
        [TestCase(9, new long[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(20, new long[] { 2, 12, 3, 2, 2, 2, 2, 2, 2, 2 })]
        [TestCase(25, new long[] { 2, 13, 9, 3, 3, 3, 2, 2, 2, 2 })]
        [TestCase(30, new long[] { 3, 13, 13, 4, 3, 3, 3, 3, 3, 3 })]
        [TestCase(35, new long[] { 3, 14, 14, 10, 4, 4, 3, 3, 3, 3 })]
        [TestCase(90, null)]
        [TestCase(99, null)]
        [TestCase(100, null)]
        [TestCase(105, null)]
        [TestCase(113, null)]
        [TestCase(201, null)]
        [TestCase(210, null)]
        [TestCase(998, null)]
        [TestCase(999, null)]
        [TestCase(1000, null)]
        [TestCase(1001, null)]
        [TestCase(2000, null)]
        [TestCase(2010, null)]
        [TestCase(9999, null)]
        [TestCase(12009, null)]
        [TestCase(30091, null)]
        [TestCase(59999, null)]
        [TestCase(99099, null)]
        [TestCase(999999, null)]
        [TestCase(1000000, null)]
        public void givenNumberOfRoomsCheckExpectedDigitCounts(long numberOfRooms, long[] expectedDigitCounts)
        {
            RoomDigitCalculator digitCalc = new RoomDigitCalculator();

            if (expectedDigitCounts == null)
            {
                digitCalc.InitializeDigitCounts();
                expectedDigitCounts = digitCalc.CalculateDigitCountsSlow(numberOfRooms);
            }

            digitCalc.InitializeDigitCounts();
            long[] actualDigitCounts = digitCalc.CalculateDigitCounts(numberOfRooms);

            //Note: SequenceEqual requires .NET 3.5 or above, for .NET 2.0 I would write a method to compare the arrays
            if (!expectedDigitCounts.SequenceEqual(actualDigitCounts))
            {
                Console.Write(string.Format("Number Of Rooms = {0}, ", numberOfRooms));
                Console.Write("Expected = ");
                for (int i = 0; i < expectedDigitCounts.Length; i++)
                {
                    Console.Write(expectedDigitCounts[i]);
                    Console.Write(" ");
                }
                Console.Write("Actual = ");
                for (int i = 0; i < actualDigitCounts.Length; i++)
                {
                    Console.Write(actualDigitCounts[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Assert.AreEqual(expectedDigitCounts, actualDigitCounts);
        }
    }
}
