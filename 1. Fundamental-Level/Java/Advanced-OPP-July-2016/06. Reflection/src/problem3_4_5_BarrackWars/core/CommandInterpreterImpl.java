package problem3_4_5_BarrackWars.core;

import problem3_4_5_BarrackWars.annotations.Inject;
import problem3_4_5_BarrackWars.contracts.CommandInterpreter;
import problem3_4_5_BarrackWars.contracts.Executable;
import problem3_4_5_BarrackWars.contracts.Repository;
import problem3_4_5_BarrackWars.contracts.UnitFactory;
import problem3_4_5_BarrackWars.core.commands.Command;

import java.lang.reflect.Constructor;
import java.lang.reflect.Field;

public class CommandInterpreterImpl implements CommandInterpreter {

    private Repository repository;
    private UnitFactory unitFactory;

    public CommandInterpreterImpl(Repository repository, UnitFactory unitFactory) {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    @Override
    public Executable interpretCommand(String[] data, String commandName) {
        Executable executable = null;
        try {
            Class<Executable> executableClass = (Class<Executable>) Class.forName(
                    Command.class.getPackage().getName() + "." + commandName + "Command");
            Constructor constructor = executableClass.getDeclaredConstructor(String[].class);
            executable = (Executable) constructor.newInstance((Object) data);

            this.resolveDependencies(executable, executableClass);
        } catch (ReflectiveOperationException ex) {
            System.err.println(ex.getMessage());
        }

        return executable;
    }

    private void resolveDependencies(Executable executable, Class executableClass) throws ReflectiveOperationException {
        Field[] fieldsInCommand = executableClass.getDeclaredFields();
        for (Field fieldInCommand : fieldsInCommand) {
            if (!fieldInCommand.isAnnotationPresent(Inject.class)) {
                continue;
            }

            Field[] sourceFields = this.getClass().getDeclaredFields();
            for (Field sourceFiled : sourceFields) {
                if (!fieldInCommand.getType().equals(sourceFiled.getType())) {
                    continue;
                }

                Object valueToSet = sourceFiled.get(this);
                fieldInCommand.setAccessible(true);
                fieldInCommand.set(executable, valueToSet);
            }
        }
    }
}