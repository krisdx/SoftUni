package bg.softuni.app.core.io.command;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class SelectCoreCommand extends Command implements Executable {
    @Inject
    private DataProvider database;

    public SelectCoreCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        Character coreName = this.getData()[0].charAt(0);
        try {
            this.database.selectCore(coreName);
        } catch (UnsupportedOperationException ex) {
            return String.format(Messages.FAILED_CORE_SELECTION, coreName);
        }

        return String.format(Messages.SUCCESSFUL_CORE_SELECTION, coreName);
    }
}