namespace CollectionOfPersons
{
    using System.Collections.Generic;
    using System.Linq;
    using CollectionOfPersons.Interfaces;

    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private Dictionary<string, Person> byEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> byEmailDomain = new Dictionary<string, SortedSet<Person>>();
        private Dictionary<string, SortedSet<Person>> byNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private OrderedDictionary<int, SortedSet<Person>> byAge = new OrderedDictionary<int, SortedSet<Person>>();
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> byTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

        public int Count
        {
            get { return this.byEmail.Count; }
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.byEmail.ContainsKey(email))
            {
                return false;
            }

            var person = new Person(email, name, age, town);

            // Add by email
            this.byEmail[email] = person;

            // Add by domain
            string emailDomain = this.ExtractEmailDomain(email);
            if (!this.byEmailDomain.ContainsKey(emailDomain))
            {
                this.byEmailDomain[emailDomain] = new SortedSet<Person>();
            }
            this.byEmailDomain[emailDomain].Add(person);

            // Add by name and town
            string nameAndTownKey = this.CombineNameAndTown(name, town);
            if (!this.byNameAndTown.ContainsKey(nameAndTownKey))
            {
                this.byNameAndTown[nameAndTownKey] = new SortedSet<Person>();
            }
            this.byNameAndTown[nameAndTownKey].Add(person);

            // Add by age
            if (!this.byAge.ContainsKey(age))
            {
                this.byAge[age] = new SortedSet<Person>();
            }
            this.byAge[age].Add(person);

            // Add by town and age
            if (!this.byTownAndAge.ContainsKey(town))
            {
                this.byTownAndAge[town] = new OrderedDictionary<int, SortedSet<Person>>();
            }
            if (!this.byTownAndAge[town].ContainsKey(age))
            {
                this.byTownAndAge[town][age] = new SortedSet<Person>();
            }
            this.byTownAndAge[town][age].Add(person);

            return true;
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            // Delete by email
            this.byEmail.Remove(email);

            // Delete by domain
            string emailDomain = this.ExtractEmailDomain(email);
            this.byEmailDomain[emailDomain].Remove(person);

            // Delete by town and key
            string nameAndTownKey = this.CombineNameAndTown(person.Name, person.Town);
            this.byNameAndTown[nameAndTownKey].Remove(person);

            // Delete by age
            this.byAge[person.Age].Remove(person);

            // Deleteby town and age
            this.byTownAndAge[person.Town][person.Age].Remove(person);

            return true;
        }

        public Person FindPerson(string email)
        {
            if (!this.byEmail.ContainsKey(email))
            {
                return null;
            }

            return this.byEmail[email];
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            if (!this.byEmailDomain.ContainsKey(emailDomain))
            {
                return Enumerable.Empty<Person>();
            }

            return this.byEmailDomain[emailDomain];
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            string key = this.CombineNameAndTown(name, town);
            if (!this.byNameAndTown.ContainsKey(key))
            {
                return Enumerable.Empty<Person>();
            }

            return this.byNameAndTown[key];
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var persons = this.byAge.Range(startAge, true, endAge, true);
            
            foreach (var pair in persons)
            {
                foreach (var person in pair.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            if (!this.byTownAndAge.ContainsKey(town))
            {
                yield break;
            }

            var persons = this.byTownAndAge[town].Range(startAge, true, endAge, true);
            foreach (var pair in persons)
            {
                foreach (var person in pair.Value)
                {
                    yield return person;
                }
            }
        }

        private string ExtractEmailDomain(string email)
        {
            var domain = email.Split('@')[1];
            return domain;
        }

        private string CombineNameAndTown(string name, string town)
        {
            string keySeperator = "|!|";
            return name + keySeperator + town;
        }
    }
}