package bg.softuni.app.core.io.reader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Uses BufferedReader to read the input from
 * the standard input stream.
 *
 * @see BufferedReader
 */
public class ConsoleReader implements Reader {

    private BufferedReader reader;

    public ConsoleReader() {

        this.reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );
    }

    @Override
    public String readLine() throws IOException {
        return this.reader.readLine().trim();
    }
}