package bg.softuni.app.data;

import bg.softuni.app.framework.contracts.GarbageManager;
import bg.softuni.app.framework.contracts.ProcessingData;

public class Database implements DataProvider {

    private double totalEnergy;
    private double totalCapital;

    private GarbageManager garbageManager;

    public Database(GarbageManager garbageManager) {
        this.garbageManager = garbageManager;
    }

    @Override
    public double getTotalEnergy() {
        return this.totalEnergy;
    }

    @Override
    public double getTotalCapital() {
        return this.totalCapital;
    }

    @Override
    public void addProcessedGarbageData(ProcessingData processingData) {
        this.setTotalEnergy(this.getTotalEnergy() + processingData.getEnergyBalance());
        this.setTotalCapital(this.getTotalCapital() + processingData.getCapitalBalance());
    }

    @Override
    public void denyPoducintg(String type, double energy, double capital) {
        this.garbageManager.setManagement(type, energy, capital);
    }

    @Override
    public void setManagement(String type) {
        this.garbageManager.setManagement(type, this.totalEnergy, this.totalCapital);
    }

    @Override
    public boolean canProduce(String type) {
        return this.garbageManager.canProduce(type, this.totalEnergy, this.totalCapital);
    }

    private void setTotalEnergy(double totalEnergy) {
        this.totalEnergy = totalEnergy;
    }

    private void setTotalCapital(double totalCapital) {
        this.totalCapital = totalCapital;
    }
}