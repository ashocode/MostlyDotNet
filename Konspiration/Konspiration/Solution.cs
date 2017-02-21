
namespace Konspiration
{
    using System;
    using System.IO;

    class Solution
    {
        static void Main()
        {
            string codeInput = File.ReadAllText("../../cat_code.txt");

            SplitMethods(codeInput);
        }

        static void SplitMethods(string text)
        {
            int findStatic = 0;


            while (findStatic != -1)
            {
                string takeMethodSubString = string.Empty;

                findStatic = text.IndexOf("static", findStatic + 1);

                if (findStatic == -1)
                {
                    break;
                }

                int methodBraket = text.IndexOf('(', findStatic);
                string fromStaticToBraket = text.Substring(findStatic, methodBraket - findStatic);

                fromStaticToBraket = fromStaticToBraket.TrimEnd(' ');

                int spaceBeforeMethod = fromStaticToBraket.LastIndexOf(' ');

                takeMethodSubString = fromStaticToBraket.Substring(spaceBeforeMethod + 1, fromStaticToBraket.Length - spaceBeforeMethod - 1);

                Console.Write(takeMethodSubString + " -> ");

                int firstCurrly = text.IndexOf('{', methodBraket);
                int nextStatic = text.IndexOf("static", findStatic + 1);
                int lastCurrly = 0;

                if (nextStatic == -1)
                {
                    lastCurrly = text.LastIndexOf('}');
                }
                else
                {
                    lastCurrly = text.LastIndexOf('}', nextStatic);
                }

                string method = text.Substring(firstCurrly, lastCurrly - firstCurrly);

                CountMethodCalls(method);
            }
        }

        static void CountMethodCalls(string text)
        {
            int methodCallBraket = 0;
            int startFrom = 0;
            int numberOfMethodCalls = 0;
            string methodCall = string.Empty;

            while (methodCallBraket != 1)
            {

                methodCallBraket = text.IndexOf('(', startFrom);

                if (methodCallBraket == -1)
                {
                    break;
                }

                startFrom = methodCallBraket + 1;

                bool capital = true;
                int count = 0;

                while (capital)
                {
                    if ((text[methodCallBraket - count - 1] >= 65 && text[methodCallBraket - count - 1] <= 90)
                        || (text[methodCallBraket - count - 1] >= 97 && text[methodCallBraket - count - 1] <= 122))
                    {
                        count += 1;
                    }
                    else if (text[methodCallBraket - count - 1] == ' ')
                    {
                        count += 1;
                        if (text[methodCallBraket - count - 2] != ' ')
                        {
                            count += 1;

                            if (text[methodCallBraket - count - 3] == ' ')
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > 0)
                {
                    string takeMethodSubString = text.Substring(methodCallBraket - count, count);
                    string previous = text.Substring(methodCallBraket - count - 1, 1);
                    if ((previous == ".") || (previous == " ") || (previous == "(") || (previous == "\t") && (takeMethodSubString[0] >= 65 && takeMethodSubString[0] <= 90))
                    {
                        numberOfMethodCalls += 1;
                        methodCall = methodCall + takeMethodSubString.Replace(" ", "") + ", ";
                    }
                }
            }

            if (numberOfMethodCalls != 0)
            {
                Console.Write(numberOfMethodCalls + " -> " + methodCall.Remove((methodCall.Length - 2), 2));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("None");
            }

        }
    }
}
