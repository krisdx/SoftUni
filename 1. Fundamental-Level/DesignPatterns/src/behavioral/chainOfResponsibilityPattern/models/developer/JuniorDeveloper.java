package behavioral.chainOfResponsibilityPattern.models.developer;

import behavioral.chainOfResponsibilityPattern.models.bug.Bug;
import behavioral.chainOfResponsibilityPattern.models.bug.BugDifficulty;

public class JuniorDeveloper extends AbstractDeveloper implements Developer {

	public JuniorDeveloper(String name, Developer successor) {
		super(name, successor);
	}

	@Override
	public void handleBug(Bug bug) {

		if (bug.getBugDifficulty() == BugDifficulty.Easy) {
			System.out.printf("Easy Bug. Handled by Junioer Developer %s - %n", 
					this.getName());
		} else {
			super.handleBug(bug);
		}
	}
}