package problem3_4_5_BarrackWars.core;

import problem3_4_5_BarrackWars.contracts.*;
import problem3_4_5_BarrackWars.contracts.Runnable;
import problem3_4_5_BarrackWars.core.commands.Command;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Engine implements Runnable {

    private Repository repository;
    private UnitFactory unitFactory;
    private CommandInterpreter commandInterpreter;

    public Engine(CommandInterpreter commandInterpreter, Repository repository, UnitFactory unitFactory) {
        this.repository = repository;
        this.unitFactory = unitFactory;
        this.commandInterpreter = commandInterpreter;
    }

    @Override
    public void run() {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        while (true) {
            try {
                String input = reader.readLine();
                String[] data = input.split("\\s+");
                String commandName = makeFistLetterUpper(data[0]);

                Executable executable = this.commandInterpreter.interpretCommand(data, commandName);
                String result = executable.execute();
                if (result.equals("fight")) {
                    break;
                }

                System.out.println(result);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private String makeFistLetterUpper(String str) {
        StringBuilder stringBuilder = new StringBuilder(str);
        Character character = str.charAt(0);
        stringBuilder.setCharAt(0, Character.toUpperCase(character));
        return stringBuilder.toString();
    }

    private String getCommandsPath() {
        return System.getProperty("user.dir") +
                "\\src\\" +
                Command.class.getPackage().getName().replace(".", "\\");
    }
}