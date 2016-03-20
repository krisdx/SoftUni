using _02.Bank_Of_Kurtovo_Konare.Models;
using System;

public class BankOfKurtovoKonare
{
    static void Main()
    {
        Deposit deposit = new Deposit(Customer.Company, 20000m, 3.4m);
        deposit.DrawMoney(345m);
        deposit.DepositMoney(1000m);
        Console.WriteLine(deposit);
        deposit.CalculateInterestRate(10);
        Console.WriteLine();

        Loan loanIndividual = new Loan(Customer.Individual, 1000m, 20m);
        loanIndividual.DepositMoney(3000m);
        Console.WriteLine(loanIndividual);
        loanIndividual.CalculateInterestRate(5);
        Console.WriteLine();

        Loan loanCompalny = new Loan(Customer.Company, 200000m, 5m);
        loanCompalny.DepositMoney(30000m);
        Console.WriteLine(loanCompalny);
        loanCompalny.CalculateInterestRate(4);
        Console.WriteLine();

        Mortgage mortageIndividual = new Mortgage(Customer.Individual, 500, 3.3m);
        mortageIndividual.DepositMoney(200m);
        Console.WriteLine(mortageIndividual);
        mortageIndividual.CalculateInterestRate(7);
        Console.WriteLine();

        Mortgage mortageCompany = new Mortgage(Customer.Company, 50000, 4m);
        mortageIndividual.DepositMoney(2000m);
        Console.WriteLine(mortageIndividual);
        mortageIndividual.CalculateInterestRate(13);


        Loan loan = new Loan(Customer.Individual, 1.0m, 2.0m);
        Console.WriteLine(loan);
    }
}