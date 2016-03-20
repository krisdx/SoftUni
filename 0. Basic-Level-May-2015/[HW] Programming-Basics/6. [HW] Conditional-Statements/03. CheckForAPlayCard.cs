using System;

// Classical play cards use the following signs to designate the card face: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints “yes” if it is a valid card sign or “no” otherwise. 

class CheckForAPlayCard
{
    static void Main()
    {
        Console.Write("Please, enter charecter: ");
        string character = Console.ReadLine();

        string[] playCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        bool cards = false;

        for (int i = 0; i < playCards.Length; i++)
        {
            if (character == playCards[i])
            {
                cards = true;
                break;
            }
            else 
            {
                cards = false;
            }
        }
        
        if (cards)
        {
            Console.WriteLine("\nYes.\n");
        }
        else
        {
            Console.WriteLine("\nNo.\n");
        }
    }
}