package Network;

import IO.OutputWriter;
import StaticData.ExceptionMessages;
import StaticData.SessionData;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;

public class DownloadManager {
    public static void download(String fileUrl) {
        URL url = null;
        ReadableByteChannel readableByteChannel = null;
        FileOutputStream fileOutputStream = null;
        try {
            if (Thread.currentThread().getName().equals("main")) {
                OutputWriter.writeMessageOnNewLine("Started downloading..");
            }

            url = new URL(fileUrl);
            readableByteChannel = Channels.newChannel(url.openStream());

            String fileName = extractNameOfFile(url.toString());
            File file = new File(SessionData.currentPath + "/" + fileName);

            fileOutputStream = new FileOutputStream(file);
            fileOutputStream.getChannel().transferFrom(readableByteChannel, 0, Long.MAX_VALUE);
            if (Thread.currentThread().getName().equals("main")) {
                OutputWriter.writeMessageOnNewLine("Download complete..");
            }
        } catch (MalformedURLException ex) {
            OutputWriter.displayException(ex.getMessage());
        } catch (IOException ex) {
            ex.printStackTrace();
        } finally {
            try {
                if (fileOutputStream != null) {
                    fileOutputStream.close();
                }
                if (readableByteChannel != null) {
                    readableByteChannel.close();
                }
            } catch (IOException ex) {
                ex.printStackTrace();
            }
        }
    }

    public static void downloadOnNewThread(String fileUrl) {
        Thread thread = new Thread(() -> download(fileUrl));
        OutputWriter.writeMessageOnNewLine(
                String.format("Worker thread %d started download..", thread.getId()));
        thread.setDaemon(false);
        thread.start();
    }

    private static String extractNameOfFile(String fileUrl) throws MalformedURLException {
        int indexOfLastSlash = fileUrl.lastIndexOf('/');
        if (indexOfLastSlash == -1) {
            throw new MalformedURLException(ExceptionMessages.INVALID_PATH);
        }

        return fileUrl.substring(indexOfLastSlash + 1);
    }
}