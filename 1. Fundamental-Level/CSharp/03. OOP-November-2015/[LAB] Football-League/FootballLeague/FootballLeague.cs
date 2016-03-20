using System;

public class FootballLeague
{
    public static void Main() // I didn't have time to finish it :((
    {
        string line = Console.ReadLine();
        while (line != "End")
        {
            try
            {
                LeagueManager.HandleInput(line);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            line = Console.ReadLine();
        }
    }
}