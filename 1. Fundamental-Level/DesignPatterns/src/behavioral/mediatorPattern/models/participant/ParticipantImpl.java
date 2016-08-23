package behavioral.mediatorPattern.models.participant;

import behavioral.mediatorPattern.models.charRoom.ChatRoom;

public class ParticipantImpl implements Participant {

	private String name;
	private ChatRoom chatRoom;

	public ParticipantImpl(String name) {
		this.name = name;
	}

	@Override
	public String getName() {
		return this.name;
	}

	@Override
	public void setChatRoom(ChatRoom chatRoom) {
		this.chatRoom = chatRoom;
	}

	@Override
	public void sendMessage(String to, String message) {
		this.chatRoom.send(this.getName(), to, message);
	}

	@Override
	public void receiveMessage(String sender, String message) {
		System.out.printf("%s to %s '%s'%n", sender, this.getName(), message);
	}
}