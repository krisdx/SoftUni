using System;

class CrossingSequences //-k.d
{
    static void Main()
    {
        long trib1 = long.Parse(Console.ReadLine());
        long trib2 = long.Parse(Console.ReadLine());
        long trib3 = long.Parse(Console.ReadLine());
        long spiralSrart = long.Parse(Console.ReadLine());
        long spiralStep = long.Parse(Console.ReadLine());

        long spiralResult = spiralSrart;
        long tribResult = 0;
        bool[] tribPositions = new bool[1000000 + 1];
        tribPositions[trib1] = true;
        tribPositions[trib2] = true;
        tribPositions[trib3] = true;

        while (tribResult <= 1000000)
        {
            tribResult = trib1 + trib2 + trib3;
            trib1 = trib2;
            trib2 = trib3;
            trib3 = tribResult;
            if (tribResult > 1000000)
            {
                break;
            }
            tribPositions[tribResult] = true;
        }

        bool solutionFound = false;
        long counter = 1;
        for (int i = 1; i <= 100000; i++)
        {
            if (spiralResult > 1000000 || spiralSrart > 1000000)
            {
                break;
            }

            if (tribPositions[(ulong)spiralSrart] == true)
            {
                Console.WriteLine(spiralSrart);
                solutionFound = true;
                break;
            }

            spiralSrart += spiralStep * (counter / 2);
            counter++;
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}