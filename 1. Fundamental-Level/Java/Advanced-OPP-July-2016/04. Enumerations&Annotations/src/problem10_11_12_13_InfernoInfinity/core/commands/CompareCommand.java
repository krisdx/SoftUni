package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;
import problem10_11_12_13_InfernoInfinity.utilities.CommandName;

@CommandName(name = "Compare")
public class CompareCommand extends Command implements Executable {

    public CompareCommand(Engine engine) {
        super(engine);
    }

    @Override
    public void execute(String[] args) {
        String firstWeaponName = args[1];
        Weapon firstWeapon = this.getEngine().getDatabase().getWeapons().get(firstWeaponName);
        String secondWeaponName = args[2];
        Weapon secondWeapon = this.getEngine().getDatabase().getWeapons().get(secondWeaponName);

        int compareResult = firstWeapon.compareTo(secondWeapon);
        if (compareResult >= 0) {
            this.getEngine().getWriter().print(firstWeapon.toString());
            this.getEngine().getWriter().printLine(String.format(" (Item Level: %.1f)", firstWeapon.getWeaponPower()));
        } else {
            this.getEngine().getWriter().print(secondWeapon.toString());
            this.getEngine().getWriter().printLine(String.format(" (Item Level: %.1f)", secondWeapon.getWeaponPower()));
        }
    }
}