using System;

//The gravitational field of the Moon is approximately 17% of that on the Earth. Write a program that calculates the weight of a man on the moon by a given weight on the Earth. 

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Enter weigth: ");
        float weigth = float.Parse(Console.ReadLine());

        float gravitationOftheMoon = 0.17f;
        float weigthOfAMenOnTheMoon = (weigth * gravitationOftheMoon);

        Console.WriteLine("\nThe weigth of a man of the moon will be: {0:F3}\n", weigthOfAMenOnTheMoon);
    }
}