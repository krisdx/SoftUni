package bg.softuni.app.core.io;

import bg.softuni.app.core.factory.garbageFactory.GarbageFactory;
import bg.softuni.app.core.io.command.Command;
import bg.softuni.app.core.io.command.Executable;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.framework.contracts.GarbageProcessor;
import bg.softuni.app.utility.Constants;
import bg.softuni.app.utility.annotations.Inject;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;

public class CommandInterpreterImpl implements CommandInterpreter {

    private static final String COMMANDS_PACKAGE =
            Command.class.getPackage().getName();

    private GarbageFactory garbageFactory;
    private DataProvider database;
    GarbageProcessor garbageProcessor;

    public CommandInterpreterImpl(
            GarbageFactory garbageFactory,
            DataProvider database,
            GarbageProcessor garbageProcessor) {

        this.garbageFactory = garbageFactory;
        this.database = database;
        this.garbageProcessor = garbageProcessor;
    }

    @Override
    @SuppressWarnings("unchecked")
    public Executable parseCommand(String input) throws ReflectiveOperationException {

        String[] splitInput = input.split("\\s+");
        String commandName = splitInput[0];
        String[] data = null;
        if (splitInput.length > 1) {
            data = splitInput[1].split("\\|");
        }

        String commandPath =
                COMMANDS_PACKAGE + "." + commandName + Constants.COMMAND_SUFFIX;
        Class<Executable> commandClass = (Class<Executable>) Class.forName(commandPath);
        Constructor constructor = commandClass.getDeclaredConstructor(String[].class);

        Executable executable = (Executable) constructor.newInstance((Object) data);

        this.injectDependencies(commandClass, executable);
        return executable;
    }

    private void injectDependencies(Class<Executable> commandClass, Executable executable)
            throws IllegalAccessException {

        Field[] sourceFields = this.getClass().getDeclaredFields();
        for (Field sourceField : sourceFields) {

            Field[] fieldsInCommand = commandClass.getDeclaredFields();
            for (Field fieldInCommand : fieldsInCommand) {

                if (!fieldInCommand.isAnnotationPresent(Inject.class)) {
                    continue;
                }

                if (!sourceField.getType().equals(fieldInCommand.getType())) {
                    continue;
                }

                sourceField.setAccessible(true);
                fieldInCommand.setAccessible(true);

                fieldInCommand.set(executable, sourceField.get(this));
            }
        }
    }
}