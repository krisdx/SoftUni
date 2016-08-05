package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "END")
public class EndCommand extends Command implements Executable {

    public EndCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        this.getEngine().stop();
    }
}