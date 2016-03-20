using System;

class StripedTowel
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool hashTag = true;
        int dotsCounter = 0;
        for (int i = 0; i < Math.Floor(n * 1.5); i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (hashTag)
                {
                    Console.Write('#');
                    hashTag = false;
                }
                else
                {
                    Console.Write('.');
                    dotsCounter++;
                    if (dotsCounter == 2)
                    {
                        hashTag = true;
                        dotsCounter = 0;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}