package behavioral.chainOfResponsibilityPattern.models.developer;

import behavioral.chainOfResponsibilityPattern.models.bug.Bug;
import behavioral.chainOfResponsibilityPattern.models.bug.BugDifficulty;

public class RegularDeveloper extends AbstractDeveloper implements Developer {

	public RegularDeveloper(String name, Developer successor) {
		super(name, successor);
	}

	@Override
	public void handleBug(Bug bug) {

		if (bug.getBugDifficulty() == BugDifficulty.Medium) {
			System.out.printf("Medium Bug. Handled by Regular Developer %s - %n",
					this.getName());
		} else {
			super.handleBug(bug);
		}
	}
}