public delegate double CalcualteInterest(double money, double interest, int years);

public class InterestCalculator
{
    private readonly CalcualteInterest interestDelegate;

    public InterestCalculator(double money, double interest, int years, CalcualteInterest interestDelegate)
    {
        this.Money = money;
        this.Interest = interest;
        this.Years = years;
        this.interestDelegate = interestDelegate;
    }

    public double Money { get; set; }

    public double Interest { get; set; }

    public int Years { get; set; }

    public override string ToString()
    {
        return string.Format("{0:f4}", this.interestDelegate(this.Money, this.Interest, this.Years));
    }
}