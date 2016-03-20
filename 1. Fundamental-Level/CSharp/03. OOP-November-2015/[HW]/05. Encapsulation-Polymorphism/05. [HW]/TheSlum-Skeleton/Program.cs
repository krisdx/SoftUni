namespace TheSlum
{
    using GameEngine;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Engine engine = new CustomEngine();
            engine.Run();
        }
    }
}