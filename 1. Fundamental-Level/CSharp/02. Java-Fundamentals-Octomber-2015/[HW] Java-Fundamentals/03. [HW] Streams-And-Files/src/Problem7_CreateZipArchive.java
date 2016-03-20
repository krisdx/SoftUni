import java.io.*;
import java.util.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class Problem7_CreateZipArchive {
    public static void main(String[] args) {
        Map<String, File> files = new HashMap<String, File>() {{
            put("count-chars.txt", new File("resources/count-chars.txt"));
            put("words.txt", new File("resources/words.txt"));
            put("lines.txt", new File("resources/lines.txt"));
        }};

        ZipFiles(files, "resources/text-files.zip");
    }

    private static void ZipFiles(Map<String, File> files, String zipArchiveName) {
        try (ZipOutputStream zipOutputStream = new ZipOutputStream(new FileOutputStream(zipArchiveName))) {

            for (Map.Entry<String, File> file : files.entrySet()) {
                try (FileInputStream source = new FileInputStream(file.getValue())) {
                    zipOutputStream.putNextEntry(new ZipEntry(file.getKey()));

                    byte[] buffer = new byte[4096];
                    while (true) {
                        int read = source.read(buffer, 0, buffer.length);
                        if (read <= 0) {
                            break;
                        }
                        zipOutputStream.write(buffer, 0, read);
                    }
                }
            }

        } catch (FileNotFoundException fileNotFoundException) {
            System.out.println("File not found.");
        } catch (IOException exception) {
            System.out.println("Cannot read the file.");
        }
    }
}