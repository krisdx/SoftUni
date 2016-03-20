using System;

public class TakeThePlaneDown
{
    public static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine()); // radius

        int numberOfEnemyPlanes = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfEnemyPlanes; i++)
        {
            int enemyPlaneX = int.Parse(Console.ReadLine());
            int enemyPlaneY = int.Parse(Console.ReadLine());

            bool canShootEnemy =
                (X - enemyPlaneX) * (X - enemyPlaneX) +
                (Y - enemyPlaneY) * (Y - enemyPlaneY) <= distance * distance;
            if (canShootEnemy)
            {
                Console.WriteLine("You destroyed a plane at [{0},{1}]", enemyPlaneX, enemyPlaneY);
            }
        }
    }
}