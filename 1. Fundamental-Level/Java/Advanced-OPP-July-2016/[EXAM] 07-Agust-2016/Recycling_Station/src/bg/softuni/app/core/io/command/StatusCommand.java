package bg.softuni.app.core.io.command;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class StatusCommand extends Command implements Executable {

    @Inject
    private DataProvider database;

    public StatusCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        String status = String.format(Messages.STATUS_MESSAGE,
                this.database.getTotalEnergy(), this.database.getTotalCapital());
        return status;
    }
}