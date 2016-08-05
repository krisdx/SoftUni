package problem3_4_5_BarrackWars.core.commands;

import problem3_4_5_BarrackWars.annotations.CommandName;
import problem3_4_5_BarrackWars.annotations.Inject;
import problem3_4_5_BarrackWars.contracts.Executable;
import problem3_4_5_BarrackWars.contracts.Repository;

@CommandName("report")
public class ReportCommand extends Command implements Executable {

    @Inject
    private Repository repository;

    public ReportCommand(String[] data) {
        super(data);
    }

    @Override
    public String execute() {
        String output = this.repository.getStatistics();
        return output;
    }
}