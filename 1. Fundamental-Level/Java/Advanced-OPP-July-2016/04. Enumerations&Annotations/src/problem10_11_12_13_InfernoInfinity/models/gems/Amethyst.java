package problem10_11_12_13_InfernoInfinity.models.gems;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;

public class Amethyst extends AbstractGem implements Gem {

    private static final int AMETHYST_STRENGTH = 2;
    private static final int AMETHYST_AGILITY = 8;
    private static final int AMETHYST_VITALITY = 4;

    public Amethyst() {
        super(AMETHYST_STRENGTH, AMETHYST_AGILITY, AMETHYST_VITALITY);
    }
}