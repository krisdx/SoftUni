package creational.abstractFactory.factory;

import java.util.ArrayList;
import java.util.List;

import creational.abstractFactory.models.Calzone;
import creational.abstractFactory.models.CheesePizza;
import creational.abstractFactory.models.PepperoniPizza;

public class PizzaExtraordinaire implements PizzaFactory {

	private static final String NAME = "Pizza Extraordinaire";

	@Override
	public CheesePizza makeCheesePizza() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("rotten tomatoes");
		ingridients.add("grey cheese");
		ingridients.add("green cheese");

		CheesePizza pizza = new CheesePizza(ingridients, NAME);
		return pizza;
	}

	@Override
	public Calzone makeCalzone() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("rotten tomatoes");
		ingridients.add("greasy ham");

		Calzone pizza = new Calzone(ingridients, NAME);
		return pizza;
	}

	@Override
	public PepperoniPizza makePepperoniPizza() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("old salami");
		ingridients.add("green tomatoes");

		PepperoniPizza pizza = new PepperoniPizza(ingridients, NAME);
		return pizza;
	}
}