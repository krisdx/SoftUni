package problem5_ExtendedKingGambit.events;

import java.util.EventObject;

public class HeroDeathEvent extends EventObject {

    private String heroName;

    /**
     * Constructs a prototypical Event.
     *
     * @param source The object on which the Event initially occurred.
     * @throws IllegalArgumentException if source is null.
     */
    public HeroDeathEvent(Object source, String heroName) {
        super(source);
        this.heroName = heroName;
    }

    public String getHeroName() {
        return this.heroName;
    }
}