package problem5_ExtendedKingGambit.contracts;

import problem5_ExtendedKingGambit.events.HeroDeathEvent;
import problem5_ExtendedKingGambit.observers.AbstractHero;

public interface AttackObservable {
    void attachHero(AbstractHero heroObserver);

    void attachKing(Attackable king);

    void attackHero(String heroName);

    void respondToHeroDeathEvent(HeroDeathEvent heroDeathEvent);

    void attackKing();
}