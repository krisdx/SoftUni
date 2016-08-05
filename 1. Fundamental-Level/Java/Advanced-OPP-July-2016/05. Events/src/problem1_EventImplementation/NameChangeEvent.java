package problem1_EventImplementation;

import java.util.EventObject;

public class NameChangeEvent extends EventObject {

    private String changedName;

    /**
     * Constructs a prototypical NameChangeEvent.
     *
     * @param changedName The object on which the NameChangeEvent initially occurred.
     * @throws IllegalArgumentException if changedName is null.
     */
    public NameChangeEvent(Object sender, String changedName) {
        super(sender);
        this.changedName = changedName;
    }

    public String getChangedName(){
        return this.changedName;
    }
}