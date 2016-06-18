package filesAndStreams;

import java.io.*;

public class Problem2_LineNumbers {
    public static void main(String[] args) throws IOException {
        String inputTextPath = System.getProperty("user.dir") + "\\resources\\02. LineNumbers\\01_LinesIn.txt";
        String outputTextPath = System.getProperty("user.dir") + "\\resources\\02. LineNumbers\\01_LinesOut.txt";
        try (
                BufferedReader reader = new BufferedReader(
                        new FileReader(inputTextPath));
                BufferedWriter writer = new BufferedWriter(
                        new FileWriter(outputTextPath))
        ) {
            String line;
            int count = 1;
            while ((line = reader.readLine()) != null) {
                writer.write(count + ". ");
                writer.write(line);
                writer.newLine();

                count++;
            }
        }
    }
}