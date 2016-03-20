using System;

class Sunglasses// -k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int asteriskCount = n * 2;
        string asterisk = new string('*', asteriskCount);
        int spacesCount = n;
        string spaces = new string(' ', spacesCount);

        Console.WriteLine(asterisk + spaces + asterisk);

        int slashesCount = (n * 2) - 2;
        asteriskCount = 1;
        int bridgeCount = n;
        bool bridgePrinted = false;
        
        for (int i = 0; i < n - 2; i++)
        {
            asterisk = new string('*', asteriskCount);
            string slashes = new string('/', slashesCount);
            string bridge = new string('|', bridgeCount);
            
            if (n == 3)
            {
                if (i == 0)
                {
                    Console.WriteLine(asterisk + slashes + asterisk + bridge + asterisk + slashes + asterisk);
                    asteriskCount = n * 2;
                }
                else
                {
                    Console.WriteLine(asterisk + spaces + asterisk);
                }
            }
            else
            {
                if (i == 0)
                {
                    Console.WriteLine(asterisk + slashes + asterisk + spaces + asterisk + slashes + asterisk);
                }
                else if (i == (n - 2) / 2)
                {
                    Console.WriteLine(asterisk + slashes + asterisk + bridge + asterisk + slashes + asterisk);
                    bridgePrinted = true;
                }
                else if (bridgePrinted)
                {
                    Console.WriteLine(asterisk + slashes + asterisk + spaces + asterisk + slashes + asterisk);
                }
                else
                {
                    Console.WriteLine(asterisk + slashes + asterisk + spaces + asterisk + slashes + asterisk);
                }
            }

        }
        asteriskCount = n * 2;
        asterisk = new string('*', asteriskCount);
        spacesCount = n;
        spaces = new string(' ', spacesCount);

        Console.Write(asterisk + spaces + asterisk);
        Console.WriteLine();
    }
}