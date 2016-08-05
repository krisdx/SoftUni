package problem10_11_12_13_InfernoInfinity.models.weapons;

import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

public class Knife extends AbstractWeapon implements Weapon {

    private static final int MIN_KNIFE_DAMAGE = 3;
    private static final int MAX_KNIFE_DAMAGE = 4;
    private static final int KNIFE_SOCKETS_COUNT = 2;

    public Knife(String name) {
        super(name, MIN_KNIFE_DAMAGE, MAX_KNIFE_DAMAGE, KNIFE_SOCKETS_COUNT);
    }
}