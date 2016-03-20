using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StraightFlush
{
    static Regex cardSuit = new Regex(@"[SHDC]");

    static void Main()
    {
        string input = Console.ReadLine();

        string[] cards = input.Split(new char[] { ',' ,' '}, StringSplitOptions.RemoveEmptyEntries);

        bool solutionFound = false;
        for (int i = 0; i < cards.Length; i++)
        {
            string currentCard = cards[i];
            int currentCardValue = GetValue(currentCard);
            char currentCardSuit = char.Parse(cardSuit.Match(currentCard).ToString());

            Dictionary<int, char> cardsLeft = new Dictionary<int, char>();
            for (int j = 0; j < cards.Length; j++)
            {
                string nextCard = cards[j];
                int nextCardValue = GetValue(nextCard);
                char nextCardSuit = char.Parse(cardSuit.Match(nextCard).ToString());
                if (nextCardSuit != currentCardSuit)
                {
                    continue;
                }

                cardsLeft.Add(nextCardValue, nextCardSuit);
            }

            List<string> currentCombo = new List<string>() { currentCard };
            int nextValue = currentCardValue + 1;
            while (cardsLeft.ContainsKey(nextValue))
            {
                currentCombo.Add(GetStringValue(nextValue) + cardsLeft[nextValue]);
                if (currentCombo.Count == 5)
                {
                    Print(currentCombo);
                    solutionFound = true;
                    break;
                }

                nextValue++;
            }

        }

        if (!solutionFound)
        {
            Console.WriteLine("No Straight Flushes");
        }
    }

    public static string GetStringValue(int nextValue)
    {
        switch (nextValue)
        {
            case 11: return "J";
            case 12: return "Q";
            case 13: return "K";
            case 14: return "A";
            default: return nextValue.ToString();
        }
    }

    public static int GetValue(string currentCard)
    {
        currentCard = currentCard.Remove(currentCard.Length - 1);

        switch (currentCard)
        {
            case "J": return 11;
            case "Q": return 12;
            case "K": return 13;
            case "A": return 14;
            default: return int.Parse(currentCard);
        }
    }

    public static void Print(List<string> currentCombo)
    {
        int length = currentCombo.Count;
        int commaCounter = 1;

        Console.Write('[');
        foreach (var card in currentCombo)
        {
            if (commaCounter == length)
            {
                Console.Write(card);
            }
            else
            {
                Console.Write("{0}, ", card);
            }
            commaCounter++;
        }
        Console.WriteLine(']');
    }
}