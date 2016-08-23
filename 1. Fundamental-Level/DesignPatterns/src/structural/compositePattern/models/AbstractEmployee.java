package structural.compositePattern.models;

import java.util.ArrayList;
import java.util.List;

public abstract class AbstractEmployee implements Employee {

	private String name;
	private List<Employee> subordinates;

	protected AbstractEmployee(String name) {
		this.name = name;
		this.subordinates = new ArrayList<>();
	}

	@Override
	public String getName() {
		return this.name;
	}

	@Override
	public void add(Employee subordinate) {
		this.subordinates.add(subordinate);
	}

	@Override
	public void remove(Employee subordinate) {
		this.subordinates.remove(subordinate);
	}

	@Override
	public void display(int indent) {
		System.out.printf("%s%s%n",newString('-', indent), this);

		for (Employee subordinate : this.subordinates) {
			subordinate.display(indent + 3);
		}
	}

	@Override
	public String toString() {
		return String.format("%s [%s]", this.name, 
				this.getClass().getSimpleName());
	}

	protected String newString(char ch, int count) {
		String str = "";
		for (int i = 0; i < count; i++) {
			str += Character.toString(ch);
		}

		return str;
	}
}