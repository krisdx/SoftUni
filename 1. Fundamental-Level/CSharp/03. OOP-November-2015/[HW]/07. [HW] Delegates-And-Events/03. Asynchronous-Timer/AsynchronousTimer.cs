using System;

public class AsynchronousTimer
{
    public event EventHandler OnTick;

    public AsynchronousTimer(Action action, int ticksCount, int interval)
    {
        this.TicksCount = ticksCount;
        this.Interval = interval;
    }

    public void Run()
    {
        while (this.TicksCount > 0)
        {
            
        }
    }

    public int  TicksCount { get; set; }

    public int Interval { get; set; }
}