package behavioral.visitorPattern.models.element;

public interface Employee extends Element {
	String getName();

	void setName(String name);
	
	double getIncome();

	void setIncome(double income);	
	
	int getVacationDays();

	void setVacationDays(int vacationDays);
}