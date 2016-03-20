using System;

class ChessboardGame //-k.d
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());
        string inputText = Console.ReadLine();

        char[] textArray = inputText.ToCharArray();

        int blackTeam = 0;
        int whiteTeam = 0;
        for (int index = 0; index < textArray.Length; index++)
        {
            if (index >= boardSize * boardSize) // !!!
            {
                break;
            }

            if (index % 2 == 0 && (char.IsLetterOrDigit(textArray[index]))) // blackTeam
            {
                if (char.IsUpper(textArray[index]))
                {
                    whiteTeam += textArray[index];
                }
                else
                {
                    blackTeam += textArray[index];
                }
            }
            else if (index % 2 == 1 && char.IsLetterOrDigit(textArray[index])) // whiteTeam
            {
                if (char.IsUpper(textArray[index]))
                {
                    blackTeam += textArray[index];
                }
                else
                {
                    whiteTeam += textArray[index];
                }
            }
        }

        if (whiteTeam == blackTeam)
        {
            Console.WriteLine("Equal result: {0}", whiteTeam);
        }
        else
        {
            int diff = Math.Abs(blackTeam - whiteTeam);
            if (blackTeam < whiteTeam)
            {
                Console.WriteLine("The winner is: white team");
                Console.WriteLine(diff);
            }
            else
            {
                Console.WriteLine("The winner is: black team");
                Console.WriteLine(diff);
            }
        }
    }
}