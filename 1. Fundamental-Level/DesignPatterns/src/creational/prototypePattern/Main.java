package creational.prototypePattern;

public class Main {

	public static void main(String[] args) {

		/**
		 * Prototype pattern is a factory for cloning new instances from a
		 * prototype. Create new objects by copying this prototype. Instead of *
		 * using the new keyword.
		 */

		Car car = new Car("BMW", "316i", 95);
		Car clonedCar = car.getCopy();
		clonedCar.setHorsePower(100);

		System.out.println("The car's hourse power: " + car.getHorsePower());
		System.out.println("The cloned car's hourse power: " + clonedCar.getHorsePower());
	}
}