package behavioral.chainOfResponsibilityPattern.models.developer;

import behavioral.chainOfResponsibilityPattern.models.bug.Bug;

public abstract class AbstractDeveloper implements Developer {

	private String name;
	private Developer successor;

	protected AbstractDeveloper(String name, Developer successor) {
		this.name = name;
		this.setSuccessor(successor);
	}

	@Override
	public String getName() {
		return this.name;
	}

	@Override
	public Developer getSuccessor() {
		return this.successor;
	}

	@Override
	public void setSuccessor(Developer successor) {
		this.successor = successor;
	}

	@Override
	public void handleBug(Bug bug) {
		if (this.getSuccessor() != null) {
			this.getSuccessor().handleBug(bug);
		} else {
			System.out.println("The bug cannot be handled.");
		}
	}
}