package filesAndStreams;

import java.io.*;

public class Problem1_OddLines {
    public static void main(String[] args) throws IOException {
        String inputTextPath = System.getProperty("user.dir") + "\\resources\\01. OddLines\\01_OddLinesIn.txt";
        String outputTextPath = System.getProperty("user.dir") + "\\resources\\01. OddLines\\01_OddLinesOut.txt";
        try (
                BufferedReader reader = new BufferedReader(
                        new FileReader(inputTextPath));
                BufferedWriter writer = new BufferedWriter(
                        new FileWriter(outputTextPath))
        ) {
            String line;
            int count = 0;
            while ((line = reader.readLine()) != null) {
                if (count % 2 != 0) {
                    writer.write(line);
                    writer.newLine();
                }

                count++;
            }
        }
    }
}