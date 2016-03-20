namespace Theatre.Interfaces
{
    using System;

    public interface IPerformance : IComparable<IPerformance>
    {
        string TheatreName { get; }

        string PerformanceTitle { get; }

        DateTime StartTime { get; }

        TimeSpan Duration { get; }

        decimal Price { get; }
    }
}