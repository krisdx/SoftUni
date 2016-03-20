using System;

public class ShuffleBits
{
    public static void Main()
    {
        uint firstNum = uint.Parse(Console.ReadLine());
        uint secondNum = uint.Parse(Console.ReadLine());

        ulong resultNum = 0;
        int resultNumIndex = 63;
        if (firstNum >= secondNum)
        {
            for (int i = 31; i >= 0; i--)
            {
                ulong firstNumBit = (firstNum >> i) & 1;
                resultNum = resultNum | (firstNumBit << resultNumIndex);
                resultNumIndex--;

                ulong secondNumBit = (secondNum >> i) & 1;
                resultNum = resultNum | (secondNumBit << resultNumIndex);
                resultNumIndex--;
            }
        }
        else
        {
            for (int i = 31; i >= 0; i -= 2)
            {
                ulong firstNumBit = (firstNum >> i) & 1;
                resultNum |= firstNumBit << resultNumIndex;
                resultNumIndex--;
                ulong firstNumBit2 = (firstNum >> (i - 1)) & 1;
                resultNum |= firstNumBit2 << resultNumIndex;
                resultNumIndex--;

                ulong secondNumBit = (secondNum >> i) & 1;
                resultNum |= secondNumBit << resultNumIndex;
                resultNumIndex--;
                ulong secondNumBit2 = (secondNum >> (i - 1)) & 1;
                resultNum |= secondNumBit2 << resultNumIndex;
                resultNumIndex--;
            }
        }

        Console.WriteLine(resultNum);
     // Console.WriteLine(Convert.ToString((long)resultNum, 2).PadLeft(64, '0'));
    }
}