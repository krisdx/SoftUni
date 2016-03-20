public class Kitten : Cat
{
    public Kitten(string name, int age)
        : base(name, age)
    {
    }

    public override string Genger
    {
        get
        {
            return "female";
        }
    }
}