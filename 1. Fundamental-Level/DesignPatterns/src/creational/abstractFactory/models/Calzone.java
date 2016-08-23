package creational.abstractFactory.models;

import java.util.List;

public class Calzone extends AbstractPizza implements Pizza {

	public Calzone(List<String> ingridients, String madeBy) {
		super(ingridients, madeBy);
	}
}