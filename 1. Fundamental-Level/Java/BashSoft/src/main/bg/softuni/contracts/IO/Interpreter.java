package main.bg.softuni.contracts.IO;

import java.io.IOException;

public interface Interpreter {
    void interpretCommand(String input) throws IOException;
}