using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GenericList<T> where T: IComparable
{
    private const int defaultCapacity = 16;
    private T[] elements;
    private int capacity;
    private int currentIndex;

    public GenericList(int capacity = defaultCapacity)
    {
        this.Capacity = capacity;
        this.elements = new T[capacity];
        this.currentIndex = 0;
    }

    public int Capacity
    {
        get
        {
            return this.capacity;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("The capacity cannot be negative.");
            }

            this.capacity = value;
        }
    }

    public int Count
    {
        get { return this.currentIndex; }
        private set { this.currentIndex = value; }
    }

    public void Add(T element)
    {
        if (this.currentIndex + 1 == this.Capacity)
        {
            DoubleCapacity();
        }

        this.elements[this.currentIndex] = element;
        this.currentIndex++;
    }

    private void DoubleCapacity()
    {
        T[] doubleSizedArray = new T[this.Capacity * 2];
        for (int i = 0; i < this.Capacity; i++)
        {
            doubleSizedArray[i] = this.elements[i];
        }

        this.elements = doubleSizedArray.ToArray();
        this.Capacity = doubleSizedArray.Length;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > this.Capacity)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            return this.elements[index];
        }
        set
        {
            if (index < 0 || index > this.Capacity)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }

            this.elements[index] = value;
        }
    }

    public void Remove(int index)
    {
        T[] newArray = new T[this.elements.Length - 1];
        int elementCounter = 0;
        for (int i = 0; i < newArray.Length; i++)
        {
            if (elementCounter == index)
            {
                elementCounter++;
            }

            newArray[i] = this.elements[elementCounter];
            elementCounter++;
        }

        this.currentIndex--;

        this.elements = newArray.ToArray();
    }

    public void Insert(int index, T element)
    {
        T[] newArray = new T[this.elements.Length + 1];
        int elementCounter = 0;
        for (int i = 0; i < newArray.Length; i++)
        {
            if (i == index)
            {
                newArray[i] = element;
                continue;
            }

            newArray[i] = this.elements[elementCounter];
            elementCounter++;
        }

        this.currentIndex++;

        this.elements = newArray.ToArray();
    }

    public void Clear()
    {
        for (int i = 0; i < this.currentIndex; i++)
        {
            this.elements[i] = default (T);
        }

        this.Capacity = defaultCapacity;
        this.currentIndex = 0;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < this.currentIndex; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.currentIndex; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public T Max()
    {
        T maxElement = this.elements[0];
        for (int i = 0; i < this.currentIndex; i++)
        {
            if (this.elements[i].CompareTo(maxElement) == 1)
            {
                maxElement = this.elements[i];
            }
        }

        return maxElement;
    }

    public T Min()
    {
        T minElement = this.elements[0];
        for (int i = 0; i < this.currentIndex; i++)
        {
            if (this.elements[i].CompareTo(minElement) == -1)
            {
                minElement = this.elements[i];
            }
        }

        return minElement;
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < currentIndex; i++)
        {
            if (i < currentIndex - 1)
            {
                output.AppendFormat("{0}, ", this.elements[i]);
            }
            else
            {
                output.Append(this.elements[i]);
            }
        }

        return output.ToString();
    }
}