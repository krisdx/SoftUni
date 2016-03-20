using System;

public class LightTheTorches
{
    public static void Main()
    {
        int totalNumberOfRooms = int.Parse(Console.ReadLine());
        string lights = Console.ReadLine();

        char[] lightInRooms = new char[totalNumberOfRooms];
        for (int i = 0; i < totalNumberOfRooms; i++)
        {
            int index = GetIndex(i, lights);
            lightInRooms[i] = lights[index];
        }

        int currentPosition = totalNumberOfRooms / 2;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            string[] moveingDetails = input.Split();
            string direction = moveingDetails[0];
            int roomsMoved = int.Parse(moveingDetails[1]);

            int positionToLand = GetPosition(currentPosition, roomsMoved, totalNumberOfRooms, direction);
            if (currentPosition != positionToLand)
            {
                if (lightInRooms[positionToLand] == 'L')
                {
                    lightInRooms[positionToLand] = 'D';
                }
                else if (lightInRooms[positionToLand] == 'D')
                {
                    lightInRooms[positionToLand] = 'L';
                }
            }

            currentPosition = positionToLand;
        }

        long reslut = 0;
        for (int i = 0; i < lightInRooms.Length; i++)
        {
            if (lightInRooms[i] == 'D')
            {
                reslut += 'D';
            }
        }

        Console.WriteLine(reslut);
    }

    private static int GetPosition(int currentPosition, int roomsMoved, int totalNumberOfRooms, string direction)
    {
        int positionToLand = 0;

        if (direction == "RIGHT")
        {
            if (currentPosition + roomsMoved + 1 >= totalNumberOfRooms - 1)
            {
                positionToLand = totalNumberOfRooms - 1;
            }
            else
            {
                positionToLand = currentPosition + roomsMoved + 1;
            }
        }
        else
        {
            if (currentPosition - roomsMoved - 1 <= 0)
            {
                positionToLand = 0;
            }
            else
            {
                positionToLand = currentPosition - roomsMoved - 1;
            }
        }

        return positionToLand;
    }

    private static int GetIndex(int i, string str)
    {
        if (i > str.Length - 1)
        {
            return i % str.Length;
        }
        else
        {
            return i;
        }
    }
}