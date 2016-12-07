package app.json;

import java.io.IOException;

public interface JsonParser {
    <T> T readFromJson(Class<T> classes, String file);

    <T> void writeToJson(T object, String file) throws IOException;
}