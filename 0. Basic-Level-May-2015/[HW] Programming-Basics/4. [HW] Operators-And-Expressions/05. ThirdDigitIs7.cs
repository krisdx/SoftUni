using System;

// Write an expression that checks for given integer if its third digit from right-to-left is 7. 

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int number = int.Parse(Console.ReadLine());
       
        int divide = (number / 100); 
        bool result = divide % 10 == 7; 
      
        Console.WriteLine("\n{0}", result); 
    }
}