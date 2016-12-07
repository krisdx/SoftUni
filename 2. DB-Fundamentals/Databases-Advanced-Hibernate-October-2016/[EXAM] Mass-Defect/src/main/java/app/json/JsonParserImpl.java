package app.json;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.springframework.stereotype.Component;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

@Component
public class JsonParserImpl implements JsonParser {

    private Gson gson;

    public JsonParserImpl() {
        this.setGson(new GsonBuilder().setPrettyPrinting().create());
    }

    public Gson getGson() {
        return this.gson;
    }

    public void setGson(Gson gson) {
        this.gson = gson;
    }

    public <T> T readFromJson(Class<T> classes, String file) {
        String fileData = null;
        T objects = null;

        try {
            fileData = new String(Files.readAllBytes(Paths.get(file)));
            objects = this.getGson().fromJson(fileData, classes);
        } catch (IOException ioEx) {
            ioEx.printStackTrace();
        }

        return objects;
    }

    @Override
    public <T> void writeToJson(T object, String file) {
        String json = this.getGson().toJson(object);

        try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))) {
            writer.write(json);
        } catch (IOException ioEx) {
            ioEx.printStackTrace();
        }
    }
}