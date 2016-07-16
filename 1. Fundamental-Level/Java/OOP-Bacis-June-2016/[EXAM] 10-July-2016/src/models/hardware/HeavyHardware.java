package models.hardware;

public class HeavyHardware extends Hardware {
    private static final String HEAVY_HARDWARE_TYPE = "Heavy";

    public HeavyHardware(String name, int maxCapacity, int maxMemory) {
        super(name);
        this.setMaxCapacity(maxCapacity);
        this.setMaxMemory(maxMemory);
    }

    @Override
    public String getType() {
        return HEAVY_HARDWARE_TYPE;
    }

    @Override
    protected void setMaxCapacity(int maxCapacity) {
        super.setMaxCapacity(maxCapacity * 2);
    }

    @Override
    protected void setMaxMemory(int maxMemory) {
        super.setMaxMemory(maxMemory - (int)(maxMemory * (0.25d)));
    }
}