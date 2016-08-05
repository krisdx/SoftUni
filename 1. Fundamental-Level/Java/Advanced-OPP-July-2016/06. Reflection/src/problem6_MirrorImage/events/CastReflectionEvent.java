package problem6_MirrorImage.events;

import java.util.EventObject;

public class CastReflectionEvent extends EventObject {

    /**
     * Constructs a prototypical Event.
     *
     * @param source The object on which the Event initially occurred.
     * @throws IllegalArgumentException if source is null.
     */
    public CastReflectionEvent(Object source) {
        super(source);
    }
}