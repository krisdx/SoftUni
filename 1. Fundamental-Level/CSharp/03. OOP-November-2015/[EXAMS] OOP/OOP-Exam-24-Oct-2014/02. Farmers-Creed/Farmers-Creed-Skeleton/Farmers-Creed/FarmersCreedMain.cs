namespace FarmersCreed
{
    using System;
    using FarmersCreed.Simulator;

    public class FarmersCreedMain
    {
        public static void Main()
        {
            ExtendedFarmSimulator simulator = new ExtendedFarmSimulator();
            simulator.Run();
        }
    }
}