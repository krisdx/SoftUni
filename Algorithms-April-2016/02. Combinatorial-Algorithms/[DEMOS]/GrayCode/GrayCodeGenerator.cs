using System;

public class GrayCodeGenerator
{
    private const int n = 4;
    private static int[] arr = new int[n];

    public static void Main()
    {
	    ForwardGray(n - 1);
    }

    static void ForwardGray(int k)
    {
        if (k < 0)
        {
            Print();
        }
        else
        {
            arr[k] = 0;
            ForwardGray(k - 1);
            arr[k] = 1;
            BackwardGray(k - 1);
        }
    }
	
    static void BackwardGray(int k)
    {
        if (k < 0)
        {
            Print();
        }
        else
        {
            arr[k] = 1;
            ForwardGray(k - 1);
            arr[k] = 0;
            BackwardGray(k - 1);
        }
    }
	
	static void Print()
	{
		Console.WriteLine("(" + string.Join(", ", arr) + ")");
	}
}