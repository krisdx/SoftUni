using System;

public class BitArrayMain
{
    public static void Main()
    {
        BitArray biyArray = new BitArray(8);
        biyArray[7] = 1;
        Console.WriteLine(biyArray);

        //BitArray biyArray2 = new BitArray(10000);
        //biyArray2[3500] = 1;
        //Console.WriteLine(biyArray2);
    }
}