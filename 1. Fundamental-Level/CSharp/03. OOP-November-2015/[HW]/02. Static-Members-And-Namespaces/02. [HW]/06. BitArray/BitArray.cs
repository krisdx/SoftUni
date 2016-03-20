using System;
using System.Numerics;

public class BitArray
{
    public const int MaxBits = 100000;

    private int numberOfBits;
    private byte[] bitArray;

    public BitArray(int numberOfBits)
    {
        this.NumberOfBits = numberOfBits;
        this.bitArray = new byte[numberOfBits];
    }

    public int NumberOfBits
    {
        get { return this.numberOfBits; }
        set
        {
            if (value < 0 ||
                value > MaxBits)
            {
                throw new IndexOutOfRangeException("The number of bits must be in range [0.. 100 000].");
            }

            this.numberOfBits = value;
        }
    }

    public int this[int index]
    {
        get
        {
            return this.bitArray[index];
        }
        set
        {
            if (index > this.NumberOfBits ||
                index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            this.bitArray[index] = (byte)value;
        }
    }

    private string ConvertBinaryNumToDecimal()
    {
        BigInteger num = 0;
        int n = 0;
        for (int i = 0; i < this.numberOfBits; i++)
        {
            if (bitArray[i] == 1)
            {
                BigInteger currentNum = 2;
                for (int j = 1; j < n; j++)
                {
                    currentNum *= 2;
                }

                num += currentNum;
            }

            n++;
        }

        return num.ToString();
    }

    public override string ToString()
    {
        return ConvertBinaryNumToDecimal();
    }
}