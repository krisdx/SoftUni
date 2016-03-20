using System;

// A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints it back on the console.

class PrintCompanyInformation
{
    static void Main()
    {
        Console.WriteLine("Please enter the following information: \n");

        Console.Write("Company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Company adress: ");
        string companyAdress = Console.ReadLine();

        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Fax number: ");
        string faxNumber = Console.ReadLine();
        if (faxNumber == "")
        {
            faxNumber = "No fax.";
        }

        Console.Write("Web site: ");
        string webSite = Console.ReadLine();

        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Manager first name: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Manager age: ");
        string managerAge = Console.ReadLine();

        Console.Write("Manager phone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("\n\n{0}\nCompany adress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})\n", companyName, companyAdress, phoneNumber, faxNumber, webSite, managerFirstName, managerLastName, managerAge, managerPhone);
    }
}