using System;

// A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account. Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

class BankAccountData
{
    static void Main()
    {
        string firstName = "Kristiyan";
        string middleName = "Tekle";
        string lastName = "Duba";
        int moneyBalance = 300000;
        string bankName = "Kris";
        string IBAN = "BG77 1234 5678 9012 3456 78";
        string creditCard1 = "1313 1313 1313 1313";
        string creditCard2 = "1515 1515 1515 1515";
        string creditCard3 = "1919 1919 1919 1919";
        Console.WriteLine("Your Bank Account: \n\n{0} {1} {2}.\nMoney balance: {3:C}\nBank Name: {4}\nIBAN: {5}\nYour credit card numbers:\nCredit card  №1: {6}\nCredit card  №2: {7}\nCredit card  №3: {8}\n", firstName, middleName, lastName, moneyBalance, bankName, IBAN, creditCard1, creditCard2, creditCard3);
    }
}