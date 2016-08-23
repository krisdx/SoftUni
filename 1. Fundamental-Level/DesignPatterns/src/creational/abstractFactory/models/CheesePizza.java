package creational.abstractFactory.models;

import java.util.List;

public class CheesePizza extends AbstractPizza implements Pizza {

	public CheesePizza(List<String> ingridients, String madeBy) {
		super(ingridients, madeBy);
	}
}