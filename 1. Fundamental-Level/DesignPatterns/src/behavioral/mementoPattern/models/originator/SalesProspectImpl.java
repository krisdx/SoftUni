package behavioral.mementoPattern.models.originator;

import behavioral.mementoPattern.models.Memento;

public class SalesProspectImpl implements SalesProspect, Originator {

	private String name;
	private String phone;
	private double budget;

	public SalesProspectImpl(String name, String phone, double budget) {
		this.name = name;
		this.phone = phone;
		this.budget = budget;
	}

	@Override
	public Memento saveMemento() {
		return new Memento(this.getName(), this.getPhone(), this.getBudget());
	}

	@Override
	public void restore(Memento memento) {
		this.name = memento.getName();
		this.phone = memento.getPhone();
		this.budget = memento.getBudget();
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
	public String getPhone() {
		return this.phone;
	}

	@Override
	public void setPhone(String phone) {
		this.phone = phone;
	}

	@Override
	public double getBudget() {
		return this.budget;
	}

	@Override
	public void setBudget(double budget) {
		this.budget = budget;
	}

	@Override
	public String toString() {
		return String.format("Name: %s%nPhone: %s%nBudget: %s%n", 
				this.getName(), this.getPhone(),
				this.getBudget());
	}
}