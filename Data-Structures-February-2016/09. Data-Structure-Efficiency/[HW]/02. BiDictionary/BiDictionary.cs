namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// BiDictionary allows adding triples {key1, key2, value} and fast search by key1, key2 or by both key1 and key2. Allow multiple values to be stored for given key
    /// </summary>
    /// <typeparam name="K1">The first key</typeparam>
    /// <typeparam name="K2">The second key</typeparam>
    /// <typeparam name="T">The type T is list of values (T)</typeparam>
    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFistKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFistKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        /// <summary>
        /// Adds a value by both keys.
        /// </summary>
        /// <param name="key1">The first key</param>
        /// <param name="key2">The second key</param>
        /// <param name="value">The value to be added</param>
        public void Add(K1 key1, K2 key2, T value)
        {
            if (!this.valuesByFistKey.ContainsKey(key1))
            {
                this.valuesByFistKey[key1] = new List<T>();
            }
            this.valuesByFistKey[key1].Add(value);

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey[key2] = new List<T>();
            }
            this.valuesBySecondKey[key2].Add(value);

            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys.Add(tuple, new List<T>());
            }
            this.valuesByBothKeys[tuple].Add(value);
        }

        /// <summary>
        /// Gets the values by both keys.
        /// </summary>
        /// <param name="key1">The first key</param>
        /// <param name="key2">The second key</param>
        /// <returns>Returns the values by both keys. Returns null if one or both key does not exist</returns>
        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return null;
            }

            return this.valuesByBothKeys[tuple];
        }

        /// <summary>
        /// Gets the values by the first key only.
        /// </summary>
        /// <param name="key1">The first key</param>
        /// <returns>Returns the values by the first key only. Returns null if the key does not exists</returns>
        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (!this.valuesByFistKey.ContainsKey(key1))
            {
                return null;
            }

            return this.valuesByFistKey[key1];
        }

        /// <summary>
        /// Gets the values by the second key only.
        /// </summary>
        /// <param name="key2">The second key</param>
        /// <returns>Returns the values by the second key only. Returns null if the key does not exists</returns>
        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                return null;
            }

            return this.valuesBySecondKey[key2];
        }

        /// <summary>
        /// Removes the values for both keys.
        /// </summary>
        /// <param name="key1">The first key</param>
        /// <param name="key2">The second key</param>
        /// <returns>Returns true or false whether the value has been removed</returns>
        public bool Remove(K1 key1, K2 key2)
        {
            if (!this.valuesByFistKey.ContainsKey(key1))
            {
                return false;
            }

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                return false;
            }

            this.valuesByFistKey.Remove(key1);
            this.valuesBySecondKey.Remove(key2);

            var tuple = new Tuple<K1, K2>(key1, key2);
            this.valuesByBothKeys.Remove(tuple);
            return true;
        }
    }
}