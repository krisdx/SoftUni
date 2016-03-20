using System;
using System.Linq;

class PaintBall //-k.d
{
    static void Main()
    {
        int[] numbers = new int[10];
        for (int num = 0; num < numbers.Length; num++)
        {
            numbers[num] = 1023;
        }

        bool shootingWithBlack = true;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            string[] paintBallShoot = input.Split(' ');
            int rowToShoot = int.Parse(paintBallShoot[0]);
            int colToShhot = int.Parse(paintBallShoot[1]);
            int radius = int.Parse(paintBallShoot[2]);

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    bool isInseideRowUp = row >= rowToShoot - radius;
                    bool isInsideRowDown = row <= rowToShoot + radius;
                    bool isInsideColRigth = col >= colToShhot - radius;
                    bool isInsideColLeft = col <= colToShhot + radius;

                    if ((isInseideRowUp && isInsideRowDown) && (isInsideColLeft && isInsideColRigth))
                    {
                        if (shootingWithBlack)
                        {
                            numbers[row] &= ~(1 << col);
                        }
                        else
                        {
                            numbers[row] |= (1 << col);
                        }
                    }
                }
            }

            shootingWithBlack = !shootingWithBlack;
        }

        int sum = numbers.Sum();
        Console.WriteLine(sum);
    }
}