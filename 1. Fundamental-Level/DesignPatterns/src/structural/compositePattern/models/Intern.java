package structural.compositePattern.models;

public class Intern extends AbstractEmployee implements Employee {

	public Intern(String name) {
		super(name);
	}

	@Override
	public void add(Employee subordinate) {
		System.out.printf("%s cannot have subordinates%n", 
				this.getClass().getSimpleName());
	}

	@Override
	public void remove(Employee subordinate) {
		System.out.printf("%s does not have subordinates%n", 
				this.getClass().getSimpleName());
	}

	@Override
	public void display(int indent) {
		System.out.printf("%s%s%n", newString('-', indent), this);
	}
}