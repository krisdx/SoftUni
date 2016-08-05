package problem1_EventImplementation.contracts;

public interface Observable {

    void addNameChangeListener(Observer listener);

    void removeNameChangeListener(Observer listener);
}