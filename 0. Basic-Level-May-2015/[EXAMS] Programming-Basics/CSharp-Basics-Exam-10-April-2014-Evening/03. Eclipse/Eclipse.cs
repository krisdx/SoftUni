using System;

class Eclipse
{
    static void Main()//-k.d
    {
        int n = int.Parse(Console.ReadLine());

        int asteriskCount = (n * 2) - 2;
        string asterisk = new string('*', asteriskCount);

        string spaces = new string(' ', 1);
        string middleSpaces = new string(' ', n - 1);
        string bridge = new string('-', n - 1);

        Console.WriteLine(spaces + asterisk + spaces + middleSpaces + spaces + asterisk + spaces);

        string slashes = new string('/', (n * 2) - 2);
        asteriskCount = 1;
        asterisk = new string('*', asteriskCount);
        for (int i = 0; i < n - 2; i++)
        {
            if (i == n / 2 - 1)
            {
                Console.WriteLine(asterisk + slashes + asterisk + bridge + asterisk + slashes + asterisk);
            }
            else
            {
                Console.WriteLine(asterisk + slashes + asterisk + middleSpaces + asterisk + slashes + asterisk);
            }
        }

        asteriskCount = (n * 2) - 2;
        asterisk = new string('*', asteriskCount);
        Console.WriteLine(spaces + asterisk + spaces + middleSpaces + spaces + asterisk + spaces);
    }
}
