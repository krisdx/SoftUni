using System;
using System.Linq;

class TeleportPoints // BS
{
    static void Main()
    {
        decimal[] A = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        decimal[] B = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        decimal[] C = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        decimal[] D = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        decimal radius = decimal.Parse(Console.ReadLine());
        decimal step = decimal.Parse(Console.ReadLine());

        int validPoints = 0;
        for (decimal AX = A[0]; AX >= 0; AX -= step)
        {
            for (decimal AY = A[1]; AY >= 0; AY -= step)
            {
                if (AX >= 0 - radius &&
                    AX <= 0 &&
                    AY >= 0 - radius &&
                    AY <= 0)
                {
                    validPoints++;
                }
            }
        }

        for (decimal BX = 0; BX <= B[0]; BX += step)
        {
            for (decimal BY = B[1]; BY >= 0; BY -= step)
            {
                if (BX >= 0 &&
                    BX <= B[0] &&
                    BY >= 0 - radius &&
                    BY <= 0)
                {
                    validPoints++;
                }
            }
        }

        for (decimal CX = 0; CX <= C[0]; CX += step)
        {
            for (decimal CY = 0; CY <= C[1]; CY += step)
            {
                if (CX >= 0 &&
                    CX <= C[0] &&
                    CY >= 0 &&
                    CY <= C[0])
                {
                    validPoints++;
                }
            }
        }

        for (decimal DX = D[0]; DX >= 0; DX -= step)
        {
            for (decimal DY = 0; DY <= D[1]; DY += step)
            {
                if (DX >= 0 - radius &&
                    DX <= 0 &&
                    DY >= 0 &&
                    DY <= D[1])
                {
                    validPoints++;
                }
            }
        }

        Console.WriteLine(validPoints);
    }
}