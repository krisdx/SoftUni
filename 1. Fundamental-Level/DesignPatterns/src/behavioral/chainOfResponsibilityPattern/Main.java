package behavioral.chainOfResponsibilityPattern;

import behavioral.chainOfResponsibilityPattern.models.bug.BugDifficulty;
import behavioral.chainOfResponsibilityPattern.models.bug.BugImpl;
import behavioral.chainOfResponsibilityPattern.models.developer.Developer;
import behavioral.chainOfResponsibilityPattern.models.developer.JuniorDeveloper;
import behavioral.chainOfResponsibilityPattern.models.developer.SeniorDeveloper;
import behavioral.chainOfResponsibilityPattern.models.developer.RegularDeveloper;

public class Main {

	public static void main(String[] args) {

		/**
		 * Chain of Responsibility pattern allows an object to pass a request
		 * to another object until the request is fulfilled.
		 * 
		 * An object-oriented linked list with recursive traversal. Each sender
		 * keeps a single reference to the next.
		 */

		Developer seniorDeveloper = new SeniorDeveloper("Georgi", null);
		Developer regularDeveloper = new RegularDeveloper("Iven", seniorDeveloper);
		Developer juniorDeveloper = new JuniorDeveloper("Petio", regularDeveloper);

		juniorDeveloper.handleBug(new BugImpl(BugDifficulty.Easy));
		juniorDeveloper.handleBug(new BugImpl(BugDifficulty.Medium));
		juniorDeveloper.handleBug(new BugImpl(BugDifficulty.Hard));
		juniorDeveloper.handleBug(new BugImpl(BugDifficulty.Impossible));
	}
}