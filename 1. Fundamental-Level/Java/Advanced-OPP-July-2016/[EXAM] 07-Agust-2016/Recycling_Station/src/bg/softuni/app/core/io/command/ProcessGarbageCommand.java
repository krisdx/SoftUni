package bg.softuni.app.core.io.command;

import bg.softuni.app.core.factory.garbageFactory.GarbageFactory;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.framework.contracts.GarbageManager;
import bg.softuni.app.framework.contracts.GarbageProcessor;
import bg.softuni.app.framework.contracts.ProcessingData;
import bg.softuni.app.framework.contracts.Waste;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;
import com.sun.org.apache.regexp.internal.RE;

public class ProcessGarbageCommand extends Command implements Executable {

    @Inject
    private GarbageFactory garbageFactory;

    @Inject
    private GarbageProcessor garbageProcessor;

    @Inject
    private DataProvider database;

    public ProcessGarbageCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Waste garbage = null;
        try {

            garbage = this.garbageFactory.createGarbage(this.getData());

            if (!this.database.canProduce(garbage.getClass().getSimpleName())) {
                return Messages.CANNOT_PRODUCE;
            }

            ProcessingData processingData = this.garbageProcessor.processWaste(garbage);
            this.database.addProcessedGarbageData(processingData);
        } catch (ReflectiveOperationException ex) {
            return Messages.FAILED_GARBAGE_PROCESSING;
        }

        return String.format(Messages.SUCCESSFUL_GARBAGE_PROCESSING,
                garbage.getWeight(), garbage.getName());
    }
}