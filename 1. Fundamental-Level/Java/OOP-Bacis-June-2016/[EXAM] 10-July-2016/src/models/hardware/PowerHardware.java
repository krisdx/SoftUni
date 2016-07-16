package models.hardware;

public class PowerHardware extends Hardware {
    private static final String POWER_HARDWARE_TYPE = "Power";

    public PowerHardware(String name, int maxCapacity, int maxMemory) {
        super(name);
        this.setMaxCapacity(maxCapacity);
        this.setMaxMemory(maxMemory);
    }

    @Override
    public String getType() {
        return POWER_HARDWARE_TYPE;
    }

    @Override
    protected void setMaxCapacity(int maxCapacity) {
        super.setMaxCapacity(maxCapacity - (int) (maxCapacity * (0.75)));
    }

    @Override
    protected void setMaxMemory(int maxMemory) {
        super.setMaxMemory((int) (maxMemory + (maxMemory * (0.75))));
    }
}