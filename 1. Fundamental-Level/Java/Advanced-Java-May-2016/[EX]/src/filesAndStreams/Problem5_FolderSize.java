package filesAndStreams;

import java.io.*;

public class Problem5_FolderSize {
    public static void main(String[] args) throws IOException {
        String directoryPath = System.getProperty("user.dir") +
                "\\resources\\05. FolderSize\\";

        double size = 0;
        File directory = new File(directoryPath);
        if (directory.listFiles() == null) {
            System.out.println("No directories and files.");
            return;
        }

        for (File file : directory.listFiles()) {
            if (file.isFile()) {
                size += file.length();
            }
        }

        size /= 1024; // kilobytes
        size /= 1024; // megabytes
        System.out.println(size);
    }
}