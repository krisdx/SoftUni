package filesAndStreams;

import java.io.*;

public class Problem6_Timer {
    public static void main(String[] args) throws IOException {
        File firstFilePath = new File(System.getProperty("user.dir") +
                "\\resources\\06. Timer\\File1.csv");
        File secondFilePath = new File(System.getProperty("user.dir") +
                "\\resources\\06. Timer\\File2.txt");
        try (
                BufferedReader firstFile = new BufferedReader(
                        new FileReader(firstFilePath));
                BufferedReader secondFile = new BufferedReader(
                        new FileReader(secondFilePath))
        ) {

            long firstFileStartTime = System.nanoTime();
            while ((firstFile.readLine()) != null) {
            }
            long firstFileEndTime = System.nanoTime();

            long secondFileStartTime = System.nanoTime();
            while ((secondFile.readLine()) != null) {
            }
            long secondFileEndTime = System.nanoTime();

            long firstFileTime = firstFileEndTime - firstFileStartTime;
            long secondFileTime = secondFileEndTime - secondFileStartTime;
            if (firstFileTime < secondFileTime) {
                System.out.println(true);
            } else {
                System.out.println(false);
            }
        }
    }
}