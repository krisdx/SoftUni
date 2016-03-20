using System;

class NewHouse //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int dashesCount = n / 2;
        int asteriskCount = 1;
        for (int i = 0; i < (n / 2) + 1 ; i++)
        {
            string dashes = new string('-', dashesCount);
            string asterisk = new string('*', asteriskCount);
            if (i == 0)
            {
                Console.WriteLine(dashes + asterisk + dashes);
                dashesCount--;
                asteriskCount += 2;
            }
            else
            {
                Console.WriteLine(dashes + asterisk + dashes);
                dashesCount--;
                asteriskCount += 2;
            }
        }

        for (int i = 0; i < n; i++)
        {
            string asterisk = new string('*', n - 2);
            string pipe = new string('|', 1);
            Console.WriteLine(pipe + asterisk + pipe);
        }
    }
}
