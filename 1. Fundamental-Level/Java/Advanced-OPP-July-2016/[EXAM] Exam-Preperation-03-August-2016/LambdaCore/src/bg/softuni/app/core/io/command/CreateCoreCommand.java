package bg.softuni.app.core.io.command;

import bg.softuni.app.core.factory.coreFactory.CoreFactory;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.models.cores.Core;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class CreateCoreCommand extends Command implements Executable {

    @Inject
    private CoreFactory coreFactory;

    @Inject
    private DataProvider database;

    public CreateCoreCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Core core = null;
        try {
            core = this.coreFactory.createCore(this.getData());
            this.database.addCore(core);
        } catch (ReflectiveOperationException | IllegalArgumentException ex) {
            return Messages.FAILED_CORE_CREATION;
        }

        return String.format(Messages.SUCCESSFUL_CORE_CREATION, core.getName());
    }
}