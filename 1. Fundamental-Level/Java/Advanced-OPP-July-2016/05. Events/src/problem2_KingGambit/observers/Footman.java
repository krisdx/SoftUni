package problem2_KingGambit.observers;

import problem2_KingGambit.contracts.HeroObserver;

public class Footman extends AbstractHero implements HeroObserver {

    public Footman(String name) {
        super(name);
    }

    @Override
    public void respondToAttack() {
        System.out.printf("Footman %s is panicking!%n",
                this.getName());
    }
}