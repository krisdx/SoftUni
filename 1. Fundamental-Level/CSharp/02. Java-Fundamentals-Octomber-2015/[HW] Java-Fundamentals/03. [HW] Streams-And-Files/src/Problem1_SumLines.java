import java.io.*;

public class Problem1_SumLines {
    public static void main(String[] args) {
        try (BufferedReader fileReader = new BufferedReader(
                new FileReader("resources/lines.txt"))
        ) {
            while (true) {
                String line = fileReader.readLine();
                if (line == null) {
                    break;
                }

                System.out.println(sumCharsInString(line));
            }

        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }

    private static int sumCharsInString(String line) {
        int sum = 0;
        for (int i = 0; i < line.length(); i++) {
            sum += line.charAt(i);
        }

        return sum;
    }
}