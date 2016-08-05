package problem2_KingGambit.observers;

import problem2_KingGambit.contracts.HeroObserver;

public abstract class AbstractHero implements HeroObserver {

    private String name;

    protected AbstractHero(String name) {
        this.setName(name);
    }

    @Override
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
}