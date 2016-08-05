package problem10_11_12_13_InfernoInfinity.models.gems;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;

public class Emerald extends AbstractGem implements Gem {

    private static final int EMERALD_STRENGTH = 1;
    private static final int EMERALD_AGILITY = 4;
    private static final int EMERALD_VITALITY = 9;

    public Emerald() {
        super(EMERALD_STRENGTH, EMERALD_AGILITY, EMERALD_VITALITY);
    }
}