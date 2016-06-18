package filesAndStreams;

import java.io.*;

public class Problem4_MergingTwoFiles {
    public static void main(String[] args) throws IOException {
        String firstFilePath = System.getProperty("user.dir") +
                "\\resources\\04. MergingTwoFiles\\01_FileOne.txt";
        String secondFilePath = System.getProperty("user.dir") +
                "\\resources\\04. MergingTwoFiles\\01_FileTwo.txt";
        String mergedFilePath = System.getProperty("user.dir") +
                "\\resources\\04. MergingTwoFiles\\01_Merged.txt";
        try (
                BufferedReader firstFile = new BufferedReader(
                        new FileReader(firstFilePath));
                BufferedReader secondFile = new BufferedReader(
                        new FileReader(secondFilePath));
                BufferedWriter writer = new BufferedWriter(
                        new FileWriter(mergedFilePath))
        ) {
            String firstLine;
            String secondLine;
            while ((firstLine = firstFile.readLine()) != null &&
                    (secondLine = secondFile.readLine()) != null) {
                writer.write(firstLine);
                writer.newLine();
                writer.write(secondLine);
                writer.newLine();
            }

            while ((firstLine = firstFile.readLine()) != null) {
                writer.write(firstLine);
                writer.newLine();
            }

            while ((secondLine = secondFile.readLine()) != null) {
                writer.write(secondLine);
                writer.newLine();
            }
        }
    }
}