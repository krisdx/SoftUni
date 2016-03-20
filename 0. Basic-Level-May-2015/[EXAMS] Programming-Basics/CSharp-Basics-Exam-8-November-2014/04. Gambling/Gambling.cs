using System;

class Gambling //-k.d
{
    static void Main()
    {
        decimal cash = decimal.Parse(Console.ReadLine());
        string[] houseHand = Console.ReadLine().Split(' ');

        string[] cardFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        int houseStrength = GetValue(houseHand[0], houseHand[1], houseHand[2], houseHand[3]);

        decimal winningCardsCounter = 0;
        decimal totalHandDrawn = 0;
        for (int card1 = 0; card1 < cardFaces.Length; card1++)
        {
            for (int card2 = 0; card2 < cardFaces.Length; card2++)
            {
                for (int card3 = 0; card3 < cardFaces.Length; card3++)
                {
                    for (int card4 = 0; card4 < cardFaces.Length; card4++)
                    {
                        int myHandStrength = GetValue(cardFaces[card1], cardFaces[card2], cardFaces[card3], cardFaces[card4]);
                        if (myHandStrength > houseStrength)
                        {
                            winningCardsCounter++;
                        }
                        totalHandDrawn++;
                    }
                }
            }
        }

        decimal probability = ((winningCardsCounter / totalHandDrawn) * 100);

        decimal expectedWinnings = (cash * 2) * probability;
        expectedWinnings /= 100;
        //expectedWinnings = Math.Round(expectedWinnings, 2);
        if (probability < 50)
        {
            Console.WriteLine("FOLD");
            Console.WriteLine("{0:#.##}", expectedWinnings);
        }
        else
        {
            Console.WriteLine("DRAW");
            Console.WriteLine("{0:#.##}", expectedWinnings);
        }
    }

    private static int GetValue(string c1, string c2, string c3, string c4)
    {
        string[] currentCards = { c1, c2, c3, c4 };

        int currentHouseStrength = 0;
        for (int card = 0; card < currentCards.Length; card++)
        {
            switch (currentCards[card])
            {
                case "1": currentHouseStrength += 1; break;
                case "2": currentHouseStrength += 2; break;
                case "3": currentHouseStrength += 3; break;
                case "4": currentHouseStrength += 4; break;
                case "5": currentHouseStrength += 5; break;
                case "6": currentHouseStrength += 6; break;
                case "7": currentHouseStrength += 7; break;
                case "8": currentHouseStrength += 8; break;
                case "9": currentHouseStrength += 9; break;
                case "10": currentHouseStrength += 10; break;
                case "J": currentHouseStrength += 11; break;
                case "Q": currentHouseStrength += 12; break;
                case "K": currentHouseStrength += 13; break;
                case "A": currentHouseStrength += 14; break;
            }
        }
        return currentHouseStrength;
    }
}