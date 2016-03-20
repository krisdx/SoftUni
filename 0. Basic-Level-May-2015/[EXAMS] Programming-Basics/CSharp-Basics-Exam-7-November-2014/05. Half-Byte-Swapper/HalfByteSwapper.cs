using System;

class HalfByteSwapper //-k.d
{
    static void Main()
    {
        uint[] numbers = new uint[4];
        for (int i = 0; i < 4; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 150; i++)
        {
            string commands1 = Console.ReadLine();
            if (commands1 == "End")
            {
                break;
            }
            string commands2 = Console.ReadLine();

            string[] firstCommandsStr = commands1.Split(' ');
            int[] firstCommand = new int[firstCommandsStr.Length];
            for (int i1 = 0; i1 < firstCommand.Length; i1++)
            {
                firstCommand[i1] = int.Parse(firstCommandsStr[i1]);
            }

            string[] secondCommandsStr = commands2.Split(' ');
            int[] secondCommand = new int[secondCommandsStr.Length];
            for (int i2 = 0; i2 < secondCommand.Length; i2++)
            {
                secondCommand[i2] = int.Parse(secondCommandsStr[i2]);
            }

            //geting the 4 group of bits
            uint mask1 = (uint)(numbers[firstCommand[0]] & (15 << (firstCommand[1] * 4))) >> (firstCommand[1] * 4);
            uint mask2 = (uint)(numbers[secondCommand[0]] & (15 << (secondCommand[1] * 4))) >> (secondCommand[1] * 4);
            //setting this groups to "0000"
            numbers[firstCommand[0]] &= (uint)~(15 << (firstCommand[1] * 4));
            numbers[secondCommand[0]] &= (uint)~(15 << (secondCommand[1] * 4));
            //adding the the masks to the numbers
            numbers[firstCommand[0]] |= mask2 << (firstCommand[1] * 4);
            numbers[secondCommand[0]] |= mask1 << (secondCommand[1] * 4);
        }

        foreach (uint num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}