package app.perser;

import java.io.IOException;

public interface FileParser {
    String read(String fileName) throws IOException;

    void write(String content, String fileName) throws IOException;
}