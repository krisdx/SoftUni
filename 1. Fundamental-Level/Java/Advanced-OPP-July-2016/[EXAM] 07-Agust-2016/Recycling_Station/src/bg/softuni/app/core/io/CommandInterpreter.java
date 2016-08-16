package bg.softuni.app.core.io;

import bg.softuni.app.core.io.command.Executable;

public interface CommandInterpreter {

    Executable parseCommand(String input)
            throws ReflectiveOperationException;
}