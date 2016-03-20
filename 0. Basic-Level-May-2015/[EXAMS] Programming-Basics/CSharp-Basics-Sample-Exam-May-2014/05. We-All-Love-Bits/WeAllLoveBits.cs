using System;

class WeAllLoveBits //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string numberInString = Convert.ToString(number, 2);
            string reversedNumberInString = "";

            for (int bit = numberInString.Length - 1; bit >= 0; bit--)
            {
                reversedNumberInString += numberInString[bit];
            }

            int reversedNumberInInt = Convert.ToInt32(reversedNumberInString, 2);
            int result = (number ^ (~number)) & reversedNumberInInt;
            Console.WriteLine(result);
        }
    }
}