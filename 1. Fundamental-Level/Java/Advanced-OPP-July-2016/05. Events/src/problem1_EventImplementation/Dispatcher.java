package problem1_EventImplementation;

import problem1_EventImplementation.contracts.Observable;
import problem1_EventImplementation.contracts.Observer;

import java.util.ArrayList;
import java.util.List;

public class Dispatcher implements Observable {

    private String name;
    private List<Observer> observers;

    public Dispatcher(String name) {
        this.name = name;
        this.observers = new ArrayList<>();
    }

    @Override
    public void addNameChangeListener(Observer listener) {
        this.observers.add(listener);
    }

    @Override
    public void removeNameChangeListener(Observer listener) {
        this.observers.remove(listener);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String changedName) {
        this.name = changedName;
        this.fireNameChangeEvent();
    }

    private void fireNameChangeEvent() {
        NameChangeEvent nameChangeEvent = new NameChangeEvent(this, this.getName());
        for (Observer observer : this.observers) {
            observer.handleChangedName(nameChangeEvent);
        }
    }
}