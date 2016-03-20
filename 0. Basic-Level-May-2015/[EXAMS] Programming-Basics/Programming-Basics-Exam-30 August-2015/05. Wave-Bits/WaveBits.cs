using System;
using System.Text;
using System.Linq;

class WaveBits
{
    static void Main()
    {
        ulong num = ulong.Parse(Console.ReadLine());

        int index = 0;
        int maxLength = 0;
        int currentLength = 0;
        bool b = false;
        for (int i = 0; i < 64 - 2; i++)
        {
            ulong currentBit = (num >> i) & 1;
            ulong nextBit = (num >> i + 1) & 1;
            ulong nextBit2 = (num >> i + 2) & 1;
            if (currentBit == 1 &&
                nextBit == 0 &&
                nextBit2 == 1)
            {
                if (!b)
                {
                    b = true;
                    currentLength += 3;
                }
                else
                {
                    currentLength += 2;
                }

                i++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    index = i + maxLength;
                    currentLength = 0;
                }
            }
        }

        string str = Convert.ToString((long)num, 2);
        //StringBuilder sb = new StringBuilder();
        //for (int i = str.Length - 1; i >= 0; i--)
        //{
        //    sb.Append(str[i]);
        //}
        //str = sb.ToString();
        str = str.Remove(index, maxLength);
       
        ulong resultNum = Convert.ToUInt64(str, 2);
        Console.WriteLine(resultNum);
    }
}