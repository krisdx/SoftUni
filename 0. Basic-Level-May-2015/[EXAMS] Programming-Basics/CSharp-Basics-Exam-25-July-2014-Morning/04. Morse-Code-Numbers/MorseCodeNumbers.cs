using System;

class MorseCodeNumbers //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int nSum = 0;
        while (n > 0)
        {
            nSum += n % 10;
            n /= 10;
        }

        bool solutionFound = false;
        for (int n1 = 0; n1 <= 5; n1++)
        {
            for (int n2 = 0; n2 <= 5; n2++)
            {
                for (int n3 = 0; n3 <= 5; n3++)
                {
                    for (int n4 = 0; n4 <= 5; n4++)
                    {
                        for (int n5 = 0; n5 <= 5; n5++)
                        {
                            for (int n6 = 0; n6 <= 5; n6++)
                            {
                                int currentProduct = GetCurrentProduct(n1, n2, n3, n4, n5, n6);
                                if (currentProduct == nSum)
                                {
                                    PrintChars(n1, n2, n3, n4, n5, n6);
                                    solutionFound = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }

    private static int GetCurrentProduct(int n1, int n2, int n3, int n4, int n5, int n6)
    {
        int[] currentChars = { n1, n2, n3, n4, n5, n6 };

        int currentProduct = 1;
        for (int i = 0; i < currentChars.Length; i++)
        {
            switch (currentChars[i])
            {
                case 1: currentProduct *= 1; break;
                case 2: currentProduct *= 2; break;
                case 3: currentProduct *= 3; break;
                case 4: currentProduct *= 4; break;
                case 5: currentProduct *= 5; break;
                default: currentProduct = 0; break;
            }
        }
        return currentProduct;
    }

    private static void PrintChars(int n1, int n2, int n3, int n4, int n5, int n6)
    {
        int[] currentMorseCode = { n1, n2, n3, n4, n5, n6 };
   
        for (int i = 0; i < currentMorseCode.Length; i++)
        {
            switch (currentMorseCode[i])
            {
                case 1: Console.Write(".----" + "|"); break;
                case 2: Console.Write("..---" + "|"); break;
                case 3: Console.Write("...--" + "|"); break;
                case 4: Console.Write("....-" + "|"); break;
                case 5: Console.Write("....." + "|"); break;
            }
        }
        Console.WriteLine();
    }
}