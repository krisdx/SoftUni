package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Create")
public class CreateCommand extends Command {

    public CreateCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        String weaponType = args[1];
        String weaponName = args[2];
        Weapon weapon = this.getEngine().getWeaponFactory().createWeapon(weaponName, weaponType);
        this.getEngine().getDatabase().addWeapon(weapon);
    }
}