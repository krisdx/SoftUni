package problem5_ExtendedKingGambit.events;

import java.util.EventObject;

public class HeroAttackEvent extends EventObject {

    /**
     * Constructs a prototypical Event.
     *
     * @param source The object on which the Event initially occurred.
     * @throws IllegalArgumentException if source is null.
     */
    public HeroAttackEvent(Object source) {
        super(source);
    }
}