package creational.factoryMethod.factory;

import creational.factoryMethod.models.LenovoSmartPhone;
import creational.factoryMethod.models.SmartPhone;

public class LenovoManufacturer implements Manufacturer {

	@Override
	public SmartPhone manufactureSmartPhone() {
		return new LenovoSmartPhone(20, 1, 2, 3);
	}

}