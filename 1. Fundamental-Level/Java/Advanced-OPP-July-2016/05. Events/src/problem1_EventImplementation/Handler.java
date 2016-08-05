package problem1_EventImplementation;

import problem1_EventImplementation.contracts.Observer;

public class Handler implements Observer {

    @Override
    public void handleChangedName(NameChangeEvent nameChangeEventEvent) {
        System.out.printf("Dispatcher's name changed to %s.%n", nameChangeEventEvent.getChangedName());
    }
}