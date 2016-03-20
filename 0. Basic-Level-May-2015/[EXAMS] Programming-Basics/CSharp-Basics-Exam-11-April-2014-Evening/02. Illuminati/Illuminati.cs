using System;

class Illuminati // -k.d
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] chars = new char[input.Length];

        int vowelsCount = 0;
        int sum = 0;
        for (int letter = 0; letter < input.Length; letter++)
        {
            chars[letter] = Convert.ToChar(input[letter]);
            if (chars[letter] == 65 || chars[letter] == 97)
            {
                sum += 65;
                vowelsCount++;
            }
            else if (chars[letter] == 69 || chars[letter] == 101)
            {
                sum += 69;
                vowelsCount++;
            }
            else if (chars[letter] == 73 || chars[letter] == 105)
            {
                sum += 73;
                vowelsCount++;
            }
            else if (chars[letter] == 79 || chars[letter] == 111)
            {
                sum += 79;
                vowelsCount++;
            }
            else if (chars[letter] == 85 || chars[letter] == 117)
            {
                sum += 85;
                vowelsCount++;
            }
        }
        Console.WriteLine(vowelsCount);
        Console.WriteLine(sum);
    }
}