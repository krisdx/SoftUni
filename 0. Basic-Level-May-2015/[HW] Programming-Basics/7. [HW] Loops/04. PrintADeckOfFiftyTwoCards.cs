using System;

// Write a program that generates and prints all possible cards from a standard deck of 52 cards (without the jokers). The cards should be printed using the classical notation (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A. Print each card face in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and a switch-case statement.

class PrintADeckOfFiftyTwoCards
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        int cardSuits = 4;
        int cardsNumbers = 13;

        for (int card = 0; card < cardsNumbers; card++)
        {
            string currentCard = cards[card];
            for (int suit = 0; suit <= cardSuits; suit++)
            {
                switch (suit)
                {
                    case 1: Console.Write("{0}{1} ", card, '♣');
                        break;
                    case 2: Console.Write("{0}{1} ", card, '♦');
                        break;
                    case 3: Console.Write("{0}{1} ", card, '♥');
                        break;
                    case 4: Console.WriteLine("{0}{1} ", card, '♠');
                        break;
                }
            }
        }
        Console.WriteLine();
    }
}

