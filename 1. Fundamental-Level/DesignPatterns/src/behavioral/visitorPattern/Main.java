package behavioral.visitorPattern;

import behavioral.visitorPattern.models.Employees;
import behavioral.visitorPattern.models.element.Clerk;
import behavioral.visitorPattern.models.element.Director;
import behavioral.visitorPattern.models.element.Employee;
import behavioral.visitorPattern.models.element.President;
import behavioral.visitorPattern.models.visitor.IncomeVisitor;
import behavioral.visitorPattern.models.visitor.VacationVisitor;

public class Main {

	public static void main(String[] args) {

		/**
		 * Visitor pattern lets you define a new operation without changing the
		 * classes of the elements.
		 */
		
		  Employees employees = new Employees();
          employees.attach(new Clerk());
          employees.attach(new Director());
          employees.attach(new President());

          // Employees are 'visited'
          employees.accept(new IncomeVisitor());
          employees.accept(new VacationVisitor());
	}
}