using System;

namespace PR_10
{
    internal class Program
    {
        static void Main(string [] args)
        {
            Console.Title = "Практическая работа № 10";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");

            try
            {
                const int M = 4, N = 3;
                int[,] matrix = new int[M, N];
                Random rand = new Random();

                // Заполнение матрицы случайными числами в диапазоне [-27, 38]
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        matrix[i, j] = rand.Next(-27, 39);
                    }
                }

                // Поиск наибольшего нечетного числа
                int? maxOdd = null;
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (matrix[i, j] % 2 != 0)
                        {
                            if (maxOdd == null || matrix[i, j] > maxOdd)
                                maxOdd = matrix[i, j];
                        }
                    }
                }

                // Вывод матрицы с выделением найденного элемента
                Console.WriteLine("Матрица:");
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (maxOdd.HasValue && matrix[i, j] == maxOdd.Value)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(matrix[i, j] + "\t");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write(matrix[i, j] + "\t");
                        }
                    }
                    Console.WriteLine();
                }

                if (maxOdd.HasValue)
                    Console.WriteLine($"Наибольшее нечетное число: {maxOdd.Value}");
                else
                    Console.WriteLine("Нечетных чисел в матрице не найдено.");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Что-то пошло не так. {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}

