package creational.simpleFactory;

import creational.simpleFactory.factory.CarFactory;
import creational.simpleFactory.factory.CarFactoryImpl;
import creational.simpleFactory.models.Car;

public class Main {

	public static void main(String[] args) {

		/**
		 * Simple factory is not a pattern. It creates (returns) one of many
		 * classes directly.
		 */

		CarFactory carFactory = new CarFactoryImpl();

		Car poorCar = carFactory.createCar("Poor", "B");
		Car luxuryCar = carFactory.createCar("Luxury", "S");

		System.out.println(poorCar);
		System.out.println(luxuryCar);

		Car unsupportedCar = carFactory.createCar("Test", "A");
	}
}