using System;

class AccountInformation //-k.d
{
    static void Main()
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        uint clientID = uint.Parse(Console.ReadLine());
        decimal totalAccountBalance = decimal.Parse(Console.ReadLine());

        string isActive = "";
        if (totalAccountBalance >= 0)
        {
            isActive = "yes";
        }
        else
        {
            isActive = "no";
        }

        Console.WriteLine("Hello, {0} {1}\nClient id: {2}\nTotal balance: {3:F2}\nActive: {4}", firstName, lastName, clientID, totalAccountBalance, isActive);
    }
}
