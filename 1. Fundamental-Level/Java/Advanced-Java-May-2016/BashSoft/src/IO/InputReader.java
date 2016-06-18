package IO;

import StaticData.SessionData;

import java.io.IOException;
import CommandHandler.CommandInterpreter;
import java.util.Scanner;

public class InputReader {
    private static final String END_COMMAND = "quit";

    public static void readCommands() throws Exception {
        OutputWriter.writeMessage(String.format("%s > ", SessionData.currentPath));

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().trim();
        while (!input.equals(END_COMMAND)) {
            try {
                CommandInterpreter.interpretCommand(input);
            } catch (IOException ex) {
                OutputWriter.displayException(ex.getMessage());
            }

            OutputWriter.writeMessage(String.format("%s > ", SessionData.currentPath));
            input = scanner.nextLine().trim();
        }

        Thread[] threads = new Thread[Thread.activeCount()];
        Thread.enumerate(threads);
        for (Thread thread : threads) {
            if (!thread.getName().equals("main") && !thread.isDaemon()) {
                thread.join();
            }
        }
    }
}