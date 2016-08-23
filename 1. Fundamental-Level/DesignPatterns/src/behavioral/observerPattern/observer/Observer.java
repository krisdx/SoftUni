package behavioral.observerPattern.observer;

import behavioral.observerPattern.observable.YouTubeChannel;

public interface Observer {
	void respondToEvent(YouTubeChannel youTubeChannel, String name);
}