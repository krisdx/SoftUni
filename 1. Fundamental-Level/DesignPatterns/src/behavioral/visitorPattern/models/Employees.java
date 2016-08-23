package behavioral.visitorPattern.models;

import java.util.ArrayList;
import java.util.List;

import behavioral.visitorPattern.models.element.Employee;
import behavioral.visitorPattern.models.visitor.Visitor;

public class Employees {

	private List<Employee> employees;

	public Employees() {
		this.employees = new ArrayList<>();
	}

	public void attach(Employee employee) {
		this.employees.add(employee);
	}

	public void detach(Employee employee) {
		this.employees.remove(employee);
	}

	public void accept(Visitor visitor) {
		for (Employee employee : this.employees) {
			employee.accept(visitor);
		}

		System.out.println();
	}
}