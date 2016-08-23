package structural.decoratorPattern.models;

public interface LibraryItem {

	String getTitle();
	
	int getCopiesCount();
	
	void setCopiesCount(int copiesCount);
	
	void display();
}