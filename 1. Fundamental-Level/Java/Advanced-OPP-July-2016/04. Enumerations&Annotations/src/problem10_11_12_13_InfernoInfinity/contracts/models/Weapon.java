package problem10_11_12_13_InfernoInfinity.contracts.models;

import java.util.Map;

public interface Weapon extends Comparable<Weapon> {

    void addGem(int socketIndex, Gem gem);

    void removeGem(int socketIndex);

    String getName();

    int getMinDamage();

    int getMaxDamage();

    int getSocketsCount();

    int getStrength();

    int getAgility();

    int getVitality();

    double getWeaponPower();

    Map<Integer, Gem> getGems();
}