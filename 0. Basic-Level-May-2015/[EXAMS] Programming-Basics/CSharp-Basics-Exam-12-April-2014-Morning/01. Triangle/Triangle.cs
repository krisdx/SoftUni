using System;

public class Triangle 
{
    public static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double ab = Math.Sqrt(
            (bX - aX) * (bX - aX) +
            (bY - aY) * (bY - aY));

        double bc = Math.Sqrt(
            (bX - cX) * (bX - cX) +
            (bY - cY) * (bY - cY));

        double ca = Math.Sqrt(
            (cX - aX) * (cX - aX) +
            (cY - aY) * (cY - aY));

        bool canFormATriangle =
            ab + bc > ca && ab + ca > bc && ca + bc > ab;

        if (!canFormATriangle)
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", ab);
        }
        else
        {
            Console.WriteLine("Yes");
            double p = (ab + bc + ca) / 2;
            double area = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));
            Console.WriteLine("{0:F2}", area);
        }
    }
}