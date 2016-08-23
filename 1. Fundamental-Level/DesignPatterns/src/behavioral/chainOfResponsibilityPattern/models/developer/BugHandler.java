package behavioral.chainOfResponsibilityPattern.models.developer;

import behavioral.chainOfResponsibilityPattern.models.bug.Bug;

public interface BugHandler {
	void handleBug(Bug bug);

	Developer getSuccessor();
	
	void setSuccessor(Developer successor);
}