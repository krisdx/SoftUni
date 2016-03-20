using System;
using System.Numerics;
using System.Linq;

class PetarsGame //-k.d
{
    static void Main()
    {
        BigInteger startNum = BigInteger.Parse(Console.ReadLine());
        BigInteger endNum = BigInteger.Parse(Console.ReadLine());
        string replacementString = Console.ReadLine();

        BigInteger sum = 0;
        for (BigInteger num = startNum; num < endNum ; num++)
        {
            if (num % 5 == 0)
            {
                sum += num;
            }
            else
            {
                sum += num % 5;
            }
        }

        string outputText = "";
        if (sum % 2 == 1)
        {
            BigInteger lastDigit = sum % 10;
            string toReplace = lastDigit.ToString();
            outputText = sum.ToString();
            outputText = outputText.Replace(toReplace, replacementString);
        }
        else
        {
            outputText = sum.ToString();
            string toReplace = outputText[0].ToString();
            outputText = outputText.Replace(toReplace, replacementString);
        }

        Console.WriteLine(outputText);
    }
}