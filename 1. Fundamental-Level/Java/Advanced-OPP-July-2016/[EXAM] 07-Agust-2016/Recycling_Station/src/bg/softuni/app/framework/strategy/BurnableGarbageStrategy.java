package bg.softuni.app.framework.strategy;

import bg.softuni.app.framework.contracts.GarbageDisposalStrategy;
import bg.softuni.app.framework.contracts.ProcessingData;
import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.framework.processingData.ProcessingDataImpl;

public class BurnableGarbageStrategy implements GarbageDisposalStrategy {

    @Override
    public ProcessingData processGarbage(Waste garbage) {
        double totalGarbageVolume = garbage.getWeight() * garbage.getVolumePerKg();

        double energyBalance = totalGarbageVolume - (totalGarbageVolume * 0.2);
        double capitalBalance = 0.0;

        return new ProcessingDataImpl(energyBalance, capitalBalance);
    }
}