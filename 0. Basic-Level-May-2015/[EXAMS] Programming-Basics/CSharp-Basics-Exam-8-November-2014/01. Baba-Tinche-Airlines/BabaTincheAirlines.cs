using System;

class BabaTincheAirlines //-k.d
{
    static void Main()
    {
        string[] firstClassPassengers = Console.ReadLine().Split(' ');
        string[] businessClassPassengers = Console.ReadLine().Split(' '); ;
        string[] economyClassPassengers = Console.ReadLine().Split(' ');

        double firstClassSum = 0;
        double allPassengersInFirstClass = double.Parse(firstClassPassengers[0]);
        double frequentFlyersInFirstClass = double.Parse(firstClassPassengers[1]);
        double passengersWithMealsInFirstClass = double.Parse(firstClassPassengers[2]);

        firstClassSum += (allPassengersInFirstClass - frequentFlyersInFirstClass) * 7000;
        firstClassSum += passengersWithMealsInFirstClass * ((7000 * 0.005));
        firstClassSum += frequentFlyersInFirstClass * (7000 - (7000 * 0.7));


        double bussinessClassSum = 0;
        double allPassengersInBusinessClass = double.Parse(businessClassPassengers[0]);
        double frequentFlyersInBusinessClass = double.Parse(businessClassPassengers[1]);
        double passengersWithMealsInBusinessClass = double.Parse(businessClassPassengers[2]);

        bussinessClassSum += (allPassengersInBusinessClass - frequentFlyersInBusinessClass) * 3500;
        bussinessClassSum += passengersWithMealsInBusinessClass * ((3500 * 0.005));
        bussinessClassSum += frequentFlyersInBusinessClass * (3500 - (3500 * 0.7));


        double economyClassSum = 0;
        double allPassengersInEconomyClass = double.Parse(economyClassPassengers[0]);
        double frequentFlyersInEconomyClass = double.Parse(economyClassPassengers[1]);
        double passengersWithMealsInEconomyClass = double.Parse(economyClassPassengers[2]);

        economyClassSum += (allPassengersInEconomyClass - frequentFlyersInEconomyClass) * 1000;
        economyClassSum += passengersWithMealsInEconomyClass * ((1000 * 0.005));
        economyClassSum += frequentFlyersInEconomyClass * (1000 - (1000 * 0.7));


        int totalIncome = (int)(firstClassSum + bussinessClassSum + economyClassSum);
        int maxPossibleIncome = (12 * 7000) + (28 * 3500) + (50 * 1000);
        maxPossibleIncome += (int)((12 * (0.005 * 7000)) + (28 * (0.005 * 3500)) + (50 * (0.005 * 1000)));

        Console.WriteLine((int)totalIncome);
        Console.WriteLine((int)(maxPossibleIncome - totalIncome));
    }
}