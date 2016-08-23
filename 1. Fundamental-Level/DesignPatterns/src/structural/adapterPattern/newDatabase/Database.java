package structural.adapterPattern.newDatabase;

public interface Database {

	void add(String name);
	
	void remove(String name);
	
	void printNames();
}