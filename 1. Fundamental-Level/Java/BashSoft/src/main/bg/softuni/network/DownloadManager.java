package main.bg.softuni.network;

import main.bg.softuni.contracts.downloader.AsynchDownloader;
import main.bg.softuni.exceptions.InvalidPathException;
import main.bg.softuni.io.OutputWriter;
import main.bg.softuni.staticData.SessionData;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import java.nio.channels.Channels;
import java.nio.channels.ReadableByteChannel;

public class DownloadManager implements AsynchDownloader {

    @Override
    public void download(String fileUrl) {
        URL url;
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
                OutputWriter.writeMessageOnNewLine("Download complete.");
            }
        } catch (MalformedURLException ex) {
            OutputWriter.displayException(ex.getMessage());
        } catch (IOException ex) {
            OutputWriter.displayException(ex.getMessage());
        } finally {
            try {
                if (fileOutputStream != null) {
                    fileOutputStream.close();
                }
            } catch (IOException ex) {
                ex.printStackTrace();
            } finally {
                if (readableByteChannel != null) {
                    try {
                        readableByteChannel.close();
                    } catch (IOException ex) {
                        ex.printStackTrace();
                    }
                }
            }
        }
    }

    @Override
    public void downloadOnNewThread(String fileUrl) {
        Thread thread = new Thread(() -> download(fileUrl));
        thread.setDaemon(false);
        OutputWriter.writeMessageOnNewLine(
                String.format("Worker thread %d started download..", thread.getId()));
        SessionData.threadPool.add(thread);
        thread.start();
    }

    private String extractNameOfFile(String fileUrl)
            throws MalformedURLException {
        int indexOfLastSlash = fileUrl.lastIndexOf('/');
        if (indexOfLastSlash == -1) {
            throw new InvalidPathException();
        }

        return fileUrl.substring(indexOfLastSlash + 1);
    }
}