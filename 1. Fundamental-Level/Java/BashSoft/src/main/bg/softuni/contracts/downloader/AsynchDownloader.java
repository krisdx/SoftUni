package main.bg.softuni.contracts.downloader;

public interface AsynchDownloader extends Downloader {
    void downloadOnNewThread(String fileUrl);
}