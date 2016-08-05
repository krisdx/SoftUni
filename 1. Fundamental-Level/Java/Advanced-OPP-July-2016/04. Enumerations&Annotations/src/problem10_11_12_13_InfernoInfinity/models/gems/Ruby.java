package problem10_11_12_13_InfernoInfinity.models.gems;

import problem10_11_12_13_InfernoInfinity.contracts.models.Gem;

public class Ruby extends AbstractGem implements Gem {

    private static final int RUBY_STRENGTH = 7;
    private static final int RUBY_AGILITY = 2;
    private static final int RUBY_VITALITY = 5;

    public Ruby() {
        super(RUBY_STRENGTH, RUBY_AGILITY, RUBY_VITALITY);
    }
}