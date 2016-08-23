package behavioral.observerPattern.observable;

public interface YouTubeChannel extends Observable {
	void uploadNewVideo(String name);
}