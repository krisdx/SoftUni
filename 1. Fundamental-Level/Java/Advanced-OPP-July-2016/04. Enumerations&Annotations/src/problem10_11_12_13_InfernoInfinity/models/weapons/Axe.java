package problem10_11_12_13_InfernoInfinity.models.weapons;

import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

public class Axe extends AbstractWeapon implements Weapon {

    private static final int MIN_AXE_DAMAGE = 5;
    private static final int MAX_AXE_DAMAGE = 10;
    private static final int AXE_SOCKETS_COUNT = 4;

    public Axe(String name) {
        super(name, MIN_AXE_DAMAGE, MAX_AXE_DAMAGE, AXE_SOCKETS_COUNT);
    }
}