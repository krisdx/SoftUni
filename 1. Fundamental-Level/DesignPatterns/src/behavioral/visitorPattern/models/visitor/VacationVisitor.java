package behavioral.visitorPattern.models.visitor;

import behavioral.visitorPattern.models.element.Element;
import behavioral.visitorPattern.models.element.Employee;

public class VacationVisitor implements Visitor {

	@Override
	public void visit(Element element) {	
		Employee employee = (Employee) element;
		if (employee != null) {

			// Provide 3 extra vacation days
			employee.setVacationDays(employee.getVacationDays() + 3);
			System.out.printf("%s %s's new vacation days: %d%n", 
					employee.getClass().getSimpleName(),
					employee.getName(), 
					employee.getVacationDays());
		}
	}
}