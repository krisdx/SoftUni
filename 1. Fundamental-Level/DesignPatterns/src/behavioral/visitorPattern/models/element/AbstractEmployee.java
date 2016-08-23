package behavioral.visitorPattern.models.element;

import behavioral.visitorPattern.models.visitor.Visitor;

public abstract class AbstractEmployee implements Employee {

	private String name;
	private double income;
	private int vacationDays;

	protected AbstractEmployee(String name, double income, int vacationDays) {
		this.setName(name);
		this.setIncome(income);
		this.setVacationDays(vacationDays);
	}

	@Override
	public String getName() {
		return this.name;
	}

	@Override
	public void setName(String name) {
		this.name = name;
	}

	@Override
	public double getIncome() {
		return this.income;
	}

	@Override
	public void setIncome(double income) {
		this.income = income;
	}

	@Override
	public int getVacationDays() {
		return this.vacationDays;
	}

	@Override
	public void setVacationDays(int vacationDays) {
		this.vacationDays = vacationDays;
	}

	@Override
	public void accept(Visitor visitor) {
		visitor.visit(this);
	}
}
