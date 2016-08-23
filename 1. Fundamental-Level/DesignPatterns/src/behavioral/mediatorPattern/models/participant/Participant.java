package behavioral.mediatorPattern.models.participant;

import behavioral.mediatorPattern.models.charRoom.ChatRoom;

public interface Participant {
	String getName();

	void setChatRoom(ChatRoom chatRoom);

	void receiveMessage(String sender, String message);

	void sendMessage(String to, String message);
}