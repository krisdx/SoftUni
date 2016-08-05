package problem2_KingGambit.observers;

import problem2_KingGambit.contracts.HeroObserver;

public class King extends AbstractHero implements HeroObserver {

    public King(String name) {
        super(name);
    }

    @Override
    public void respondToAttack() {
        System.out.printf("King %s is under attack!%n",
                this.getName());
    }
}