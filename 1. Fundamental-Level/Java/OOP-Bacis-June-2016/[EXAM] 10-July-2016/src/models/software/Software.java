package models.software;

import models.Component;

public abstract class Software extends Component {
    protected int capacityConsumption;
    protected int memoryConsumption;

    protected Software(String name) {
        super(name);
    }

    protected Software(String name, int capacityConsumption, int memoryConsumption) {
        super(name);
        this.setCapacityConsumption(capacityConsumption);
        this.setMemoryConsumption(memoryConsumption);
    }

    public int getCapacityConsumption() {
        return this.capacityConsumption;
    }

    public int getMemoryConsumption() {
        return this.memoryConsumption;
    }

    @Override
    public String toString() {
        return this.getName();
    }

    protected void setCapacityConsumption(int capacityConsumption) {
        this.capacityConsumption = capacityConsumption;
    }

    protected void setMemoryConsumption(int memoryConsumption) {
        this.memoryConsumption = memoryConsumption;
    }
}