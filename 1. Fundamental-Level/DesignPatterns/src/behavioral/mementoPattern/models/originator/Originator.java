package behavioral.mementoPattern.models.originator;

import behavioral.mementoPattern.models.Memento;

public interface Originator {
	Memento saveMemento();
	
	void restore(Memento memento);
}