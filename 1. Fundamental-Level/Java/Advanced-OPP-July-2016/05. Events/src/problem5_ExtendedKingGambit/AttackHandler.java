package problem5_ExtendedKingGambit;

import problem5_ExtendedKingGambit.contracts.AttackObservable;
import problem5_ExtendedKingGambit.contracts.Attackable;
import problem5_ExtendedKingGambit.contracts.HeroObserver;
import problem5_ExtendedKingGambit.events.HeroAttackEvent;
import problem5_ExtendedKingGambit.events.HeroDeathEvent;
import problem5_ExtendedKingGambit.observers.AbstractHero;
import problem5_ExtendedKingGambit.observers.Footman;
import problem5_ExtendedKingGambit.observers.RoyalGuard;

import java.util.*;

public class AttackHandler implements AttackObservable {

    private Attackable king;
    private Map<String, AbstractHero> footmans;
    private Map<String, AbstractHero> royalGuards;

    public AttackHandler() {
        this.footmans = new LinkedHashMap<>();
        this.royalGuards = new LinkedHashMap<>();
    }

    @Override
    public void attachHero(AbstractHero heroObserver) {
        if (heroObserver instanceof Footman) {
            this.footmans.put(heroObserver.getName(), heroObserver);
        } else if (heroObserver instanceof RoyalGuard) {
            this.royalGuards.put(heroObserver.getName(), heroObserver);
        }
    }

    @Override
    public void attachKing(Attackable king) {
        if (this.king != null) {
            throw new UnsupportedOperationException("The King already exists.");
        }

        this.king = king;
    }

    @Override
    public void attackHero(String heroName) {
        AbstractHero hero = this.getHeroByName(heroName);
        if (hero != null) {
            hero.setLivesCount(hero.getLivesCount() - 1);
        }
    }

    @Override
    public void respondToHeroDeathEvent(HeroDeathEvent heroDeathEvent) {
        if (this.footmans.containsKey(heroDeathEvent.getHeroName())) {
            this.footmans.remove(heroDeathEvent.getHeroName());
        } else if (this.royalGuards.containsKey(heroDeathEvent.getHeroName())) {
            this.royalGuards.remove(heroDeathEvent.getHeroName());
        }
    }

    @Override
    public void attackKing() {
        this.king.respondToAttack();
        this.triggerHeroAttackEvent();
    }

    private void triggerHeroAttackEvent() {
        HeroAttackEvent heroAttackEvent = new HeroAttackEvent(this);
        for (HeroObserver royalGuard : this.royalGuards.values()) {
            royalGuard.respondToAttack(heroAttackEvent);
        }

        for (HeroObserver footman : this.footmans.values()) {
            footman.respondToAttack(heroAttackEvent);
        }
    }

    private AbstractHero getHeroByName(String heroName) {
        if (this.royalGuards.containsKey(heroName)) {
            return this.royalGuards.get(heroName);
        } else if (this.footmans.containsKey(heroName)) {
            return this.footmans.get(heroName);
        }

        return null;
    }
}