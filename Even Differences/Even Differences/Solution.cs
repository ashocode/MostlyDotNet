namespace Even_Differences
{
    using System;

    class Solution
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            long[] longNumbers = new long[numbers.Length];

            for (int j = 0; j < numbers.Length; j++)
            {
                longNumbers[j] = long.Parse(numbers[j]);
            }

            CalculateJumps(longNumbers);
        }

        static void CalculateJumps(long[] numbers)
        {
            long evenResult = 0L;

            for (int i = 1; i < numbers.Length; i++)
            {
                long firstValue = numbers[i];
                long secondValue = numbers[i - 1];

                long result = Math.Abs(firstValue - secondValue);

                if (result % 2 == 0)
                {
                    evenResult = evenResult + result;
                    i++;
                }
            }

            Console.WriteLine(evenResult);
        }
    }
}
