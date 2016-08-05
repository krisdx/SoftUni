package problem1_EventImplementation.contracts;

import problem1_EventImplementation.NameChangeEvent;

public interface Observer {
    void handleChangedName(NameChangeEvent event);
}