package bg.softuni.app.framework.strategy;

import bg.softuni.app.framework.contracts.GarbageDisposalStrategy;
import bg.softuni.app.framework.contracts.ProcessingData;
import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.framework.processingData.ProcessingDataImpl;

public class RecyclableGarbageStrategy implements GarbageDisposalStrategy {

    @Override
    public ProcessingData processGarbage(Waste garbage) {
        double totalGarbageVolume = garbage.getWeight() * garbage.getVolumePerKg();

        double energyBalance = 0 - (totalGarbageVolume / 2.0);
        double capitalBalance = 400 * garbage.getWeight();

        return new ProcessingDataImpl(energyBalance, capitalBalance);
    }
}