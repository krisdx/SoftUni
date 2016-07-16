package models.software;

public class ExpressSoftware extends Software {

    private static final String EXPRESS_SOFTWARE_TYPE = "Express";

    public ExpressSoftware(String name, int capacityConsumption, int memoryConsumption) {
        super(name);
        super.setCapacityConsumption(capacityConsumption);
        this.setMemoryConsumption(memoryConsumption);
    }

    @Override
    public String getType() {
        return EXPRESS_SOFTWARE_TYPE;
    }

    @Override
    protected void setMemoryConsumption(int memoryConsumption) {
        super.setMemoryConsumption(memoryConsumption * 2);
    }
}