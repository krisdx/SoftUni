using System;

class PhoneProcesses
{
    static void Main()
    {
        int initialPhonePower = GetBatteryPower(Console.ReadLine());     

        if (initialPhonePower <= 0)
        {
            Console.WriteLine("Phone Off");
            return;
        }

        string app = Console.ReadLine().ToLower();
        int unExecutedApps = 0;
        while (app != "end")
        {
            string[] appDetails = app.Split(new char[] { '_', '%' }, StringSplitOptions.RemoveEmptyEntries);
            int appPower = int.Parse(appDetails[1]);

            initialPhonePower -= appPower;
            if (initialPhonePower <= 15 && initialPhonePower > 0)
            {
                Console.WriteLine("Connect charger -> {0}%", initialPhonePower);
                app = Console.ReadLine().ToLower();
                while (app != "end")
                {
                    unExecutedApps++;
                    app = Console.ReadLine().ToLower();
                }
                Console.WriteLine("Programs left -> {0}", unExecutedApps);
                return;
            }
            else if (initialPhonePower <= 0)
            {
                Console.WriteLine("Phone Off");
                return;
            }

            app = Console.ReadLine().ToLower();
        }

        if (initialPhonePower > 15)
        {
            Console.WriteLine("Successful complete -> {0}%", initialPhonePower);
        }
    }

    public static int GetBatteryPower(string initialPower)
    {
        string phonePower = string.Empty;
        for (int i = 0; i < initialPower.Length; i++)
        {
            if (char.IsDigit(initialPower[i]))
            {
                phonePower += initialPower[i];
            }
        }
        return int.Parse(phonePower);
    }
}