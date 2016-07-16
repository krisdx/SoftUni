import IO.InputReader;
import IO.OutputWriter;
import contracts.Printable;
import contracts.Readable;
import core.Engine;
import data.Data;

public class Main {
    public static void main(String[] args) {
        Data data = new Data();
        Printable writer = new OutputWriter();
        Readable reader = new InputReader();

        Engine engine = new Engine(writer, reader, data);
        engine.run();
    }
}