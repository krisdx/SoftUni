package problem3_4_5_BarrackWars.core.commands;

import problem3_4_5_BarrackWars.annotations.CommandName;
import problem3_4_5_BarrackWars.annotations.Inject;
import problem3_4_5_BarrackWars.contracts.Executable;
import problem3_4_5_BarrackWars.contracts.Repository;
import problem3_4_5_BarrackWars.contracts.Unit;
import problem3_4_5_BarrackWars.contracts.UnitFactory;

@CommandName("add")
public class AddCommand extends Command implements Executable {

    @Inject
    private UnitFactory unitFactory;
    @Inject
    private Repository repository;

    public AddCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        String unitType = this.getData()[1];
        Unit unitToAdd = this.unitFactory.createUnit(unitType);
        this.repository.addUnit(unitToAdd);
        String output = unitType + " added!";
        return output;
    }
}