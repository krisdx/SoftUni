namespace _02.Bank_Of_Kurtovo_Konare.Interfaces
{
    using _02.Bank_Of_Kurtovo_Konare.Models;

    public interface IAccount
    {
        decimal Balance { get; set; }

        decimal InterestRate { get; set; }

        Customer Customer { get; set; }

        void DepositMoney(decimal money);

        decimal CalculateInterest(int months);
    }
}