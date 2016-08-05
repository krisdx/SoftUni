package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Print")
public class PrintCommand extends Command implements Executable{

    public PrintCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        String weaponName = args[1];
        Weapon weapon = this.getEngine().getDatabase().getWeapons().get(weaponName);
        this.getEngine().getWriter().printLine(weapon.toString());
    }
}