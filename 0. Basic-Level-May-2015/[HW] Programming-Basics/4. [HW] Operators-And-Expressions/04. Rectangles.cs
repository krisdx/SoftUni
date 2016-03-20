using System;

//Write an expression that calculates rectangle’s perimeter and area by given width and height.

class Rectangles
{
    static void Main()
    {
        Console.Write("Enter the width of the rectangle: ");
        float width = float.Parse(Console.ReadLine());
        
        Console.Write("Enter the heigth of the rectangle: ");
        float heigth = float.Parse(Console.ReadLine());
        
        float perimeter = 2 * (heigth + width);
        float area = (heigth * width);
       
        Console.WriteLine("\nThe perimeter of the rectangle is: {0}\n", perimeter);
        Console.WriteLine("The area of the rectangle is: {0}\n", area);
    }
}