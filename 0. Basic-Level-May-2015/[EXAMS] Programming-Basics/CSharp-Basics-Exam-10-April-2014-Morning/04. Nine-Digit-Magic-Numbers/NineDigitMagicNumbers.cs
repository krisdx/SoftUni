using System;

class NineDigitMagicNumbers
{
    static void Main() // -k.d
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());

        bool solutionFound = false;
        for (int i = 111; i <= 777; i++)
        {
            int abc = i;
            int def = i + diff;
            int ghi = def + diff;

            string wholeNumber = "" + abc + def + ghi;

            if (wholeNumber.Contains("0") || wholeNumber.Contains("8") || wholeNumber.Contains("9"))
            {
                continue;
            }

            int currentSum = 0;
            for (int index = 0; index < wholeNumber.Length; index++)
            {
                currentSum += int.Parse(Convert.ToString(wholeNumber[index]));
            }
            if (currentSum == sum && wholeNumber.Length == 9) // wholeNumber.Length == 9 !!!
            {
                Console.WriteLine(wholeNumber);
                solutionFound = true;
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}