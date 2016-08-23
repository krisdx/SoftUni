package behavioral.mediatorPattern.models.charRoom;

import behavioral.mediatorPattern.models.participant.Participant;

public interface ChatRoom {
	void register(Participant participant);

	void send(String from, String to, String message);
}