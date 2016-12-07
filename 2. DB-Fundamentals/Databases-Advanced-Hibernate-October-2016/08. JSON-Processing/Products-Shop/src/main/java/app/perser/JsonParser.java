package app.perser;

import com.google.gson.Gson;

import java.io.IOException;

public interface JsonParser {
    Gson getGson();

    <T> T importFromJson(Class<T> tClass, String fileName) throws IOException;

    <T> void exportToJson(T object, String fileName) throws IOException;
}