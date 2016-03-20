using System;

class TicTacToePower  
{
    static void Main() //-k.d
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int initialValue = int.Parse(Console.ReadLine());

        int index = 0;
        if (y == 0)
        {
            index = x + 1;
            initialValue += x;
        }
        else if (y == 1)
        {
            index = x + 4;
            initialValue += x + 3;
        }
        else if (y == 2)
        {
            index = x + 7;
            initialValue += x + 6;
        }

        ulong result = (ulong)Math.Pow(initialValue, index);
        Console.WriteLine(result);
    }
}
