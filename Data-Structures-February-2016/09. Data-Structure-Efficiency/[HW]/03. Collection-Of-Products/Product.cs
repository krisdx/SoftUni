namespace CollectionOfProducts
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string id, string title, string supplier, double price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() + this.Title.GetHashCode() + this.Supplier.GetHashCode();
        }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nTitle: {1}\nSupplier: {2}\nPrice: {3:F2}",
                this.Id, this.Title, this.Supplier, this.Price);
        }
    }
}