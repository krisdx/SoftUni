package creational.factoryMethod;

import creational.factoryMethod.factory.AppleManufacturer;
import creational.factoryMethod.factory.LenovoManufacturer;
import creational.factoryMethod.factory.Manufacturer;
import creational.factoryMethod.models.SmartPhone;

public class Main {

	public static void main(String[] args) {

		/**
		 * Factory method pattern produces objects as normal Factory, but
		 * objects are created by a separate method. This allows achieving
		 * higher reusability and flexibility in the changing applications.
		 */

		Manufacturer appleManufacturer = new AppleManufacturer();
		Manufacturer lenovoManufacturer = new LenovoManufacturer();

		SmartPhone lenovoSmartPhone = lenovoManufacturer.manufactureSmartPhone();
		SmartPhone appleSmartPhone = appleManufacturer.manufactureSmartPhone();

		System.out.println(lenovoSmartPhone);
		lenovoSmartPhone.start();

		System.out.println();

		System.out.println(appleSmartPhone);
		appleSmartPhone.start();
	}
}