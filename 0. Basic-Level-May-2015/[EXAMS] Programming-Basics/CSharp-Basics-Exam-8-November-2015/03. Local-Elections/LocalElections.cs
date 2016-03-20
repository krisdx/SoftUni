using System;

public class LocalElectronics
{
    public static void Main()
    {
        int totalNumberOfCandidates = int.Parse(Console.ReadLine());
        int numberOfVote = int.Parse(Console.ReadLine());
        char votingSymbol = char.Parse(Console.ReadLine());

        Console.WriteLine(new string('.', 13));
        for (int i = 1; i <= totalNumberOfCandidates; i++)
        {
            if (i == numberOfVote)
            {
                DrawSelectedBallot(i, votingSymbol);
            }
            else
            {
                DrawBallot(i);
            }
            Console.WriteLine(new string('.', 13));
        }
    }

    private static void DrawSelectedBallot(int numberOfBallot, char votingSymbol)
    {
        if (votingSymbol == 'x' || votingSymbol == 'X')
        {
            Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
            Console.WriteLine(@"{0}|.\./.|{0}", new string('.', 3));
            Console.WriteLine("{0}.|..X..|{1}", numberOfBallot.ToString().PadLeft(2, '0'), new string('.', 3));
            Console.WriteLine(@"{0}|./.\.|{0}", new string('.', 3));
            Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
        }
        else
        {
            Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
            Console.WriteLine(@"{0}|\.../|{0}", new string('.', 3));
            Console.WriteLine(@"{0}.|.\./.|{1}", numberOfBallot.ToString().PadLeft(2, '0'), new string('.', 3));
            Console.WriteLine(@"{0}|..V..|{0}", new string('.', 3));
            Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
        }
    }

    private static void DrawBallot(int numberOfBallot)
    {
        Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
        Console.WriteLine("{0}|{1}|{0}", new string('.', 3), new string('.', 5));
        Console.WriteLine("{0}.|{1}|{2}", numberOfBallot.ToString().PadLeft(2, '0'), new string('.', 5), new string('.', 3));
        Console.WriteLine("{0}|{1}|{0}", new string('.', 3), new string('.', 5));
        Console.WriteLine("{0}+{1}+{0}", new string('.', 3), new string('-', 5));
    }
}