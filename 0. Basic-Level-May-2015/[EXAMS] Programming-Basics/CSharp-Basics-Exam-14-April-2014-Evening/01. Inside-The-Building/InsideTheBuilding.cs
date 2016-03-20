using System;

class InsideTheBuilding //-k.d
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());

        for (int i = 1; i <= 5; i++)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
           bool isInsideDownLeft = (x >= 0 && x <= h) && (y >= 0 && y <= h);
            bool isInsideUp = (x >= h && x <= h * 2) && (y >= 0 && y <= h * 4);
            bool isInsideRigth = (x >= h * 2 && x <= h * 3) && (y >= 0 && y <= h);

            if (isInsideDownLeft || isInsideUp || isInsideRigth)
            {
                Console.WriteLine("inside");
            }
            else 
            {
                Console.WriteLine("outside");
            }
        }
    }
}