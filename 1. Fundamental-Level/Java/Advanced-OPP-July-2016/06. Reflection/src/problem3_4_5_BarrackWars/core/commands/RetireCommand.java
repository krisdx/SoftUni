package problem3_4_5_BarrackWars.core.commands;

import problem3_4_5_BarrackWars.annotations.CommandName;
import problem3_4_5_BarrackWars.annotations.Inject;
import problem3_4_5_BarrackWars.contracts.Executable;
import problem3_4_5_BarrackWars.contracts.Repository;

@CommandName("retire")
public class RetireCommand extends Command implements Executable {

    @Inject
    private Repository repository;

    public RetireCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        String unitType = this.getData()[1];
        if (!this.repository.getUnitsAmount().containsKey(unitType)) {
            return "No such units in repository.";
        }

        this.repository.removeUnit(unitType);
        return unitType + " retired!";
    }
}