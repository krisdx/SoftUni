namespace DefiningClasses
{
    class DefiningClassesMain
    {
        static void Main()
        {
            Dog rex = new Dog("rex", "nemska ovcharka");
            Dog unnamedDog = new Dog();

            rex.Bark();
            unnamedDog.Bark();
        }
    }
}