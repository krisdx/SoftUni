package creational.abstractFactory;

import creational.abstractFactory.factory.PizzaFactory;
import creational.abstractFactory.models.Calzone;
import creational.abstractFactory.models.CheesePizza;
import creational.abstractFactory.models.PepperoniPizza;

public class OnlineDeliveryCompany {

	private PizzaFactory factory;

	public OnlineDeliveryCompany(PizzaFactory pizzaFactory) {
		this.factory = pizzaFactory;
	}

	public CheesePizza deliverCheesePizza() {
		return factory.makeCheesePizza();
	}

	public Calzone deliverCalzone() {
		return factory.makeCalzone();
	}

	public PepperoniPizza deliverPepperoniPizza() {
		return factory.makePepperoniPizza();
	}
}