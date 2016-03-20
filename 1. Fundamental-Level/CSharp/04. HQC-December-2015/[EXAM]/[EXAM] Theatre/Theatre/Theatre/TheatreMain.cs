namespace Theatre
{
    using Theatre.Core;
    using Theatre.Data;
    using Theatre.IO;

    public class TheatreMain
    {
        public static void Main()
        {
            var theatreDatabase = new TheatreDatabase();
            var consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter();

            var engine = new TheatreEngine(theatreDatabase, consoleReader, consoleWriter);
            engine.Run();
        }
    }
}