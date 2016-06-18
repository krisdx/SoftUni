package filesAndStreams;

import java.io.*;

public class Problem7_ReadFromSpecifiedLine {
    public static void main(String[] args) throws IOException {

        try (BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
             BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(System.out))) {
            int lineNumber = Integer.valueOf(reader.readLine());
            for (int i = 0; i < lineNumber; i++) {
                reader.readLine();
            }

            String line;
            while ((line = reader.readLine()) != null) {
                writer.write(line);
                writer.newLine();
            }
        }
    }
}