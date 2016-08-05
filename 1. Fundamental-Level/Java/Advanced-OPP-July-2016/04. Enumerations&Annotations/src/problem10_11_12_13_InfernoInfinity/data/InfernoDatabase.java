package problem10_11_12_13_InfernoInfinity.data;

import problem10_11_12_13_InfernoInfinity.contracts.databese.Database;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

import java.util.LinkedHashMap;
import java.util.Map;

public class InfernoDatabase implements Database {

    private Map<String, Weapon> weapons;

    public InfernoDatabase() {
        this.weapons = new LinkedHashMap<>();
    }

    @Override
    public void addWeapon(Weapon weapon) {
        this.weapons.put(weapon.getName(), weapon);
    }

    @Override
    public Map<String, Weapon> getWeapons() {
        return this.weapons;
    }
}