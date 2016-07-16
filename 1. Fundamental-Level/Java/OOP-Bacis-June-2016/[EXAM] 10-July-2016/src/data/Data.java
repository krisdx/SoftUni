package data;

import contracts.Printable;
import models.hardware.Hardware;
import models.software.Software;

import java.util.*;

public class Data {
    private Map<String, Hardware> hardware;
    private Map<String, Software> software;

    public Data() {
        this.hardware = new LinkedHashMap<>();
        this.software = new LinkedHashMap<>();
    }

    public void addSoftware(String hardwareComponentName, Software softwareComponent) {
        if (!this.hardware.containsKey(hardwareComponentName)) {
            return;
        }

        if (this.hardware.get(hardwareComponentName).getMaxCapacity() < softwareComponent.getCapacityConsumption()) {
            return;
        }
        if (this.hardware.get(hardwareComponentName).getMaxMemory() < softwareComponent.getMemoryConsumption()) {
            return;
        }

        this.hardware.get(hardwareComponentName).registerSoftwareComponent(softwareComponent);
        this.software.put(softwareComponent.getName(), softwareComponent);
    }

    public void addHardware(Hardware hardwareComponent) {
        this.hardware.put(hardwareComponent.getName(), hardwareComponent);
    }

    public void releaseSoftwareComponent(String hardwareComponentName, String softwareComponentName) {
        if (!this.hardware.containsKey(hardwareComponentName)) {
            return;
        }

        if (!this.hardware
                .get(hardwareComponentName)
                .getSoftwareComponents()
                .containsKey(softwareComponentName)) {
            return;
        }

        Hardware hardware = this.hardware.get(hardwareComponentName);
        if (hardware
                .getSoftwareComponents()
                .get(softwareComponentName)
                .getName().equals("Light")) {
            hardware.setLightSoftwareComponents(hardware.getLightSoftwareComponentsCount() - 1);
        } else {
            hardware.setExpressSoftwareComponents(hardware.getExpressSoftwareComponentsCount() - 1);
        }

        this.hardware
                .get(hardwareComponentName)
                .getSoftwareComponents()
                .remove(softwareComponentName);

        this.software.remove(softwareComponentName);
    }

    public void printAnalisis(Printable writer) {
        writer.printLine("System Analysis");
        writer.printLine("Hardware Components: " + this.hardware.size());
        writer.printLine("Software Components: " + this.software.size());
        writer.printLine("Total Operational Memory: " + this.getOperationalMemoryInUse() +
                " / " + this.getMaximumMemory());
        writer.printLine("Total Capacity Taken: " + this.getCapacityUsage() +
                " / " + this.getMaxCapacity());
    }

    public void systemSplit(Printable writer) {
        System.out.println();
        this.hardware.entrySet().stream()
                .filter(hardware -> hardware.getValue().getType().equals("Power"))
                .forEach(hardware -> this.printInfo(writer, hardware));

        this.hardware.entrySet().stream()
                .filter(hardware -> hardware.getValue().getType().equals("Heavy"))
                .forEach(hardware -> this.printInfo(writer, hardware));
    }

    private void printInfo(Printable writer, Map.Entry<String, Hardware> hardware) {
        writer.printLine("Hardware Component - " + hardware.getKey());

        writer.printLine("Express Software Components - " + hardware.getValue().getExpressSoftwareComponentsCount());
        writer.printLine("Light Software Components - " + hardware.getValue().getLightSoftwareComponentsCount());

        writer.print("Memory Usage: " + this.getMemoryUsage(hardware));
        writer.printLine(" / " + this.getMaxCapacity());
        writer.print("Capacity Usage: " + this.getCapacityUsage(hardware));
        writer.printLine(" / " + this.getMaxCapacity());

        writer.printLine("Type: " + hardware.getValue().getType());

        writer.print("Software Components: ");
        if (hardware.getValue().getSoftwareComponents().size() == 0) {
            writer.print("None");
        } else {
            this.printComponents(writer, hardware.getValue().getSoftwareComponents());
            writer.printLine();
        }
    }

    private long getMemoryUsage(Map.Entry<String, Hardware> hardware) {
        long result = 0;
        for (Map.Entry<String, Software> softwareEntry : hardware.getValue().getSoftwareComponents().entrySet()) {
            result += softwareEntry.getValue().getMemoryConsumption();
        }

        return result;
    }

    private long getCapacityUsage(Map.Entry<String, Hardware> hardware) {
        long result = 0;
        for (Map.Entry<String, Software> softwareEntry : hardware.getValue().getSoftwareComponents().entrySet()) {
            result += softwareEntry.getValue().getCapacityConsumption();
        }

        return result;
    }

    private void printComponents(Printable writer, Map<String, Software> softwareComponents) {
        int index = 0;
        for (Map.Entry<String, Software> software : softwareComponents.entrySet()) {
            if (index + 1 == softwareComponents.size()) {
                writer.print(software.getValue().toString());
            } else {
                writer.print(software.getValue().toString() + ", ");
            }

            index++;
        }
    }

    private long getOperationalMemoryInUse() {
        long result = 0;
        for (Map.Entry<String, Software> softwareEntry : software.entrySet()) {
            result += softwareEntry.getValue().getMemoryConsumption();
        }

        return result;
    }

    private long getMaximumMemory() {
        long result = 0;
        for (Map.Entry<String, Hardware> hardwareEntry : this.hardware.entrySet()) {
            result += hardwareEntry.getValue().getMaxMemory();
        }

        return result;
    }

    private long getMaxCapacity() {
        long result = 0;
        for (Map.Entry<String, Hardware> hardwareEntry : this.hardware.entrySet()) {
            result += hardwareEntry.getValue().getMaxCapacity();
        }

        return result;
    }

    private long getCapacityUsage() {
        long result = 0;
        for (Map.Entry<String, Software> softwareEntry : software.entrySet()) {
            result += softwareEntry.getValue().getCapacityConsumption();
        }

        return result;
    }
}