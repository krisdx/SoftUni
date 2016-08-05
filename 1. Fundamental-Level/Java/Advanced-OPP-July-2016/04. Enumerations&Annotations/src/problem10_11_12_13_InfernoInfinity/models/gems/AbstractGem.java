package problem10_11_12_13_InfernoInfinity.models.gems;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;
import problem10_11_12_13_InfernoInfinity.utilities.ExceptionMessages;

public abstract class AbstractGem implements Gem {

    private int strength;
    private int agility;
    private int vitality;

    protected AbstractGem(int strength, int agility, int vitality) {
        this.setStrength(strength);
        this.setAgility(agility);
        this.setVitality(vitality);
    }

    public int getStrength() {
        return this.strength;
    }

    public int getAgility() {
        return this.agility;
    }

    public int getVitality() {
        return this.vitality;
    }

    private void setStrength(int strength) {
        this.validateInput(strength, ExceptionMessages.NEGATIVE_STRENGTH);
        this.strength = strength;
    }

    private void setAgility(int agility) {
        this.validateInput(agility, ExceptionMessages.NEGATIVE_AGILITY);
        this.agility = agility;
    }

    private void setVitality(int vitality) {
        this.validateInput(vitality, ExceptionMessages.NEGATIVE_VITALITY);
        this.vitality = vitality;
    }

    private void validateInput(int value, String exceptionMessage) {
        if (value < 0) {
            throw new IllegalArgumentException(exceptionMessage);
        }
    }
}