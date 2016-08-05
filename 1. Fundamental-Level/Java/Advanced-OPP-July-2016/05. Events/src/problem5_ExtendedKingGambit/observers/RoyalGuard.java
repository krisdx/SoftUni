package problem5_ExtendedKingGambit.observers;

import problem5_ExtendedKingGambit.contracts.AttackObservable;
import problem5_ExtendedKingGambit.contracts.HeroObserver;
import problem5_ExtendedKingGambit.events.HeroAttackEvent;

public class RoyalGuard extends AbstractHero implements HeroObserver {

    private static final int ROYAL_GUARD_LIVES = 3;

    public RoyalGuard(String name, AttackObservable attackHandler) {
        super(name, attackHandler, ROYAL_GUARD_LIVES);
    }

   @Override
    public void respondToAttack(HeroAttackEvent heroAttackEvent) {
        System.out.printf("Royal Guard %s is defending!%n",
                this.getName());
    }
}