package problem10_11_12_13_InfernoInfinity.core.factories;

import problem10_11_12_13_InfernoInfinity.contracts.factories.WeaponFactory;
import problem10_11_12_13_InfernoInfinity.utilities.ExceptionMessages;
import problem10_11_12_13_InfernoInfinity.models.weapons.Axe;
import problem10_11_12_13_InfernoInfinity.models.weapons.Knife;
import problem10_11_12_13_InfernoInfinity.models.weapons.Sword;
import problem10_11_12_13_InfernoInfinity.models.weapons.AbstractWeapon;

public class WeaponFactoryImpl implements WeaponFactory {

    @Override
    public AbstractWeapon createWeapon(String weaponName, String weaponType) {
        switch (weaponType.toLowerCase()) {
            case "axe":
                return new Axe(weaponName);
            case "sword":
                return new Sword(weaponName);
            case "knife":
                return new Knife(weaponName);
            default:
                throw new IllegalArgumentException(
                        ExceptionMessages.UNKNOWN_WEAPON_TYPE);
        }
    }
}