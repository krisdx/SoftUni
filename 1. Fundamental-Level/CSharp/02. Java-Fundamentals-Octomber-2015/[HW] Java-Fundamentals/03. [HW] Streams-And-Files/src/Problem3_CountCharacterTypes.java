import java.io.*;

public class Problem3_CountCharacterTypes {
    public static void main(String[] args) {
        try (BufferedReader fileReader = new BufferedReader(
                new FileReader("resources/words.txt"))
        ) {
            char[] vowels = new char[]{'a', 'e', 'i', 'o', 'u'};
            char[] punctuationMarks = new char[]{'?', '!', '.', ','};

            int vowelsCount = 0;
            int punctuationMarksCount = 0;
            int consonantsCount = 0;
            while (true) {
                String currentLine = fileReader.readLine();
                if (currentLine == null) {
                    break;
                }

                for (int i = 0; i < currentLine.length(); i++) {
                    if (isPunctuationMark(punctuationMarks, currentLine.charAt(i))) {
                        punctuationMarksCount++;
                    } else if (isVowel(vowels, currentLine.charAt(i))) {
                        vowelsCount++;
                    }else if (currentLine.charAt(i) != ' '){
                        consonantsCount++;
                    }
                }

                try (PrintWriter fileWriter = new PrintWriter(
                        new FileWriter(new File("resources/count-chars.txt")))){
                    String resultOutput = String.format("Vowels: %d\n" +
                            "Consonants: %d\n" +
                            "Punctuation: %d", vowelsCount, consonantsCount, punctuationMarksCount);
                    fileWriter.write(resultOutput);
                }
            }

        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }

    private static boolean isVowel(char[] vowels, char ch) {
        for (int i = 0; i < vowels.length; i++) {
            if (ch == vowels[i]) {
                return true;
            }
        }

        return false;
    }

    private static boolean isPunctuationMark(char[] punctuationMarks, char ch) {
        for (int i = 0; i < punctuationMarks.length; i++) {
            if (ch == punctuationMarks[i]) {
                return true;
            }
        }

        return false;
    }
}