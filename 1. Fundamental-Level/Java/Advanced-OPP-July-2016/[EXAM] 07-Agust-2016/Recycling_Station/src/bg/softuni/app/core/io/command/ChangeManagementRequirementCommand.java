package bg.softuni.app.core.io.command;

import bg.softuni.app.data.DataProvider;
import bg.softuni.app.utility.Messages;
import bg.softuni.app.utility.annotations.Inject;

public class ChangeManagementRequirementCommand extends Command implements Executable {

    @Inject
    private DataProvider database;

    public ChangeManagementRequirementCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        double energyBalance = Double.valueOf(this.getData()[0]);
        double capitalBalance = Double.valueOf(this.getData()[1]);
        String garbageType = this.getData()[2];

        this.database.denyPoducintg(garbageType, energyBalance, capitalBalance);
        return Messages.SUCCESSFUL_MANAGEMENT_CHANGED;
    }
}