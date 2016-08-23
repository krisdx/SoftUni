package behavioral.mementoPattern.models;

public class Memento {

	private String name;
	private String phone;
	private double budget;

	public Memento(String name, String phone, double budget) {
		this.name = name;
		this.phone = phone;
		this.budget = budget;
	}

	public String getName() {
		return this.name;
	}

	public String getPhone() {
		return this.phone;
	}

	public double getBudget() {
		return this.budget;
	}
}