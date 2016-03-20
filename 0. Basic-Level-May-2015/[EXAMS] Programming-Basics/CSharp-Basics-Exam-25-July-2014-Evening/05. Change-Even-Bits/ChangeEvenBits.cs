using System;

class ChangeEvenBits //-k.d
{
    static void Main()
    {
        int numberOfIntegers = int.Parse(Console.ReadLine());

        int[] numbers = new int[numberOfIntegers];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        ulong l = ulong.Parse(Console.ReadLine());

        ulong onesBitCounter = 0;
        ulong bitCheck = 0;
        ulong one = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            string binaryNum = Convert.ToString(numbers[i], 2);
            int evenCounter = 0;
            for (int bit = 0; bit < binaryNum.Length; bit++)
            {
                bitCheck = ((one << evenCounter) & l) >> evenCounter;
                if (bitCheck == 0)
                {
                    onesBitCounter++;
                }

                ulong mask = (one << evenCounter);
                l = l | mask;
                evenCounter += 2;
            }
        }
        Console.WriteLine(l);
        Console.WriteLine(onesBitCounter);  
    }
}