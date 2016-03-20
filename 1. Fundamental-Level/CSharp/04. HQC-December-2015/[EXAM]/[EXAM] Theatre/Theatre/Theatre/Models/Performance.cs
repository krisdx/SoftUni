namespace Theatre.Models
{
    using System;
    using Theatre.Interfaces;

    public class Performance : IPerformance
    {
        private string theatreName;
        private string performanceTitle;
        private decimal price;

        public Performance(string theatreName, string performanceTitle, DateTime startTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartTime = startTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName
        {
            get
            {
                return this.theatreName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The theatre name cannot be empty.");
                }

                this.theatreName = value;
            }
        }

        public string PerformanceTitle
        {
            get
            {
                return this.performanceTitle;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The performance title cannot be empty.");
                }

                this.performanceTitle = value;
            }
        }

        public DateTime StartTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw  new ArgumentOutOfRangeException("The price of the performance cannot be negative.");
                }

                this.price = value;
            }
        }

        public int CompareTo(IPerformance otherPerformance)
        {
            int index = this.StartTime.CompareTo(otherPerformance.StartTime);
            return index;
        }
    }
}