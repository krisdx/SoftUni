package bg.softuni.app.framework.contracts;

public interface GarbageManager {
    void setManagement(String type, double currentEnergy, double currentCapital);

    boolean canProduce(String type, double currentEnergy, double currentCapital);
}