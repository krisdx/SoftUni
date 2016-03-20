using System;

// Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2). 

class PointInsideCircleAndOutsideOfRectangle
{
    static void Main()
    {
        Console.WriteLine("Please enter x and y to see if they're within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).\n");

        Console.Write("Enter x: ");
        double x = float.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Enter x: ");
        double y = float.Parse(Console.ReadLine());

        double distanceFromCenterOfCircle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
        bool isInCircle = (distanceFromCenterOfCircle <= 1.5);

        bool isOutsideRectangle;

        if (-1 <= x && x <= 5 && -1 <= y && y <= 1)
        {
            isOutsideRectangle = false;
        }
        else
        {
            isOutsideRectangle = true;
        }

        Console.WriteLine();

        if (isInCircle && isOutsideRectangle)
        {
            Console.WriteLine("Yes. {0} and {1} are in the circle and outside of the rectangle.\n", x, y);
        }
        else if (isInCircle && !isOutsideRectangle)
        {
            Console.WriteLine("No. {0} and {1} are in the circle, but they are not outside of the rectangle.\n", x, y);
        }
        else if (!isInCircle && isOutsideRectangle)
        {
            Console.WriteLine("No. {0} and {1} are not in the circle, but they're outside of the rectangle.\n", x, y);
        }
        else
        {
            Console.WriteLine("No. {0} and {1} are not in the circle and they're inside of the rectangle.\n", x, y);
        }
    }
}