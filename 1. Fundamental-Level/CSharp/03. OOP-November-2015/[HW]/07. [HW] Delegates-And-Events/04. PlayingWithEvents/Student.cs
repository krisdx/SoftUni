using System;
using System.ComponentModel;

public class Student
{
    public delegate void PropertyChangedEventHandler(object obj, PropertyChangedEventArgs args);

    public event PropertyChangedEventHandler OnPropertyChange;

    private int age;
    private string name;

    public Student(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            this.FirePropertyChangedEvent("Age", this.age, value);
            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            this.FirePropertyChangedEvent("Name", this.name, value);
            this.name = value;
        }
    }

    private void FirePropertyChangedEvent(string propertyName, object oldValue, object newValue)
    {
        if (this.OnPropertyChange != null)
        {
            this.OnPropertyChange(this, new PropertyChangedEventArgs(propertyName, oldValue, newValue));
        }
    }
}