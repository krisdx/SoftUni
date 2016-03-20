import java.io.*;

public class Problem4_CopyJpgFile {
    public static void main(String[] args) {
        try (FileInputStream fileInputStream = new FileInputStream("resources/picture.jpg");
             FileOutputStream fileOutputStream = new FileOutputStream("resources/picture-copy.jpg")) {
            byte[] buffer = new byte[4096];
            while (true) {
                int read = fileInputStream.read(buffer, 0, buffer.length);
                if (read == -1) {
                    break;
                }

                fileOutputStream.write(buffer, 0, buffer.length);
            }
        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }
}