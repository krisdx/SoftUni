package problem2_KingGambit;

import problem2_KingGambit.contracts.AttackObservable;
import problem2_KingGambit.contracts.HeroObserver;
import problem2_KingGambit.observers.Footman;
import problem2_KingGambit.observers.King;
import problem2_KingGambit.observers.RoyalGuard;

import java.util.*;

public class AttackHandler implements AttackObservable {

    private HeroObserver king;
    private Map<String, HeroObserver> footmans;
    private Map<String, HeroObserver> royalGuards;

    public AttackHandler() {
        this.footmans = new LinkedHashMap<>();
        this.royalGuards = new LinkedHashMap<>();
    }

    @Override
    public void attachHero(HeroObserver heroObserver) {
        if (heroObserver instanceof King) {
            this.addKing(heroObserver);
        } else if (heroObserver instanceof Footman) {
            this.footmans.put(heroObserver.getName(), heroObserver);
        } else if (heroObserver instanceof RoyalGuard) {
            this.royalGuards.put(heroObserver.getName(), heroObserver);
        }
    }

    @Override
    public void killHero(String heroName) {
        if (this.footmans.containsKey(heroName)) {
            this.footmans.remove(heroName);
        } else if (this.royalGuards.containsKey(heroName)) {
            this.royalGuards.remove(heroName);
        }
    }

    @Override
    public void attackKing() {
        this.king.respondToAttack();

        this.royalGuards.values().forEach(HeroObserver::respondToAttack);
        this.footmans.values().forEach(HeroObserver::respondToAttack);
    }

    private void addKing(HeroObserver king) {
        if (this.king != null) {
            throw new UnsupportedOperationException("The King already exists.");
        }

        this.king = king;
    }
}