namespace ProcessorScheduling
{
    using System;

    public class Task : IComparable<Task>
    {
        public Task(int number, int deadLine, int value)
        {
            this.Number = number;
            this.DeadLine = deadLine;
            this.Value = value;
        }

        public int Number { get; private set; }

        public int DeadLine { get; private set; }

        public int Value { get; private set; }

        public int CompareTo(Task other)
        {
            return other.Value.CompareTo(this.Value);
        }

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}