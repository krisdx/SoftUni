using System;

class Boat
{
    static void Main() //-k.d
    {
        int n = int.Parse(Console.ReadLine());

        string rigthDots = new string('.', n);
        int asteriskCounter = 1;
        int leftDotsCounter = n - 1; 
        for (int i = 0; i < n; i++)
        {
            if (i <= n / 2)
            {
                Console.Write(new string('.', leftDotsCounter));
                leftDotsCounter -= 2;
                Console.Write(new string('*', asteriskCounter));
                asteriskCounter += 2;
                Console.WriteLine(rigthDots);
            }
            else
            {
                leftDotsCounter += 2;
                asteriskCounter -= 2;
                Console.Write(new string('.', leftDotsCounter + 2));
                Console.Write(new string('*', asteriskCounter - 2));
                Console.WriteLine(rigthDots);
            }
        }
        
        int dotsCounter = 1;
        asteriskCounter = n *2;
        for (int i = 0; i < n / 2; i++)
        {
            string asterisk = new string('*', asteriskCounter);
            if (i == 0)
            {
                Console.WriteLine(asterisk);
                asteriskCounter -= 2;
            }
            else
            {
                string dots = new string('.', dotsCounter);
                Console.WriteLine(dots + asterisk + dots);
                asteriskCounter -= 2;
                dotsCounter++;
            }
        }
    }
}