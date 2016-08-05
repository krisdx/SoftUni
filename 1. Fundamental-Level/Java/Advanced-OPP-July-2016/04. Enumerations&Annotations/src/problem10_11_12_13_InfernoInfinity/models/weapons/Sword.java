package problem10_11_12_13_InfernoInfinity.models.weapons;

import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

public class Sword extends AbstractWeapon implements Weapon {

    private static final int MIN_SWORD_DAMAGE = 4;
    private static final int MAX_SWORD_DAMAGE = 6 ;
    private static final int SWORD_SOCKETS_COUNT = 3;

    public  Sword(String name) {
        super(name, MIN_SWORD_DAMAGE, MAX_SWORD_DAMAGE, SWORD_SOCKETS_COUNT);
    }
}