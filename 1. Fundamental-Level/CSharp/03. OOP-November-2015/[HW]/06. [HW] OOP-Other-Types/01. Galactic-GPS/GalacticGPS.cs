using System;
using _01.Galactic_GPS;

public class GalacticGPS
{
    static void Main()
    {
        Location home = new Location(18.037986, 28.870097, Planet.Earth);
        Console.WriteLine(home);

    }
}