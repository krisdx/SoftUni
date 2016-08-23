package behavioral.observerPattern;

import behavioral.observerPattern.observable.YouTubeChannel;
import behavioral.observerPattern.observable.YouTubeChannelImpl;
import behavioral.observerPattern.observer.Observer;
import behavioral.observerPattern.observer.Subscriber;

public class Main {

	public static void main(String[] args) {

		/**
		 * Observer pattern presents an interface allowing objects to
		 * communicate without any concrete knowledge about each other. Allows
		 * an object to inform other object about its state, without the
		 * knowledge which are these objects.
		 */

		Observer subscriber1 = new Subscriber();
		Observer subscriber2 = new Subscriber();
		Observer subscriber3 = new Subscriber();

		YouTubeChannel youTubeChannel = new YouTubeChannelImpl(subscriber1, subscriber2, subscriber3);
		youTubeChannel.uploadNewVideo("New Test Video");
	}
}