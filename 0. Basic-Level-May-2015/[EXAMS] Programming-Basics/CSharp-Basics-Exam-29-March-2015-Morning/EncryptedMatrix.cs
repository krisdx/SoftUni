using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

class EncryptedMatrix // -k.d
{
    static void Main()
    {
        string inputText = Console.ReadLine();
        char diagonal = char.Parse(Console.ReadLine());

        char[] text = inputText.ToCharArray();

        string stringNum = "";
        for (int currentLetter = 0; currentLetter < text.Length; currentLetter++)
        {
            long lastDigit = text[currentLetter] % 10;
            stringNum += lastDigit.ToString();
        }

        BigInteger number = BigInteger.Parse(stringNum);
        List<char> numberArray = stringNum.ToList();
        numberArray.Reverse();
        List<string> resultNumber = new List<string>();
        for (int currentLetter = 0; currentLetter < text.Length; currentLetter++)
        {
            BigInteger currentDigit = number % 10;
            if (currentDigit % 2 == 0 || currentDigit == 0)
            {
                currentDigit *= currentDigit;
                if (currentDigit >= 10)
                {
                    resultNumber.Add((currentDigit % 10).ToString());
                    resultNumber.Add(((currentDigit / 10) % 10).ToString());
                }
                else
                {
                    resultNumber.Add(currentDigit.ToString());
                }
            }
            else
            {
                BigInteger previousDigit;
                bool previousDigitOutOfRange = currentLetter - 1 < 0;
                if (previousDigitOutOfRange)
                {
                    previousDigit = 0;
                }
                else
                {
                    previousDigit = BigInteger.Parse(numberArray[currentLetter - 1].ToString());
                }

                BigInteger nextDigit;
                bool nextDigitOutOfRange = currentLetter + 1 == text.Length;
                if (nextDigitOutOfRange)
                {
                    nextDigit = 0;
                }
                else
                {
                    nextDigit = BigInteger.Parse(numberArray[currentLetter + 1].ToString());
                }

                currentDigit = currentDigit + previousDigit + nextDigit;
                if (currentDigit >= 10)
                {
                    resultNumber.Add((currentDigit % 10).ToString());
                    resultNumber.Add(((currentDigit / 10) % 10).ToString());
                }
                else
                {
                    resultNumber.Add(currentDigit.ToString());
                }
            }
            number /= 10;
        }

        resultNumber.Reverse();
        //foreach (string number in resultNumber)
        //{
        //    Console.Write(number);
        //}

        if (diagonal == '\\')
        {
            int counter = 0;
            for (int row = 0; row < resultNumber.Count; row++)
            {
                for (int col = 0; col < resultNumber.Count; col++)
                {
                    if (col == counter)
                    {
                        Console.Write(resultNumber[row] + " ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                counter++;
                Console.WriteLine();
            }
        }
        else
        {
            resultNumber.Reverse();
            int counter = resultNumber.Count - 1;
            for (int row = 0; row < resultNumber.Count; row++)
            {
                for (int col = 0; col < resultNumber.Count; col++)
                {
                    if (col == counter)
                    {
                        Console.Write(resultNumber[row] + " ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                counter--;
                Console.WriteLine();
            }
        }
    }
}