package behavioral.observerPattern.observer;

import behavioral.observerPattern.observable.YouTubeChannel;

public class Subscriber implements Observer {

	@Override
	public void respondToEvent(YouTubeChannel youTubeChannel, String name) {
		System.out.println(String.format("New video '%s' uploaded by %s", 
				name, youTubeChannel.toString()));
	}
}