package problem5_ExtendedKingGambit.observers;

import problem5_ExtendedKingGambit.AttackHandler;
import problem5_ExtendedKingGambit.contracts.AttackObservable;
import problem5_ExtendedKingGambit.contracts.HeroObserver;
import problem5_ExtendedKingGambit.events.HeroDeathEvent;

public abstract class AbstractHero implements HeroObserver {

    private String name;
    private int livesCount;

    private AttackObservable attackHandler;

    protected AbstractHero(String name, AttackObservable attackHandler, int livesCount) {
        this.setName(name);
        this.setLivesCount(livesCount);
        this.attackHandler = attackHandler;
    }

    public String getName() {
        return this.name;
    }

    private void setName(String name) {
        if (name.isEmpty() || name.equals("")) {
            throw new IllegalArgumentException(
                    "The name of the hero cannot be empty.");
        }

        this.name = name;
    }

    public int getLivesCount() {
        return this.livesCount;
    }

    public void setLivesCount(int livesCount) {
        this.livesCount = livesCount;
        if (this.getLivesCount() == 0) {
            HeroDeathEvent deathEvent = new HeroDeathEvent(this, this.getName());
            this.attackHandler.respondToHeroDeathEvent(deathEvent);
        }
    }
}