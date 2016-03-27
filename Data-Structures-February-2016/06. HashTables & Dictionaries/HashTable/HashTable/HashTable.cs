namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;

        public HashTable(int capacity = DefaultCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.slots.Length; }
        }

        public IEnumerable<TKey> Keys
        {
            get { return this.Select(element => element.Key); }
        }

        public IEnumerable<TValue> Values
        {
            get { return this.Select(element => element.Value); }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.CheckForResize();

            int slotNumber = this.GetSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            bool duplicateKeys = this.slots[slotNumber].Any(element => element.Key.Equals(key));
            if (duplicateKeys)
            {
                throw new ArgumentException("Key already exists: " + key);
            }

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            int slotNumber = this.GetSlotNumber(key);
            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var keyValuePair in this.slots[slotNumber])
            {
                if (keyValuePair.Key.Equals(key))
                {
                    // Replacing the value.
                    keyValuePair.Value = value;
                    return false;
                }
            }

            // Adding the element to the hash table.
            this.CheckForResize();

            var newElement = new KeyValue<TKey, TValue>(key, value);
            this.slots[slotNumber].AddLast(newElement);
            this.Count++;

            return true;
        }

        public TValue Get(TKey key)
        {
            var keyValuePair = this.Find(key);
            if (keyValuePair == null)
            {
                throw new KeyNotFoundException("No such key" + key);
            }

            return keyValuePair.Value;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var keyValuePair = this.Find(key);
            if (keyValuePair != null)
            {
                value = keyValuePair.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = this.GetSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                foreach (var keyValuePair in elements)
                {
                    if (keyValuePair.Key.Equals(key))
                    {
                        return keyValuePair;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            var keyValuePair = this.Find(key);
            return keyValuePair != null;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = this.GetSlotNumber(key);
            var elements = this.slots[slotNumber];
            if (elements != null)
            {
                var currentElement = this.slots[slotNumber].First;
                while (currentElement != null)
                {
                    if (currentElement.Value.Key.Equals(key))
                    {
                        elements.Remove(currentElement);
                        this.Count--;

                        return true;
                    }

                    currentElement = currentElement.Next;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var keyValuePair in this.slots)
            {
                if (keyValuePair != null)
                {
                    foreach (var element in keyValuePair)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetSlotNumber(TKey key)
        {
            var slotNumber = Math.Abs(key.GetHashCode() % this.slots.Length);
            return slotNumber;
        }

        private void CheckForResize()
        {
            if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            var newHashTable = new HashTable<TKey, TValue>(this.Capacity * 2);
            foreach (var keyValuePair in this)
            {
                newHashTable.Add(keyValuePair.Key, keyValuePair.Value);
            }

            this.slots = newHashTable.slots;
            this.Count = newHashTable.Count;
        }
    }
}