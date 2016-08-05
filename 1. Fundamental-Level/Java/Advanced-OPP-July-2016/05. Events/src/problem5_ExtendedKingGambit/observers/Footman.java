package problem5_ExtendedKingGambit.observers;

import problem5_ExtendedKingGambit.contracts.AttackObservable;
import problem5_ExtendedKingGambit.events.HeroAttackEvent;
import problem5_ExtendedKingGambit.contracts.HeroObserver;

public class Footman extends AbstractHero implements HeroObserver {

    private static final int FOOTMAN_LIVES = 2;

    public Footman(String name, AttackObservable attackHandler) {
        super(name, attackHandler, FOOTMAN_LIVES);
    }

    @Override
    public void respondToAttack(HeroAttackEvent heroAttackEvent) {
        System.out.printf("Footman %s is panicking!%n",
                this.getName());
    }
}