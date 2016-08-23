package creational.abstractFactory;

import creational.abstractFactory.factory.PizzaExtraordinaire;
import creational.abstractFactory.factory.PizzaFactory;
import creational.abstractFactory.models.Pizza;

public class Main {

	public static void main(String[] args) {

		/**
		 * Abstract Factory pattern defines an interface for creating sets of
		 * linked objects. Provides a flexible mechanism for replacement of
		 * different sets.
		 */

		PizzaFactory pizzaPlace = new PizzaExtraordinaire();
		OnlineDeliveryCompany yamYam = new OnlineDeliveryCompany(pizzaPlace);

		Pizza cheesePizza = yamYam.deliverCheesePizza();

		System.out.println(cheesePizza.getName());
		System.out.println("Ingridients: ");
		for (String ingridient : cheesePizza.getIngridients()) {
			System.out.println(ingridient);
		}
	}
}