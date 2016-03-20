using System;

class HayvanNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());

        bool solutionFound = false;
        for (int i = 555; i <= 999; i++)
        {
            int abc = i;
            int def = abc + diff;
            int ghi = def + diff;

            string wholeNumber = "" + abc + def + ghi;
            if (wholeNumber.Contains("0") || wholeNumber.Contains("1") || wholeNumber.Contains("2") || wholeNumber.Contains("3") || wholeNumber.Contains("4")) 
            {
                continue;
            }
            
            int currentSum = 0;
            for (int j = 0; j < wholeNumber.Length; j++)
            {
                currentSum += int.Parse(Convert.ToString(wholeNumber[j]));
            }

            if (currentSum == sum)
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