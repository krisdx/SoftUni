package app.perser;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.io.IOException;

@Component
public class JsonParserImpl implements JsonParser {

    private Gson gson;

    @Autowired
    private FileParser fileParser;

    public JsonParserImpl() {
        this.gson = new GsonBuilder()
                .excludeFieldsWithoutExposeAnnotation()
                .setPrettyPrinting()
                .create();
    }

    @Override
    public Gson getGson() {
        return this.gson;
    }

    public void setGson(Gson gson) {
        this.gson = gson;
    }

    @Override
    public <T> T importFromJson(Class<T> tClass, String fileName) throws IOException {
        String json = this.fileParser.read(fileName);
        return this.getGson().fromJson(json, tClass);
    }

    @Override
    public <T> void exportToJson(T object, String fileName) throws IOException {
        String json = this.getGson().toJson(object);
        this.fileParser.write(json, fileName);
    }
}