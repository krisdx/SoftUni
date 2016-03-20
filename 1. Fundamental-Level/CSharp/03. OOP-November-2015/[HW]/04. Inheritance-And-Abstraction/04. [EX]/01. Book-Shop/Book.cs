using System;

public class Book
{
    private string title;
    private string author;
    private double price;

    public Book(string title, string author, double price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The title cannot be empty.");
            }

            this.title = value;
        }
    }
    public string Author
    {
        get
        {
            return this.author;
        }
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The title cannot be empty.");
            }

            this.author = value;
        }
    }
    public virtual double Price
    {
        get
        {
            return this.price;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The price cannot be negative.");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        return string.Format("-Type: {0}\n-Title: {1}\n-Author: {2}\n-Price: {3}", this.GetType(), this.title, this.Author, this.Price);
    }
}
