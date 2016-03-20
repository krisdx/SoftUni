using System;
using System.Linq;

class PossibleTriangles
{
    static void Main()
    {
        string inputSidesOfTriangle = Console.ReadLine();
        bool solutionFound = false;
        while (inputSidesOfTriangle != "End")
        {
            decimal[] triangleSides = inputSidesOfTriangle.Split().Select(decimal.Parse).ToArray();
            Array.Sort(triangleSides);

            bool canFormATriangle = triangleSides[0] + triangleSides[1] > triangleSides[2];
            if (canFormATriangle)
            {
                Console.WriteLine("{0:f2}+{1:f2}>{2:f2}", triangleSides[0], triangleSides[1], triangleSides[2]);
                solutionFound = true;
            }

            inputSidesOfTriangle = Console.ReadLine();
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}