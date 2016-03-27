namespace CollectionOfPersons
{
    using System.Collections.Generic;
    using System.Linq;

    using CollectionOfPersons.Interfaces;

    public class PersonCollectionSlow : IPersonCollection
    {
        private IList<Person> persons = new List<Person>();
        
        public int Count
        {
            get { return this.persons.Count; }
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.persons.Any(p => p.Email == email))
            {
                return false;
            }

            var person = new Person(email, name, age, town);

            this.persons.Add(person);
            return true;
        }
        
        public Person FindPerson(string email)
        {
            return this.persons.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            this.persons.Remove(person);
            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return this.persons
                .Where(p => p.Email.EndsWith("@" + emailDomain))
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return this.persons
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return this.persons
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .Where(p => p.Town == town)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }
    }
}