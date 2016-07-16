package core;

import contracts.Printable;
import contracts.Readable;
import data.Data;
import models.hardware.Hardware;
import models.hardware.HeavyHardware;
import models.hardware.PowerHardware;
import models.software.ExpressSoftware;
import models.software.LightSoftware;
import models.software.Software;

import java.io.IOException;

public class Engine implements Runnable {

    private Printable writer;
    private Readable reader;
    private Data data;

    public Engine(Printable writer, Readable reader, Data data) {
        this.writer = writer;
        this.reader = reader;
        this.data = data;
    }

    @Override
    public void run() {
        try {
            while (true) {
                String line = reader.readLine().trim();
                if (line.equals("System Split")) {
                    this.executeSystemSplit();
                    break;
                }

                int commandIndex = line.indexOf('(');
                String command = line.substring(0, commandIndex);
                String[] commandArgs = line
                        .substring(commandIndex + 1, line.length() - 1)
                        .split("[\\s,]+");

                this.executeCommand(command, commandArgs);
            }
        } catch (IOException ex) {
            this.writer.printException(ex.getMessage());
        }
    }

    private void executeCommand(String command, String[] commandArgs) {
        switch (command) {
            case "RegisterPowerHardware":
                this.registerPowerHardware(commandArgs);
                break;
            case "RegisterHeavyHardware":
                this.registerHeavyHardware(commandArgs);
                break;
            case "RegisterExpressSoftware":
                this.registerExpressSoftware(commandArgs);
                break;
            case "RegisterLightSoftware":
                this.registerLightSoftware(commandArgs);
                break;
            case "ReleaseSoftwareComponent":
                this.releaseSoftwareComponent(commandArgs);
                break;
            case "Analyze":
                this.analyze();
                break;
            default:
                throw new IllegalArgumentException("Unknown command.");
        }
    }

    private void registerLightSoftware(String[] commandArgs) {
        String hardwareComponentName = commandArgs[0];
        String softwareName = commandArgs[1];
        int capacity = Integer.valueOf(commandArgs[2]);
        int memory = Integer.valueOf(commandArgs[3]);

        Software software = new LightSoftware(softwareName, capacity, memory);
        this.data.addSoftware(hardwareComponentName, software);
    }

    private void registerExpressSoftware(String[] commandArgs) {
        String hardwareComponentName = commandArgs[0];
        String softwareName = commandArgs[1];
        int capacity = Integer.valueOf(commandArgs[2]);
        int memory = Integer.valueOf(commandArgs[3]);

        Software software = new ExpressSoftware(softwareName, capacity, memory);
        this.data.addSoftware(hardwareComponentName, software);
    }

    private void registerHeavyHardware(String[] commandArgs) {
        String name = commandArgs[0];
        int capacity = Integer.valueOf(commandArgs[1]);
        int memory = Integer.valueOf(commandArgs[2]);
        Hardware heavyHardware = new HeavyHardware(name, capacity, memory);

        this.data.addHardware(heavyHardware);
    }

    private void registerPowerHardware(String[] commandArgs) {
        String name = commandArgs[0];
        int capacity = Integer.valueOf(commandArgs[1]);
        int memory = Integer.valueOf(commandArgs[2]);
        Hardware powerHardware = new PowerHardware(name, capacity, memory);

        this.data.addHardware(powerHardware);
    }

    private void releaseSoftwareComponent(String[] commandArgs) {
        String hardwareComponentName = commandArgs[0];
        String softwareComponentName = commandArgs[1];

        this.data.releaseSoftwareComponent(hardwareComponentName, softwareComponentName);
    }

    private void analyze() {
        this.data.printAnalisis(this.writer);
    }

    private void executeSystemSplit() {
        this.data.systemSplit(this.writer);
    }
}