package creational.abstractFactory.models;

import java.util.List;

public class PepperoniPizza extends AbstractPizza implements Pizza {

	public PepperoniPizza(List<String> ingridients, String madeBy) {
		super(ingridients, madeBy);
	}
}