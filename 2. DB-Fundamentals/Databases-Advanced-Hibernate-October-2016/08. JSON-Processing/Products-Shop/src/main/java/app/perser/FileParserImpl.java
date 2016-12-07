package app.perser;

import org.springframework.stereotype.Component;

import java.io.*;

@Component
public class FileParserImpl implements FileParser{

    @Override
    public String read(String fileName) throws IOException {
        StringBuilder content = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream(fileName)))) {
            String line = null;
            while ((line = reader.readLine()) != null) {
                content.append(line);
            }
        }

        return content.toString();
    }

    @Override
    public void write(String content, String fileName) throws IOException {
        try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(fileName)))) {
            writer.write(content);
        }
    }
}