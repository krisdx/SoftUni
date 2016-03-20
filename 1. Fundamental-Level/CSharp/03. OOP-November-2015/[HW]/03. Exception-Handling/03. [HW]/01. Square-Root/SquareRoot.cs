using System;

public class SquareRoot
{
    public static void Main()
    {
        try
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Square root: " + Math.Sqrt(num));
        }
        catch (FormatException)
        {
            Console.WriteLine("Cannot convert the entered string into an integer");
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is to large for Int32.");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input.");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}