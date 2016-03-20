using System;

public class PlayingWithEventsMain
{
    public static void Main()
    {
        Student pesho = new Student("Pesho", 18);
        pesho.OnPropertyChange += OnPropertyChangeEvent;
        pesho.Name = "Gunio";
        pesho.Age = 40;
    }

    static void OnPropertyChangeEvent(object obj, PropertyChangedEventArgs eventArgs)
    {
        Console.WriteLine("Property changed: {0} (from {1} to {2})",
           eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
    }
}