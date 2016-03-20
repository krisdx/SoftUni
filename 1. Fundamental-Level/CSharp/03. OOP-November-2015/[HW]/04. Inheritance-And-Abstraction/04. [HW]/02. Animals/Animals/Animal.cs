public abstract class Animal : ISoundProducible
{
    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    protected Animal(string name, int age, string gender)
        :this(name, age)
    {
        this.Genger = gender;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public virtual string Genger { get; set; }

    public abstract void ProduceSound();
}