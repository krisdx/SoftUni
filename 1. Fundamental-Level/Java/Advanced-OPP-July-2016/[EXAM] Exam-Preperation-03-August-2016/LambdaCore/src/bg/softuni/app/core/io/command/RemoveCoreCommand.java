package bg.softuni.app.core.io.command;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class RemoveCoreCommand extends Command implements Executable {

    @Inject
    private DataProvider database;

    public RemoveCoreCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Character coreName = this.getData()[0].charAt(0);
        try {
            this.database.removeCore(coreName);
        } catch (UnsupportedOperationException ex) {
            return String.format(Messages.FAILED_TO_REMOVE_CORE, coreName);
        }

        return String.format(Messages.REMOVE_CORE_SUCCESSFUL, coreName);
    }
}