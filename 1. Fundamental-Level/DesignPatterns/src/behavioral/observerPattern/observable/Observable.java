package behavioral.observerPattern.observable;

import behavioral.observerPattern.observer.Observer;

public interface Observable {
	
	void attachObserver(Observer observer);
	
	void detachObserver(Observer observer);
	
	// void notifyObservers();
}