package models.hardware;

import models.Component;
import models.software.Software;

import java.util.*;

public abstract class Hardware extends Component {
    private Map<String, Software> softwareComponents;

    private int lightSoftwareComponents;
    private int expressSoftwareComponents;

    private int capacity;
    private int memory;

    protected int maxCapacity;
    protected int maxMemory;

    protected Hardware(String name) {
        super(name);
        this.softwareComponents = new LinkedHashMap<>();
    }

    protected Hardware(String name, int maxCapacity, int maxMemory) {
        super(name);
        this.setMaxCapacity(maxCapacity);
        this.setMaxMemory(maxMemory);
    }

    public void registerSoftwareComponent(Software software) {
        this.softwareComponents.put(software.getName(), software);

        if (software.getType().equals("Express")) {
            this.expressSoftwareComponents++;
        } else if (software.getType().equals("Light")) {
            this.lightSoftwareComponents++;
        }

        this.capacity -= software.getCapacityConsumption();
        this.memory -= software.getMemoryConsumption();
    }

    public int getMaxCapacity() {
        return this.maxCapacity;
    }

    public int getMaxMemory() {
        return this.maxMemory;
    }

    public int getLightSoftwareComponentsCount() {
        return this.lightSoftwareComponents;
    }

    public int getExpressSoftwareComponentsCount() {
        return this.expressSoftwareComponents;
    }

    public void setLightSoftwareComponents(int lightSoftwareComponents) {
        this.lightSoftwareComponents = lightSoftwareComponents;
    }

    public void setExpressSoftwareComponents(int expressSoftwareComponents) {
        this.expressSoftwareComponents = expressSoftwareComponents;
    }

    public Map<String, Software> getSoftwareComponents() {
        return this.softwareComponents;
    }

    protected void setMaxCapacity(int maxCapacity) {
        this.maxCapacity = maxCapacity;
    }

    protected void setMaxMemory(int maxMemory) {
        this.maxMemory = maxMemory;
    }
}