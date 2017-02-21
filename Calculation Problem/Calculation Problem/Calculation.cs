
namespace Calculation_Problem
{
    using System;

    class CatsDecryption
    {
        static void Main()
        {
            string input = Console.ReadLine().ToLower();
            string[] splitToWords = input.Split(' ');

            int value = DecodeCatsMessages(splitToWords);
            string convertedString = ConvertToNineteen(DecodeCatsMessages(splitToWords));
            Console.WriteLine(convertedString + " = " + value);

        }

        static int DecodeCatsMessages(string[] text)
        {
            string word = string.Empty;
            double sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                word = text[i];
                for (int j = 0; j < word.Length; j++)
                {
                    int power = word.Length - j;
                    int number = word[j] - 97;
                    sum = sum + (number * Math.Pow(23, word.Length - j - 1));
                }
            }

            int result = Convert.ToInt32(sum);
            return result;
        }

        static string ConvertToNineteen(int number)
        {
            string resultStr = string.Empty;
            if (number == 0)
            {
                resultStr = "a";
            }

            while (number > 0)
            {
                char ch = (char)((number % 23) + 'a');
                resultStr = ch.ToString() + resultStr;
                number /= 23;
            }

            return resultStr;
        }
    }
}

