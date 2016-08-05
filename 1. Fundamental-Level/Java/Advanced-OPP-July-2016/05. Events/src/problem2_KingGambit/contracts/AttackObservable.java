package problem2_KingGambit.contracts;

public interface AttackObservable {
    void attachHero(HeroObserver hero);

    void killHero(String heroName);

    void attackKing();
}