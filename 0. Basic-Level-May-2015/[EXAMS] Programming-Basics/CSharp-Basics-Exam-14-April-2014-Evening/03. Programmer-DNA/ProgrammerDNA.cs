using System;

class ProgrammerDNA
{
    static void Main() //_!_SS
    {
        int n = 10;//int.Parse(Console.ReadLine());
        char letter = 'A';// char.Parse(Console.ReadLine());

        int dotsCounter = 3;
        bool reachMiddle = false;
        for (int i = 0; i < n; i++)
        {
            string dots = new string('.', dotsCounter);
            string leters = new string(letter, 7 - (dotsCounter * 2));
            if (!reachMiddle)
            {
                Console.Write(dots);
               
                Console.Write(leters);
                Console.Write(dots);
                dotsCounter--;
                Console.WriteLine();
                if (dotsCounter < 0)
                {
                    reachMiddle = true;
                    dotsCounter++;
                }
            }
            else
            {
                Console.Write(dots);
                Console.Write(leters);
                Console.Write(dots);
                Console.WriteLine();
                if (dotsCounter == 3)
                {
                    Console.Write(dots);
                    Console.Write(leters);
                    Console.Write(dots);
                    reachMiddle = false;
                }
                dotsCounter++;
            }
        }
    }
}