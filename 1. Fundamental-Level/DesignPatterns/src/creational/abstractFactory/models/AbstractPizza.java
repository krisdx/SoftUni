package creational.abstractFactory.models;

import java.util.List;

public abstract class AbstractPizza implements Pizza {

	private String name;
	private List<String> ingridients;
	private String madeBy;

	protected AbstractPizza(List<String> ingridients, String madeBy) {
		this.ingridients = ingridients;
		this.madeBy = madeBy;
		this.setName("Calzone made by " + this.madeBy);
	}

	@Override
	public String getName() {
		return this.name;
	}

	protected void setName(String name) {
		this.name = name;
	}

	@Override
	public List<String> getIngridients() {
		return this.ingridients;
	}
}