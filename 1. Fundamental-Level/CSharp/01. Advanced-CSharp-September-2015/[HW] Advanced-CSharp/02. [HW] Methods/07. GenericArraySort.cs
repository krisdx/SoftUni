using System;

class GenericArraySort
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates =
        {
            new DateTime(2002, 3, 1),
            new DateTime(2015, 5, 6),
            new DateTime(2014, 1, 1)
        };

        ArraySort(numbers);
        ArraySort(strings);
        ArraySort(dates);
    }

    static void ArraySort<T>(T[] array) where T : IComparable
    {
        bool sorted = false;
        while (!sorted)
        {
            sorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].CompareTo(array[i + 1]) == 1)
                {
                    var exchangeValue = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = exchangeValue;
                    sorted = false;
                }
            }
        }

        Console.WriteLine("[ {0} ]", string.Join(", ", array));
    }
}