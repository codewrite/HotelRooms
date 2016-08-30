using System;
using System.Collections.Generic;

namespace HotelRooms
{
    public class RoomDigitCalculator
    {
        /// <summary>
        /// Count of how many of each digit are required.
        /// </summary>
        /// <remarks>
        /// digitCounts[0] is the number of '0' digits are required.
        /// digitCounts[1] is the number of '1' digits are required.
        /// digitCounts[2] is the number of '2' digits are required.
        /// etc. up to '9', hence 10 entries in the array
        /// </remarks>
        private long[] digitCounts;     //One for each digit, i.e. 0 - 9.

        public void InitializeDigitCounts()
        {
            digitCounts = new long[10];
        }

        public void PrintDigitCounts(long number)
        {
            CalculateDigitCounts(number);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("{0}: {1}", i, digitCounts[i]));
            }
        }

        public long[] CalculateDigitCounts(long number)
        {
            int[] numberDigits = ConvertToDigitArray(number);

            if (numberDigits.Length > 0)
                ProcessFirstDigit(number, numberDigits);
            for (int i = 1; i < numberDigits.Length; i++)
            {
                ProcessNthDigit(number, numberDigits, i);
            }

            return digitCounts;
        }

        public void PrintDigitCountsSlow(long number)
        {
            CalculateDigitCountsSlow(number);
            Console.WriteLine("Output");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(digitCounts[i]);
                if (i < 9)
                    Console.Write(", ");
                else
                    Console.WriteLine();
            }
        }

        public long[] CalculateDigitCountsSlow(long number)
        {
            for (long i = 1; i <= number; i++)
            {
                int[] digits = ConvertToDigitArray(i);
                for (int j = 0; j < digits.Length; j++)
                {
                    digitCounts[digits[j]]++;
                }
            }
            return digitCounts;
        }

        //TODO: Does this need to be in a separate class? Maybe have a long number extender?
        private int[] ConvertToDigitArray(long number)
        {
            List<int> digitArray = new List<int>();

            while (number > 0)
            {
                int digit = (int)(number % 10);
                digitArray.Add(digit);
                number /= 10;
            }

            return digitArray.ToArray();
        }

        private void ProcessFirstDigit(long number, int[] numberDigits)
        {
            for (int i = numberDigits[0]; i > 0; i--)
            {
                digitCounts[i]++;
            }

            AddEachDigitAbove(numberDigits, 0);
        }

        private void ProcessNthDigit(long number, int[] numberDigits, int digitIndex)
        {
            for (int i = 0; i < 10; i++)
            {
                digitCounts[i] += numberDigits[digitIndex] * digitIndex * (long)Math.Pow(10, digitIndex - 1);
            }

            digitCounts[numberDigits[digitIndex]]++;

            for (int i = 1; i < numberDigits[digitIndex]; i++)
            {
                digitCounts[i] += (long)Math.Pow(10, digitIndex);
            }

            if (digitIndex == numberDigits.Length - 1)
            {
                //Last digit - don't include leading zeros
                digitCounts[0] -= NumberOfNonDisplayedZeros(digitIndex);
            }
            else
            {
                //Mid number - do include leading zeros
                AddEachDigitAbove(numberDigits, digitIndex);
                if (numberDigits[digitIndex] > 0)
                    digitCounts[0] += (long)Math.Pow(10, digitIndex);
            }
        }

        private void AddEachDigitAbove(int[] numberDigits, int digitIndex)
        {
            if (numberDigits.Length - 1 > digitIndex)
            {
                for (int i = digitIndex + 1; i < numberDigits.Length; i++)
                {
                    digitCounts[numberDigits[i]] += numberDigits[digitIndex] * (long)Math.Pow(10, digitIndex);
                }
            }
        }

        private long NumberOfNonDisplayedZeros(int digitIndex)
        {
            long blankZeros = 0;

            for (int i = 1; i < digitIndex; i++)
            {
                blankZeros += (long)Math.Pow(10, i);
            }
            return blankZeros;
        }
    }
}
