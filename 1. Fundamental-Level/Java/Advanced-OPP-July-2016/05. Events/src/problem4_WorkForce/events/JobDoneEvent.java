package problem4_WorkForce.events;

import java.util.EventObject;

/**
 * This event is triggered when a job is done and
 * has to be removed from the collection.
 */
public class JobDoneEvent extends EventObject {

    /**
     * Constructs a prototypical Event.
     *
     * @param source The object on which the Event initially occurred.
     * @throws IllegalArgumentException if source is null.
     */
    public JobDoneEvent(Object source) {
        super(source);
    }
}