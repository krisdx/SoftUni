using System;

class DrunkAni
{
    static void Main()
    {
        int cabins = int.Parse(Console.ReadLine());

        string numberOfMoves = Console.ReadLine();
        int currentPosition = 0;
        while (numberOfMoves != "Found a free one!")
        {
            currentPosition = (currentPosition + int.Parse(numberOfMoves)) % cabins;

            numberOfMoves = Console.ReadLine();
        }
    }
}