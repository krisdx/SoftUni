package main.bg.softuni;

import main.bg.softuni.contracts.downloader.AsynchDownloader;
import main.bg.softuni.contracts.IO.Interpreter;
import main.bg.softuni.contracts.IO.Reader;
import main.bg.softuni.contracts.IO.ContentComparer;
import main.bg.softuni.contracts.data.DataFilter;
import main.bg.softuni.contracts.data.DataSorter;
import main.bg.softuni.contracts.database.Database;
import main.bg.softuni.io.CommandInterpreter;
import main.bg.softuni.io.IOManager;
import main.bg.softuni.io.InputReader;
import main.bg.softuni.io.OutputWriter;
import main.bg.softuni.judge.Tester;
import main.bg.softuni.network.DownloadManager;
import main.bg.softuni.repository.RepositoryFilter;
import main.bg.softuni.repository.RepositorySorter;
import main.bg.softuni.repository.StudentsRepository;

public class Main {

    public static void main(String[] args) {

        ContentComparer tester = new Tester();
        AsynchDownloader downloadManager = new DownloadManager();
        IOManager ioManager = new IOManager();
        DataSorter sorter = new RepositorySorter();
        DataFilter filter = new RepositoryFilter();
        Database repository = new StudentsRepository(filter, sorter);
        Interpreter currentInterpreter = new CommandInterpreter(
                tester, repository, downloadManager, ioManager);
        Reader reader = new InputReader(currentInterpreter);

        try {
            reader.readCommands();
        } catch (Exception ex) {
            OutputWriter.displayException(ex.getMessage());
        }
    }
}