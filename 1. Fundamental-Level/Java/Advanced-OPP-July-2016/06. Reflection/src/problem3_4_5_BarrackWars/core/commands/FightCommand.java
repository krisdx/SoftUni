package problem3_4_5_BarrackWars.core.commands;

import problem3_4_5_BarrackWars.annotations.CommandName;
import problem3_4_5_BarrackWars.contracts.Executable;

@CommandName("fight")
public class FightCommand extends Command implements Executable {

    public FightCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        return "fight";
    }
}