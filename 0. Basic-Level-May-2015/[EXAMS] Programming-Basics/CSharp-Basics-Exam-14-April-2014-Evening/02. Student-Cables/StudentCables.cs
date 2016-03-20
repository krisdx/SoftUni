using System;

class StudentCables //-k.d
{
    static void Main()
    {
        int numberOfCables = int.Parse(Console.ReadLine());

        int totalCablesLength = 0;
        int cablesCounter = 0;
        for (int i = 0; i < numberOfCables; i++)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string cableMeasure = Console.ReadLine();

            if (cableMeasure == "meters")
            {
                cableLength *= 100;
            }
            if (cableLength < 20)
            {
                continue;
            }
            totalCablesLength += cableLength;
            cablesCounter++;
        }
        totalCablesLength -= (cablesCounter - 1) * 3; 

        int studentsCables = totalCablesLength / 504;
        int remainingCable = totalCablesLength % 504;

        Console.WriteLine(studentsCables);
        Console.WriteLine(remainingCable);
    }
}