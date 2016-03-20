using System;
using System.Linq;

class WiggleWiggle
{
    static void Main()
    {
        ulong[] numbers = Console.ReadLine().Split().Select(ulong.Parse).ToArray();

        for (int i = 0; i <= numbers.Length - 2; i += 2)
        {
            ulong firstNum = numbers[i];
            ulong secondNum = numbers[i + 1];
            for (int evenBit = 0; evenBit < 63; evenBit += 2)
            {
                ulong firstNumBit = (firstNum >> evenBit) & 1;
                ulong secondNumBit = (secondNum >> evenBit) & 1;

                if (firstNumBit == 1)
                {
                    secondNum |= (ulong)1 << evenBit;
                }
                else
                {
                    secondNum &= ~((ulong)1 << evenBit);
                }

                if (secondNumBit == 1)
                {
                    firstNum |= (ulong)1 << evenBit;
                }
                else
                {
                    firstNum &= ~((ulong)1 << evenBit);
                }
            }

            numbers[i] = firstNum;
            numbers[i + 1] = secondNum;
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] ^= long.MaxValue;
        }

        foreach (var num in numbers)
        {
            Console.WriteLine(num + " " + Convert.ToString((long)num, 2).PadLeft(63, '0'));
        }
    }
}