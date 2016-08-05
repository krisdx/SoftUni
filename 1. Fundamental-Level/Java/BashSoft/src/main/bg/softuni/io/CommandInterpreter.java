package main.bg.softuni.io;

import main.bg.softuni.annotations.Alias;
import main.bg.softuni.annotations.Inject;
import main.bg.softuni.contracts.Executable;
import main.bg.softuni.contracts.IO.ContentComparer;
import main.bg.softuni.contracts.IO.DirectoryManager;
import main.bg.softuni.contracts.IO.Interpreter;
import main.bg.softuni.contracts.database.Database;
import main.bg.softuni.contracts.downloader.AsynchDownloader;
import main.bg.softuni.io.commands.Command;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;

public class CommandInterpreter implements Interpreter {

    private static final String COMMANDS_LOCATION =
            "src/main/bg/softuni/io/commands";

    private static final String COMMANDS_PACKAGE =
            Command.class.getPackage().getName();

    private ContentComparer tester;
    private Database repository;
    private AsynchDownloader downloadManager;
    private DirectoryManager ioManager;

    public CommandInterpreter(ContentComparer tester,
                              Database repository,
                              AsynchDownloader downloadManager,
                              DirectoryManager ioManager) {
        this.tester = tester;
        this.repository = repository;
        this.downloadManager = downloadManager;
        this.ioManager = ioManager;
    }

    @Override
    public void interpretCommand(String input) throws IOException {
        String[] data = input.split("\\s+");
        String commandName = data[0].toLowerCase();
        try {
            Executable command = parseCommand(input, data, commandName);
            command.execute();
        } catch (Exception ex) {
            OutputWriter.displayException(ex.getMessage());
        }
    }

    private Executable parseCommand(String input, String[] data, String commandName) {

        File commandsDirectory = new File(COMMANDS_LOCATION);
        Executable executable = null;
        for (File file : commandsDirectory.listFiles()) {
            if (!file.isFile() || !file.getName().endsWith(".java")) {
                continue;
            }

            try {
                String className = file.getName().substring(0, file.getName().indexOf("."));
                Class<Executable> executableClass =
                        (Class<Executable>) Class.forName(COMMANDS_PACKAGE + "." + className);
                if (!executableClass.isAnnotationPresent(Alias.class)) {
                    continue;
                }

                Alias aliasAnnotation = executableClass.getDeclaredAnnotation(Alias.class);
                String value = aliasAnnotation.value();
                if (!value.equals(commandName)) {
                    continue;
                }

                Constructor constructor =
                        executableClass.getDeclaredConstructor(String.class, String[].class);
                executable = (Executable) constructor.newInstance(input, data);

                this.injectDependencies(executable, executableClass);
            } catch (ReflectiveOperationException ex) {
                ex.printStackTrace();
            }
        }

        return executable;
    }

    private void injectDependencies(Executable executable, Class<Executable> executableClass)
            throws ReflectiveOperationException {
        Field[] fieldsInCommand = executableClass.getDeclaredFields();
        for (Field fieldInCommand : fieldsInCommand) {
            if (!fieldInCommand.isAnnotationPresent(Inject.class)) {
                continue;
            }

            Field[] sourceFields = this.getClass().getDeclaredFields();
            for (Field sourceField : sourceFields) {
                if (!fieldInCommand.getType().equals(sourceField.getType())) {
                    continue;
                }

                sourceField.setAccessible(true);
                Object valueToSet = sourceField.get(this);

                fieldInCommand.setAccessible(true);
                fieldInCommand.set(executable, valueToSet);
            }
        }
    }
}