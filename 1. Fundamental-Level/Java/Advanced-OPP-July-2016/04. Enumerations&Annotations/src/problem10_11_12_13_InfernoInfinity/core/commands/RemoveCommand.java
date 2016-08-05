package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Remove")
public class RemoveCommand extends Command implements Executable {

    public RemoveCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        String weaponName = args[1];
        int socketIndex = Integer.valueOf(args[2]);

        Weapon weapon = this.getEngine().getDatabase().getWeapons().get(weaponName);
        weapon.removeGem(socketIndex);
    }
}