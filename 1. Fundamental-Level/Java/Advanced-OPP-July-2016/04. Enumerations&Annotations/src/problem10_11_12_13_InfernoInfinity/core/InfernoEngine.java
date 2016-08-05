package problem10_11_12_13_InfernoInfinity.core;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.contracts.IO.Printable;
import problem10_11_12_13_InfernoInfinity.contracts.IO.Readable;
import problem10_11_12_13_InfernoInfinity.contracts.databese.Database;
import problem10_11_12_13_InfernoInfinity.contracts.factories.GemFactory;
import problem10_11_12_13_InfernoInfinity.contracts.factories.WeaponFactory;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.InvocationTargetException;

public class InfernoEngine implements Engine, Runnable {

    private Readable reader;
    private Printable writer;

    private WeaponFactory weaponFactory;
    private GemFactory gemFactory;

    private Database database;

    private boolean isRunning;

    public InfernoEngine(
            Readable reader,
            Printable writer,
            WeaponFactory weaponFactory,
            GemFactory gemFactory,
            Database database) {
        this.reader = reader;
        this.writer = writer;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
        this.database = database;

        this.isRunning = true;
    }

    @Override
    public void run() {
        while (this.isRunning) {
            try {
                String[] lineArgs = this.reader.read().trim().split(";");
                String command = lineArgs[0];

                Executable executable = null;
                String commandDirectoryPath = System.getProperty("user.dir") + "\\src\\" + this.getClass().getPackage().getName().replace(".", "\\") + "\\commands";
                File file = new File(commandDirectoryPath);
                for (File f : file.listFiles()) {
                    if (f.isFile() && f.getName().endsWith(".java")) {
                        String a = f.getName();
                        String fileName = a.substring(0, a.indexOf("."));
                        Class current = Class.forName(
                                "problem10_11_12_13_InfernoInfinity.core.commands." + fileName);
                        if (current.isAnnotationPresent(CommandName.class)) {
                            CommandName commandName = (CommandName) current.getAnnotation(CommandName.class);
                            if (commandName.name().equals(command)) {
                                executable = (Executable) current.getDeclaredConstructor(Engine.class).newInstance(this);
                                break;
                            }
                        }
                    }
                }

                executable.execute(lineArgs);
            } catch (IOException ex) {
                this.writer.displayException(ex.getMessage());
            } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | InvocationTargetException | NoSuchMethodException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public Readable getReader() {
        return this.reader;
    }

    @Override
    public Printable getWriter() {
        return this.writer;
    }

    @Override
    public WeaponFactory getWeaponFactory() {
        return this.weaponFactory;
    }

    @Override
    public GemFactory getGemFactory() {
        return this.gemFactory;
    }

    @Override
    public Database getDatabase() {
        return this.database;
    }

    @Override
    public void stop() {
        this.isRunning = false;
    }
}