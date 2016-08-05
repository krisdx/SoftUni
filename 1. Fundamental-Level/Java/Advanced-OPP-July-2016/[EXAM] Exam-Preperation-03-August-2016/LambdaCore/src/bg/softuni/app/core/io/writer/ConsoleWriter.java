package bg.softuni.app.core.io.writer;

// TODO: use Buffered Reader?
public class ConsoleWriter implements Writer{

    @Override
    public void write(String message) {
        System.out.print(message);
    }

    @Override
    public void writeLine(String message) {
        System.out.println(message);
    }

    @Override
    public void displayException(Exception exception) {
        System.err.println(exception.getMessage());
    }
}