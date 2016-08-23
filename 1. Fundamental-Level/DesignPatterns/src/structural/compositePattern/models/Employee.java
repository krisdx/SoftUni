package structural.compositePattern.models;

public interface Employee {

	String getName();

	void add(Employee subordinate);

	void remove(Employee subordinate);

	void display(int indent);
}