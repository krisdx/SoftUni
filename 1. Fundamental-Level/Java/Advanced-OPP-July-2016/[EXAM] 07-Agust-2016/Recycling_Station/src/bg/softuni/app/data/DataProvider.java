package bg.softuni.app.data;

import bg.softuni.app.framework.contracts.GarbageManager;
import bg.softuni.app.framework.contracts.ProcessingData;

public interface DataProvider {

    double getTotalEnergy();

    double getTotalCapital();

    void addProcessedGarbageData(ProcessingData processingData);

    void denyPoducintg(String type, double energy, double capital);

    void setManagement(String type);

    boolean canProduce(String type);
}