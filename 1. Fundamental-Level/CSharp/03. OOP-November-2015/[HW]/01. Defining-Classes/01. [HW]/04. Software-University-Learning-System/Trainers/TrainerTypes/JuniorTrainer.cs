public class JuniorTrainer : Trainer
{
    public JuniorTrainer(string firstName, string lastName, int age)
        :base(firstName, lastName, age)
    {
    }

    public override string ToString()
    {
        return string.Format("{0} {1} [Junior Trainer]\nAge - {2}", this.FirstName, this.LastName, this.Age);
    }
}