using System;

class Substring
{
    const char TargetChar = 'p';

    static void Main()
    {
        string inputText = Console.ReadLine();

        int jump = int.Parse(Console.ReadLine());

        bool solutionFound = false;
        for (int i = 0; i < inputText.Length; i++)
        {
            char currentChar = inputText[i];

            if (currentChar == TargetChar)
            {
                solutionFound = true;

                int endIndex = jump + 1;
                if (i + endIndex > inputText.Length)
                {
                    endIndex = inputText.Length - i;
                }
                string matchedString = inputText.Substring(i, endIndex);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("no");
        }
    }
}