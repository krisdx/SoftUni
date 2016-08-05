package problem10_11_12_13_InfernoInfinity.contracts.databese;

import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;

import java.util.*;

public interface Database {

    Map<String, Weapon> getWeapons();

    void addWeapon(Weapon weapon);
}