package problem10_11_12_13_InfernoInfinity.models.weapons;

import java.util.*;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;
import problem10_11_12_13_InfernoInfinity.contracts.models.Weapon;
import problem10_11_12_13_InfernoInfinity.utilities.ClassInfo;
import problem10_11_12_13_InfernoInfinity.utilities.ExceptionMessages;

@ClassInfo(
        author = "Pesho",
        revision = 3,
        description = "Used for Java OOP Advanced course - Enumerations and Annotations.",
        reviewers = {"Pesho", "Svetlio"})
public abstract class AbstractWeapon implements Weapon {

    private String name;

    private int minDamage;
    private int maxDamage;
    private int socketsCount;

    private int strength;
    private int agility;
    private int vitality;

    private Map<Integer, Gem> gems;

    protected AbstractWeapon(String name, int minDamage, int maxDamage, int socketsCount) {
        this.setName(name);
        this.setMinDamage(minDamage);
        this.setMaxDamage(maxDamage);
        this.setSocketsCount(socketsCount);
        this.initGems();
    }

    /**
     *
     * Add the specified gem to the weapon and applies it's effect.
     *
     * @param socketIndex The index where the gem will be inserted
     * @param gem The gem to be inserted
     */
    @Override
    public void addGem(int socketIndex, Gem gem) {
        if (!this.gems.containsKey(socketIndex)) {
            return;
        }

        if (this.gems.get(socketIndex) != null) {
            this.removeEffectOnWeapon(this.gems.get(socketIndex));
        }

        this.applyEffectOnWeapon(gem);
        this.gems.put(socketIndex, gem);
    }

    @Override
    public void removeGem(int socketIndex) {
        if (!this.gems.containsKey(socketIndex)) {
            return;
        }

        if (this.gems.get(socketIndex) == null) {
            return;
        }

        Gem gemToRemove = this.gems.get(socketIndex);
        this.removeEffectOnWeapon(gemToRemove);
        this.gems.remove(socketIndex);
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getMinDamage() {
        return this.minDamage;
    }

    @Override
    public int getMaxDamage() {
        return this.maxDamage;
    }

    @Override
    public int getSocketsCount() {
        return this.socketsCount;
    }

    @Override
    public int getStrength() {
        return this.strength;
    }

    @Override
    public int getAgility() {
        return this.agility;
    }

    @Override
    public int getVitality() {
        return this.vitality;
    }

    @Override
    public Map<Integer, Gem> getGems() {
        return this.gems;
    }

    @Override
    public double getWeaponPower() {
        double averageDamage = (this.getMinDamage() + this.getMaxDamage()) / 2.0d;
        double weaponPower = averageDamage +
                this.getStrength() + this.getAgility() + this.getVitality();
        return weaponPower;
    }

    @Override
    public int compareTo(Weapon other) {
        return Double.compare(this.getWeaponPower(), other.getWeaponPower());
    }

    @Override
    public String toString() {
        return String.format("%s: " +
                        "%d-%d Damage, " +
                        "+%d Strength, +%d Agility, +%d Vitality",
                this.getName(),
                this.getMinDamage(), this.getMaxDamage(),
                this.getStrength(), this.getAgility(), this.getVitality());
    }

    private void setName(String name) {
        if (name.isEmpty() || name.equals("")) {
            throw new IllegalArgumentException("Name cannot be empty");
        }

        this.name = name;
    }

    private void setMaxDamage(int maxDamage) {
        this.validateInput(maxDamage, ExceptionMessages.NEGATIVE_MAX_DAMAGE);
        this.maxDamage = maxDamage;
    }

    private void setMinDamage(int minDamage) {
        this.validateInput(minDamage, ExceptionMessages.NEGATIVE_MINIMAL_DAMAGE);
        this.minDamage = minDamage;
    }

    private void setSocketsCount(int socketsCount) {
        this.validateInput(socketsCount, ExceptionMessages.NEGATIVE_SOCKETS_COUNT);
        this.socketsCount = socketsCount;
    }

    private void setStrength(int strength) {
        this.validateInput(strength, ExceptionMessages.NEGATIVE_STRENGTH);
        this.strength = strength;
    }

    private void setAgility(int agility) {
        this.validateInput(strength, ExceptionMessages.NEGATIVE_AGILITY);
        this.agility = agility;
    }

    private void setVitality(int vitality) {
        this.validateInput(strength, ExceptionMessages.NEGATIVE_VITALITY);
        this.vitality = vitality;
    }

    private void initGems() {
        this.gems = new LinkedHashMap<>();
        for (int socketIndex = 0; socketIndex < this.getSocketsCount(); socketIndex++) {
            this.gems.put(socketIndex, null);
        }
    }

    private void removeEffectOnWeapon(Gem gemToRemove) {
        int gemStrengthPoints = gemToRemove.getStrength();
        int gemAgilityPoints = gemToRemove.getAgility();
        int gemVitalityPoints = gemToRemove.getVitality();

        this.setMinDamage(this.getMinDamage() - gemStrengthPoints * 2);
        this.setMaxDamage(this.getMaxDamage() - gemStrengthPoints * 3);

        this.setMinDamage(this.getMinDamage() - gemAgilityPoints);
        this.setMaxDamage(this.getMaxDamage() - gemAgilityPoints * 4);

        this.setStrength(this.getStrength() - gemStrengthPoints);
        this.setAgility(this.getAgility() - gemAgilityPoints);
        this.setVitality(this.getVitality() - gemVitalityPoints);
    }

    private void applyEffectOnWeapon(Gem gem) {
        int gemStrengthPoints = gem.getStrength();
        int gemAgilityPoints = gem.getAgility();
        int gemVitalityPoints = gem.getVitality();

        this.setMinDamage(this.getMinDamage() + gemStrengthPoints * 2);
        this.setMaxDamage(this.getMaxDamage() + gemStrengthPoints * 3);

        this.setMinDamage(this.getMinDamage() + gemAgilityPoints);
        this.setMaxDamage(this.getMaxDamage() + gemAgilityPoints * 4);

        this.setStrength(this.getStrength() + gemStrengthPoints);
        this.setAgility(this.getAgility() + gemAgilityPoints);
        this.setVitality(this.getVitality() + gemVitalityPoints);
    }

    private void validateInput(int value, String exceptionMessage) {
        if (value < 0) {
            throw new IllegalArgumentException(exceptionMessage);
        }
    }
}