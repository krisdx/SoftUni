package problem10_11_12_13_InfernoInfinity.contracts.factories;

import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

public interface WeaponFactory {
    Weapon createWeapon(String weaponName, String weaponType);
}