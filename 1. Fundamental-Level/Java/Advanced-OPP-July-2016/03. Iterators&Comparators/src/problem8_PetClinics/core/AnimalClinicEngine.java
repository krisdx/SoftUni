package problem8_PetClinics.core;

import problem8_PetClinics.contracts.Clinic;
import problem8_PetClinics.models.Animal;
import problem8_PetClinics.contracts.ClinicDatabase;
import problem8_PetClinics.contracts.IO.Printable;
import problem8_PetClinics.contracts.IO.Readable;

import java.io.IOException;

public class AnimalClinicEngine implements Runnable {

    private Printable writer;
    private Readable reader;

    private ClinicDatabase database;

    public AnimalClinicEngine(ClinicDatabase database, Printable writer, Readable reader) {
        this.database = database;
        this.writer = writer;
        this.reader = reader;
    }

    @Override
    public void run() {
        try {
            int n = Integer.valueOf(this.reader.read());
            for (int i = 0; i < n; i++) {
                String[] lineArgs = reader.read().split("\\s+");
                String command = lineArgs[0];
                this.executeCommand(command, lineArgs);
            }
        } catch (IOException ex) {
            this.writer.print(ex.getMessage());
        }
    }

    private void executeCommand(String command, String[] lineArgs) {
        switch (command) {
            case "Create":
                this.executeCreateCommand(lineArgs);
                break;
            case "Add":
                this.executeAddCommand(lineArgs);
                break;
            case "HasEmptyRooms":
                this.executeHasEmptyRoomsCommand(lineArgs);
                break;
            case "Release":
                this.executeReleaseCommand(lineArgs);
                break;
            case "Print":
                this.executePrintCommand(lineArgs);
                break;
        }
    }

    private void executePrintCommand(String[] lineArgs) {
        String clinicName = lineArgs[1];
        Clinic clinic = this.database.getClinics().get(clinicName);
        if (lineArgs.length == 2) {
            this.writer.printLine(clinic.toString());
        } else if (lineArgs.length == 3) {
            int roomIndex = Integer.valueOf(lineArgs[2]) - 1;
            Animal animal = clinic.getRooms().get(roomIndex);
            if (animal == null) {
                this.writer.printLine("Room empty");
            } else {
                this.writer.printLine(animal.toString());
            }
        }
    }

    private void executeHasEmptyRoomsCommand(String[] lineArgs) {
        String clinicName = lineArgs[1];
        Boolean result = this.database.getClinics().get(clinicName).hasEmptyRooms();
        this.writer.printLine(result.toString());
    }

    private void executeReleaseCommand(String[] lineArgs) {
        String clinicName = lineArgs[1];
        Boolean result = this.database.getClinics().get(clinicName).releaseAnimal();
        this.writer.printLine(result.toString());
    }

    private void executeAddCommand(String[] lineArgs) {
        String animalName = lineArgs[1];
        String clinicName = lineArgs[2];
        Clinic clinic = this.database.getClinics().get(clinicName);
        Animal animal = this.database.getAnimals().get(animalName);
        Boolean result = clinic.addAnimal(animal);
        System.out.println(result.toString());
    }

    private boolean executeCreateCommand(String[] lineArgs) {
        if (lineArgs[1].equals("Pet")) {
            this.database.addAnimal(
                    lineArgs[2],
                    Integer.valueOf(lineArgs[3]),
                    lineArgs[4]);
        } else {
            try {
                this.database.addClinic(
                        lineArgs[2],
                        Integer.valueOf(lineArgs[3]));
            } catch (IllegalArgumentException ex) {
                this.writer.printLine(ex.getMessage());
            }
        }

        return false;
    }
}