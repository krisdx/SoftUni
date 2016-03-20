using System;
using System.Collections.Generic;
using System.Linq;

class SumCards
{
    static void Main()
    {
        List<string> cards = Console.ReadLine().Trim().Split().ToList();
        cards.Add("0S");

        int sum = 0;
        int equalCounter = 1;
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int currentCardValue = GetValue(cards[i]);
            int nextValue = GetValue(cards[i + 1]);
            if (currentCardValue == nextValue)
            {
                equalCounter++;
            }
            else
            {
                if (equalCounter > 1)
                {
                    for (int j = 0; j < equalCounter; j++)
                    {
                        sum += currentCardValue * 2;
                    }
                }
                else
                {
                    sum += currentCardValue;
                }

                equalCounter = 1;
            }
        }

        Console.WriteLine(sum);
    }

    static int GetValue(string currentCard)
    {
        currentCard = currentCard.Remove(currentCard.Length - 1);

        int cardValue = 0;
        switch (currentCard)
        {
            case "J": cardValue = 12; break;
            case "Q": cardValue = 13; break;
            case "K": cardValue = 14; break;
            case "A": cardValue = 15; break;
            default: cardValue = int.Parse(currentCard); break;
        }

        return cardValue;
    }
}