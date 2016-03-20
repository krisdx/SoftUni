using System;

public class ReverseNumber
{
    static void Main()
    {
        long num = long.Parse(Console.ReadLine());

        long tempNum = num;
        int n = -1;
        while (true)
        {
            tempNum /= 10;
            n++;

            if (tempNum == 0)
            {
                break;
            }
        }

        long reversedNum = 0;
        while (true)
        {
            long digit = num % 10;
            reversedNum += digit * (long)Math.Pow(10, n);
            n--;
            num /= 10;

            if (num == 0)
            {
                break;
            }
        }

        Console.WriteLine(reversedNum);
    }
}