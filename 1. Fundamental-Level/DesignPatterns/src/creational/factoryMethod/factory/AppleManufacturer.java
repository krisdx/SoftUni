package creational.factoryMethod.factory;

import creational.factoryMethod.models.AppleSmartPhone;
import creational.factoryMethod.models.SmartPhone;

public class AppleManufacturer implements Manufacturer {

	@Override
	public SmartPhone manufactureSmartPhone() {
		return new AppleSmartPhone(1, 2, 3, 4);
	}
}