package problem10_11_12_13_InfernoInfinity.io;

import problem10_11_12_13_InfernoInfinity.contracts.IO.Readable;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ConsoleReader implements Readable {

    private BufferedReader reader;

    public ConsoleReader() {
        this.initReader();
    }

    @Override
    public String read() throws IOException {
        return reader.readLine();
    }

    private void initReader() {
        this.reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );
    }
}