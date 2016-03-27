namespace Trees
{
    using System;
    using System.Collections.Generic;

    public class Tree<T>
    {
        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;

            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }

        public T Value { get; private set; }

        public IList<Tree<T>> Children { get; private set; }

        public void Print(int spacesCount = 0)
        {
            Console.WriteLine(new string(' ', spacesCount) + this.Value);
            foreach (var child in this.Children)
            {
                child.Print(spacesCount + 2);
            }
        }

        public void Each(Action<T> action)
        {
            action(this.Value);
            foreach (var child in this.Children)
            {
                child.Each(action);
            }
        }
    }
}