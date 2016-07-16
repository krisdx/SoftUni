package models.software;

public class LightSoftware extends Software {

    private static final String LIGHT_SOFTWARE_TYPE = "Light";

    public LightSoftware(String name, int capacityConsumption, int memoryConsumption) {
        super(name);
        this.setCapacityConsumption(capacityConsumption);
        this.setMemoryConsumption(memoryConsumption);
    }

    @Override
    public String getType() {
        return LIGHT_SOFTWARE_TYPE;
    }

    @Override
    protected void setCapacityConsumption(int capacityConsumption) {
        super.setCapacityConsumption(
                capacityConsumption + (int) (capacityConsumption * 0.5d));
    }

    @Override
    protected void setMemoryConsumption(int memoryConsumption) {
        super.setMemoryConsumption((int) (memoryConsumption * 0.5));
    }
}