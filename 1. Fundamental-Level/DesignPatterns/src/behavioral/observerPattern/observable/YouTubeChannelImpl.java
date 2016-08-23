package behavioral.observerPattern.observable;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import behavioral.observerPattern.observer.Observer;

public class YouTubeChannelImpl implements Observable, YouTubeChannel {

	private List<Observer> observers;

	public YouTubeChannelImpl(Observer... observers) {
		this.observers = new ArrayList<>(Arrays.asList(observers));
	}

	@Override
	public void attachObserver(Observer observer) {
		this.observers.add(observer);
	}

	@Override
	public void detachObserver(Observer observer) {
		this.observers.remove(observer);
	}

	@Override
	public void uploadNewVideo(String name) {
		this.notifyObservers(name);
	}

	@Override
	public String toString() {
		return "Random YouTube Channel";
	}	
	
	private void notifyObservers(String name) {
		for (Observer observer : this.observers) {
			observer.respondToEvent(this, name);
		}
	}
}