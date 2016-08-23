package creational.simpleFactory.factory;

import java.lang.reflect.Constructor;

import creational.simpleFactory.models.Car;

public class CarFactoryImpl implements CarFactory {

	private static final String CARS_PACKAGE = 
			Car.class.getPackage().getName();

	private static final String CARS_SUFFIX = "Car";

	@Override
	@SuppressWarnings("unchecked")
	public Car createCar(String carType, String carModel) {
		String filePath = CARS_PACKAGE + "." + carType + CARS_SUFFIX;
		try {

			Class<Car> carClass = (Class<Car>) Class.forName(filePath);

			Constructor<Car> consructor = carClass.getDeclaredConstructor(String.class);
			Car car = (Car) consructor.newInstance(carModel);
			return car;

		} catch (ClassNotFoundException ex) {
			System.out.println("The type " + carType + " is not supported.");
		} catch (ReflectiveOperationException ex) {
			ex.printStackTrace();
		}

		return null;
	}
}