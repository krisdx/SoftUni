package creational.simpleFactory.factory;

import creational.simpleFactory.models.Car;

public interface CarFactory {
	Car createCar(String carType, String carModel);
}