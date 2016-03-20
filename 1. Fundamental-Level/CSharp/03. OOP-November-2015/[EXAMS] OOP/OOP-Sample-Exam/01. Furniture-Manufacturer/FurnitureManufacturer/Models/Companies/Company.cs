namespace FurnitureManufacturer.Models.Companies
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private IList<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;

            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The company name cannot be empty.");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentException("The company name cannot be less tha 5 symbols.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            private set
            {
                this.IsRegistationNumberOnlyDigits(value);

                if (value.Length != 10)
                {
                    throw new ArgumentException("The company registration number must be exactly 10 digits.");
                }

                this.registrationNumber = value;
            }
        }

        private void IsRegistationNumberOnlyDigits(string registrationNumber)
        {
            for (int i = 0; i < registrationNumber.Length; i++)
            {
                if (!char.IsDigit(registrationNumber[i]))
                {
                    throw new ArgumentException("The company registration number must hold only digits.");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            IFurniture furniture =
                this.furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
            return furniture;
        }

        public string Catalog()
        {
            StringBuilder output = new StringBuilder();

            output.Append(string.Format("{0} - {1} - {2} {3}",
             this.Name,
             this.RegistrationNumber,
             this.furnitures.Count != 0 ? this.furnitures.Count.ToString() : "no",
             this.furnitures.Count != 1 ? "furnitures" : "furniture"));

            if (this.furnitures.Count > 0)
            {
                var sortedFurnitures = this.furnitures
                    .OrderBy(f => f.Price)
                    .ThenBy(f => f.Model);

                foreach (var furniture in sortedFurnitures)
                {
                    output.AppendLine();
                    output.Append(furniture.ToString());
                }
            }

            return output.ToString();
        }
    }
}