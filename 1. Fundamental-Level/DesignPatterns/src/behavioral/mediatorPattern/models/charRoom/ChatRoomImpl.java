package behavioral.mediatorPattern.models.charRoom;

import java.util.LinkedHashMap;
import java.util.Map;

import behavioral.mediatorPattern.models.participant.Participant;

public class ChatRoomImpl implements ChatRoom {

	private Map<String, Participant> participants;

	public ChatRoomImpl() {
		this.participants = new LinkedHashMap<>();
	}

	@Override
	public void register(Participant participant) {
		if (!this.participants.containsKey(participant.getName())) {
			this.participants.put(participant.getName(), participant);
		}

		participant.setChatRoom(this);
	}

	@Override
	public void send(String from, String to, String message) {
		Participant receiver = this.participants.get(to);
		if (receiver != null) {
			receiver.receiveMessage(from, message);
		}
	}
}