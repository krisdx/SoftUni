import java.io.*;

public class Problem2_AllCaps {
    public static void main(String[] args) {
        try (BufferedReader fileReader = new BufferedReader(
                new FileReader("resources/[All-Caps] lines.txt"))
        ) {
            String allText = "";
            while (true) {
                String currentLine = fileReader.readLine();
                if (currentLine == null) {
                    allText = allText.substring(0, allText.length() - 1);
                    break;
                }

                allText += currentLine.toUpperCase() + "\n";
            }

            try (PrintWriter fileWriter = new PrintWriter(
                    new FileWriter(new File("resources/[All-Caps] lines.txt")))) {
                fileWriter.write(allText);
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }
}