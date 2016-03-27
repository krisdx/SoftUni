namespace Sorting
{
    using System.Collections.Generic;

    public class Sequence
    {
        public Sequence(IList<int> numbers, int permutationsCount = 0)
        {
            this.Numbers = numbers;
            this.PermutationsCount = permutationsCount;
        }

        public IList<int> Numbers { get; private set; }

        public int PermutationsCount { get; private set; }

        public override string ToString()
        {
            return string.Join(", ", this.Numbers);
        }
    }
}