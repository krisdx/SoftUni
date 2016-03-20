public class Tomcat : Cat
{
    public Tomcat(string name, int age)
        : base(name, age)
    {
    }

    public override string Genger
    {
        get
        {
            return "male";
        }
    }
}