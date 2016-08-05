package problem5_ExtendedKingGambit.contracts;

import problem5_ExtendedKingGambit.events.HeroAttackEvent;

public interface HeroObserver {
    void respondToAttack(HeroAttackEvent heroAttackEvent);
}