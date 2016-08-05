package problem2_KingGambit.observers;

import problem2_KingGambit.contracts.HeroObserver;

public class RoyalGuard extends AbstractHero implements HeroObserver {

    public RoyalGuard(String name) {
        super(name);
    }

    @Override
    public void respondToAttack() {
        System.out.printf("Royal Guard %s is defending!%n",
                this.getName());
    }
}