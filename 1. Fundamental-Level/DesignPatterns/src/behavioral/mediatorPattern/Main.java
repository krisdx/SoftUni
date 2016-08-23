package behavioral.mediatorPattern;

import behavioral.mediatorPattern.models.charRoom.ChatRoom;
import behavioral.mediatorPattern.models.charRoom.ChatRoomImpl;
import behavioral.mediatorPattern.models.participant.Participant;
import behavioral.mediatorPattern.models.participant.ParticipantImpl;

public class Main {

	public static void main(String[] args) {

		/**
		 * Mediator pattern simplifies communication between classes. Defines an
		 * object that encapsulates how a set of objects interact. Promotes
		 * loose coupling by keeping objects from referring to each other
		 * explicitly.
		 */

		ChatRoom chatRoom = new ChatRoomImpl();

		Participant george = new ParticipantImpl("George");
		Participant paul = new ParticipantImpl("Paul");
		Participant ringo = new ParticipantImpl("Ringo");
		Participant john = new ParticipantImpl("John");
		Participant yoko = new ParticipantImpl("Yoko");

		chatRoom.register(george);
		chatRoom.register(paul);
		chatRoom.register(ringo);
		chatRoom.register(john);
		chatRoom.register(yoko);

		yoko.sendMessage("John", "Hi John!");
		paul.sendMessage("Ringo", "All you need is love");
		ringo.sendMessage("George", "My sweet Lord");
		paul.sendMessage("John", "Can't buy me love");
		john.sendMessage("Yoko", "My sweet love");
	}
}