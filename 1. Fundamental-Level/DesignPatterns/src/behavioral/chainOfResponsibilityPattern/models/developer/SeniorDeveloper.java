package behavioral.chainOfResponsibilityPattern.models.developer;

import behavioral.chainOfResponsibilityPattern.models.bug.Bug;
import behavioral.chainOfResponsibilityPattern.models.bug.BugDifficulty;

public class SeniorDeveloper extends AbstractDeveloper implements Developer {

	public SeniorDeveloper(String name, Developer successor) {
		super(name, successor);
	}

	@Override
	public void handleBug(Bug bug) {
		if (bug.getBugDifficulty() == BugDifficulty.Hard) {
			System.out.printf("Hard Bug. Handled by Senior Developer %s - %n",
					this.getName());
		} else {
			super.handleBug(bug);
		}
	}
}