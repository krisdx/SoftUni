namespace BookStore
{
    using BookStore.Books;
    using BookStore.Interfaces;
    using BookStore.UI;
    using Engine;

    public class BookStoreMain
    {
        public static void Main()
        {
            IInputHandler inputHandler = new ConsoleInputHandler();
            IRenderer renderer = new ConsoleRenderer();

            BookStoreEngine engine = new BookStoreEngine(renderer, inputHandler);

            engine.Run();
        }
    }
}
