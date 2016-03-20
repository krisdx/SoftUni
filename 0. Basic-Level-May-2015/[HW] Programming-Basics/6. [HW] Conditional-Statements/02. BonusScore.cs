using System;

class BonusScore
{
    static void Main()
    {
        Console.Write("Please, enter score (1 to 9): ");
        int score = int.Parse(Console.ReadLine());
        
        if ((score < 1) || (score > 9)) 
        {
            Console.WriteLine("\nInvalid score.\n");
        }
        else
        {
            if ((score >= 1) && (score <= 3))
            {
                score = (score * 10);
            }
            else if ((score >= 4) && (score <= 6))
            {
                score = (score * 100);
            }
            else if ((score >= 7) && (score <= 9))
            {
                score = (score * 1000);
            }
            
            Console.WriteLine("\nResult: {0}\n", score);
        } 
    }
}

