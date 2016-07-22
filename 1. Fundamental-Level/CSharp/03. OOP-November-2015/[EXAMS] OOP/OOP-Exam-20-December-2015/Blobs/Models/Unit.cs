namespace Blobs.Models
{
    using System;

    using Blobs.Interfaces;

    public abstract class Unit : IUnit
    {
        private string name; 

        protected Unit(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name cannot be null.");
                }

                this.name = value;
            }
        }
    }
}