
namespace Lover_Of_3
{
    using System;
    using System.IO;

    class Solution
    {
        static void Main()
        {
            string[] size = Console.ReadLine().Split(' ');
            int moves = int.Parse(Console.ReadLine());
            int height = int.Parse(size[0]);
            int width = int.Parse(size[1]);
            string[] moveCommands = new string[moves];

            int[,] matrix = new int[height, width];

            for (int i = 0; i < moves; i++)
            {
                moveCommands[i] = Console.ReadLine();
            }

            int[,] field = CreateMatrix(height, width);

            PrintMatrix(field, height, width);

            CalculateSumOfMoves(moveCommands, field, moves, height, width);
        }

        static int[,] CreateMatrix(int height, int width)
        {
            int[,] matrix = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = Math.Abs(i - height + 1) * 3 + j * 3;
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix, int height, int width)
        {
            using (TextWriter tw = new StreamWriter("../../matrix.txt"))
            {
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        if (i >= 0)
                        {
                            tw.Write(" ");
                        }
                        tw.Write(matrix[j, i]);
                    }
                    tw.WriteLine();
                }
            }
        }

        static void CalculateSumOfMoves(string[] text, int[,] field, int moves, int height, int width)
        {
            string currentMove = string.Empty;
            int currentValue = 0;
            int sum = 0;
            int maxSize = Math.Min(height, width);
            int coordinateX = height - 1;
            int coordinateY = 0;

            for (int i = 0; i < moves; i++)
            {
                currentMove = text[i];
                int space = currentMove.LastIndexOf(' ');
                int steps = int.Parse(currentMove.Substring(space + 1, (currentMove.Length - 1 - space)));
                int maxSteps = steps - 1;

                if (currentMove.Contains("UR") || currentMove.Contains("RU"))
                {
                    for (int j = 0; j < maxSteps; j++)
                    {
                        if ((coordinateY < width - 1) && (coordinateX > 0))
                        {
                            coordinateX -= 1;
                            coordinateY += 1;
                            currentValue = field[coordinateX, coordinateY];
                            field[coordinateX, coordinateY] = 0;
                            sum = sum + currentValue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (currentMove.Contains("UL") || currentMove.Contains("LU"))
                {
                    for (int j = 0; j < maxSteps; j++)
                    {
                        if ((coordinateX > 0) && (coordinateY > 0))
                        {
                            coordinateX -= 1;
                            coordinateY -= 1;
                            currentValue = field[coordinateX, coordinateY];
                            field[coordinateX, coordinateY] = 0;
                            sum = sum + currentValue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (currentMove.Contains("DL") || currentMove.Contains("LD"))
                {
                    for (int j = 0; j < maxSteps; j++)
                    {
                        if ((coordinateX < height - 1) && (coordinateY > 0))
                        {
                            coordinateX += 1;
                            coordinateY -= 1;
                            currentValue = field[coordinateX, coordinateY];
                            field[coordinateX, coordinateY] = 0;
                            sum = sum + currentValue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (currentMove.Contains("DR") || currentMove.Contains("RD"))
                {
                    for (int j = 0; j < maxSteps; j++)
                    {
                        if ((coordinateX < height - 1) && (coordinateY < width - 1))
                        {
                            coordinateX += 1;
                            coordinateY += 1;
                            currentValue = field[coordinateX, coordinateY];
                            field[coordinateX, coordinateY] = 0;
                            sum = sum + currentValue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
