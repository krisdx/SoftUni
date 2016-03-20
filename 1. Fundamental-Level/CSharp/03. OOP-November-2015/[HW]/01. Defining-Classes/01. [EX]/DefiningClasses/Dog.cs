namespace DefiningClasses
{
    class Dog
    {
        public Dog()
        {
        }

        public Dog(string name, string breed)
        {
            this.Name = name;
            this.Breed = breed;
        }

        public string Name { get; set; }

        public string Breed { get; set; }

        public void Bark()
        {
            System.Console.WriteLine("{0} ({1}), said BAU!",
                this.Name?? "[unnamed]", 
                this.Breed?? "no breed");
        }
    }
}