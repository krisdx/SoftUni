package creational.abstractFactory.factory;

import creational.abstractFactory.models.Calzone;
import creational.abstractFactory.models.CheesePizza;
import creational.abstractFactory.models.PepperoniPizza;

public interface PizzaFactory {
	CheesePizza makeCheesePizza();

	Calzone makeCalzone();

	PepperoniPizza makePepperoniPizza();
}