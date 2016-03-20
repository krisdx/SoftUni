using System;

class PokerStraight
{
    static void Main()
    {
        int magicWeigth = int.Parse(Console.ReadLine());

        int[] suits = new int[] { 1, 2, 3, 4 };
        int[] faces = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        int handsCounter = 0;
        for (int index = 0; index < faces.Length - 4; index++)
        {
            for (int suit1 = 0; suit1 < suits.Length; suit1++)
            {
                for (int suit2 = 0; suit2 < suits.Length; suit2++)
                {
                    for (int suit3 = 0; suit3 < suits.Length; suit3++)
                    {
                        for (int suits4 = 0; suits4 < suits.Length; suits4++)
                        {
                            for (int suit5 = 0; suit5 < suits.Length; suit5++)
                            {
                                int currentWeigth =
                                    (10 * faces[index] + suits[suit1]) +
                                    (20 * (faces[index] + 1) + suits[suit2]) +
                                    (30 * (faces[index] + 2) + suits[suit3]) +
                                    (40 * (faces[index] + 3) + suits[suits4]) +
                                    (50 * (faces[index] + 4) + suits[suit5]);

                                if (currentWeigth == magicWeigth)
                                {
                                    handsCounter++;
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(handsCounter);
    }
}