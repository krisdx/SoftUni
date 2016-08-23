package behavioral.chainOfResponsibilityPattern.models.bug;

public class BugImpl implements Bug {

	private BugDifficulty bugDifficulty;
	
	public BugImpl(BugDifficulty bugDifficulty) {
		this.bugDifficulty = bugDifficulty;
	}
	
	@Override
	public BugDifficulty getBugDifficulty() {
		return this.bugDifficulty;
	}
}