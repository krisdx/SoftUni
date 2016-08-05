package main.bg.softuni.contracts.IO;

public interface DirectoryChanger {
    void changeCurrentDirRelativePath(String relativePath);

    void changeCurrentDirAbsolute(String absolutePath);
}