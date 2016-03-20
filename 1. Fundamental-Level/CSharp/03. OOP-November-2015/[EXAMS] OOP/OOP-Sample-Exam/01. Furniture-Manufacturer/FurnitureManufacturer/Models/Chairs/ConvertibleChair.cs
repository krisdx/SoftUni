namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Models.Chairs;

    public class ConvertibleChair : BaseChair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;

        private decimal nonConvertedHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.nonConvertedHeight = height;

            this.State = ConvertedChairState.Normal;
        }

        public bool IsConverted { get; private set; }

        public ConvertedChairState State { get; set; }

        public void Convert()
        {
            if (!IsConverted)
            {
                this.Height = ConvertedHeight;
                this.IsConverted = true;
                this.State = ConvertedChairState.Converted;
            }
            else
            {
                this.Height = nonConvertedHeight;
                this.IsConverted = false;
                this.State = ConvertedChairState.Normal;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}