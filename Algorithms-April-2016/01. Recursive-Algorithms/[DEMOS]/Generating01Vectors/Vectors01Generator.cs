namespace Generating01Vectors
{
    using System;

    public class Vectors01Generator
    {
        private static int[] vector;

        public static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            vector = new int[n];
            
            // Forward recursion
            Gen01Forward(0);

            Console.WriteLine();

            // Backward recursion
            Gen01Backward(n - 1);
        }

        static void Gen01Forward(int currentIndex)
        {
            if (currentIndex >= vector.Length)
            {
                Print();
            }
            else
            {
                for (int num = 0; num <= 1; num++)
                {
                    vector[currentIndex] = num;
                    Gen01Forward(currentIndex + 1);
                }
            }
        }

        static void Gen01Backward(int currentIndex)
        {
            if (currentIndex < 0)
            {
                Print();
            }
            else
            {
                for (int num = 0; num <= 1; num++)
                {
                    vector[currentIndex] = num;
                    Gen01Backward(currentIndex - 1);
                }
            }
        }

        static void Print()
        {
            foreach (int num in vector)
            {
                Console.Write("{0} ", num);
            }

            Console.WriteLine();
        }
    }
}