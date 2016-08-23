package creational.abstractFactory.factory;

import java.util.ArrayList;
import java.util.List;

import creational.abstractFactory.models.Calzone;
import creational.abstractFactory.models.CheesePizza;
import creational.abstractFactory.models.PepperoniPizza;
import creational.abstractFactory.models.Pizza;

public class AlfreddosPlace implements PizzaFactory {

	private static final String NAME = "Alfreddo's Pizza Palace";

	@Override
	public CheesePizza makeCheesePizza() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("tomatoes");
		ingridients.add("white cheese");
		ingridients.add("yellow cheese");
		ingridients.add("blue cheese");
		ingridients.add("extra smelly cheese");

		CheesePizza pizza = new CheesePizza(ingridients, NAME);
		return pizza;
	}

	@Override
	public Calzone makeCalzone() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("tomatoes");
		ingridients.add("ham");
		ingridients.add("bacon");

		Calzone pizza = new Calzone(ingridients, NAME);
		return pizza;
	}

	@Override
	public PepperoniPizza makePepperoniPizza() {
		List<String> ingridients = new ArrayList<>();
		ingridients.add("tomatoes");
		ingridients.add("pepperoni");
		ingridients.add("salami");

		PepperoniPizza pizza = new PepperoniPizza(ingridients, NAME);
		return pizza;
	}
}