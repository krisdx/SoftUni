using System;

class BasketBattle 
{
    static void Main() //k.d
    {
        string firstPlayerToShoot = Console.ReadLine();
        int rounds = int.Parse(Console.ReadLine());

        //who is first
        bool isNakovTurn = false; 
        bool isSimeonTurn = false;
        if (firstPlayerToShoot == "Nakov")
        {
            isNakovTurn = true;
            isSimeonTurn = false;
        }
        else
        {
            isNakovTurn = false;
            isSimeonTurn = true;
        }

        // play game
        int nakovPoints = 0;
        int simeonPoints = 0;
        int targetPoints;
        string failOrSucceeded;
        for (int round = 1; round <= rounds; round++)
        {
            // First player shoots
            targetPoints = int.Parse(Console.ReadLine());
            failOrSucceeded = Console.ReadLine();

            if (failOrSucceeded != "fail")
            {
                if (isNakovTurn)
                {
                    if (nakovPoints + targetPoints <= 500) //can't make more tha 500
                    {
                        nakovPoints += targetPoints;
                    }
                    //swich turns
                    isNakovTurn = false; 
                    isSimeonTurn = true;
                }
                else // Simeon
                {
                    if (simeonPoints + targetPoints <= 500) //can't make more tha 500
                    {
                        simeonPoints += targetPoints;
                    }
                    //swich turns
                    isNakovTurn = true;
                    isSimeonTurn = false;
                }
            }
            else // if fail just swich turns
            {
                isNakovTurn = !isNakovTurn;
                isSimeonTurn = !isSimeonTurn;
            }

            // chek if there is a winner
            if (simeonPoints == 500)
            {
                Console.WriteLine("Simeon");
                Console.WriteLine(round);
                Console.WriteLine(nakovPoints);
                return;
            }
            if (nakovPoints == 500)
            {
                Console.WriteLine("Nakov");
                Console.WriteLine(round);
                Console.WriteLine(simeonPoints);
                return;
            }
           

            // Second player shoots
            targetPoints = int.Parse(Console.ReadLine());
            failOrSucceeded = Console.ReadLine();

            if (failOrSucceeded != "fail")
            {
                if (isNakovTurn)
                {
                    if (nakovPoints + targetPoints <= 500) //can't make more tha 500
                    {
                        nakovPoints += targetPoints;
                    }
                    // switch turns
                    isNakovTurn = false;
                    isSimeonTurn = true;
                }
                else // Simeon turn
                {
                    if (simeonPoints + targetPoints <= 500) //can't make more tha 500
                    {
                        simeonPoints += targetPoints;
                    }
                    // switch turns
                    isNakovTurn = true;
                    isSimeonTurn = false;
                }
            }
            else // if fail just swich turns
            {
                isNakovTurn = !isNakovTurn;
                isSimeonTurn = !isSimeonTurn;
            }

            // chek if there is a winner again
            if (simeonPoints >= 500)
            {
                Console.WriteLine("Simeon");
                Console.WriteLine(round);
                Console.WriteLine(nakovPoints);
                return;
            }
            if (nakovPoints >= 500)
            {
                Console.WriteLine("Nakov");
                Console.WriteLine(round);
                Console.WriteLine(simeonPoints);
                return;
            }

            // switch turns againg for the next round
            isNakovTurn = !isNakovTurn;
            isSimeonTurn = !isSimeonTurn;
        }

        // end of rounds
            
        if (simeonPoints == nakovPoints)
        {
            Console.WriteLine("DRAW");
            Console.WriteLine(nakovPoints);
        }
        else
        {
            if (simeonPoints > nakovPoints)
            {
                Console.WriteLine("Simeon");
                Console.WriteLine(Math.Abs(simeonPoints - nakovPoints));
            }
            else
            {
                Console.WriteLine("Nakov");
                Console.WriteLine(Math.Abs(simeonPoints - nakovPoints));
            }
        }
    }
}