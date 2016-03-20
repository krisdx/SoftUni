using System;

class MagicCard
{
    static void Main()
    {
        string[] inputHand = Console.ReadLine().Split();
        string oddOrEven = Console.ReadLine();
        string magicCard = Console.ReadLine();

        string magicCardValue = magicCard.Remove(magicCard.Length - 1);
        char magicCardSuit = GetCardSuit(magicCard);
        int calculatedCardValue = 0;
        for (int i = 0; i < inputHand.Length; i++)
        {
            string currentCard = inputHand[i];
            string currentCardValue = currentCard.Remove(currentCard.Length - 1);
            char currentCardSuit = GetCardSuit(currentCard);

            if (oddOrEven == "odd" && i % 2 == 1)
            {
                int cardValue = GetCardValue(currentCardValue);
                if (currentCardValue == magicCardValue)
                {
                    cardValue *= 3;
                }
                if (currentCardSuit == magicCardSuit)
                {
                    cardValue *= 2;
                }
                calculatedCardValue += cardValue;
            }
            else if (oddOrEven == "even" && i % 2 == 0)
            {
                int cardValue = GetCardValue(currentCardValue);
                if (currentCardValue == magicCardValue)
                {
                    cardValue *= 3;
                }
                if (currentCardSuit == magicCardSuit)
                {
                    cardValue *= 2;
                }
                calculatedCardValue += cardValue;
            }
        }

        Console.WriteLine(calculatedCardValue);
    }

    static int GetCardValue(string cardValue)
    {
        int calculatedCardValue = 0;
        switch (cardValue)
        {
            case "J": calculatedCardValue = 120; break;
            case "Q": calculatedCardValue = 130; break;
            case "K": calculatedCardValue = 140; break;
            case "A": calculatedCardValue = 150; break;
            default: calculatedCardValue = int.Parse(cardValue) * 10; break;
        }

        return calculatedCardValue;
    }

    static char GetCardSuit(string currentCard)
    {
        char suit;
        if (currentCard.Length == 3)
        {
            suit = char.Parse(currentCard.Substring(2));
        }
        else
        {
            suit = char.Parse(currentCard.Substring(1));
        }

        return suit;
    }
}