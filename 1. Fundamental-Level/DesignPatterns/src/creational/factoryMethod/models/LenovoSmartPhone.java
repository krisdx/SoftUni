package creational.factoryMethod.models;

public class LenovoSmartPhone extends AbstractSmartPhone implements SmartPhone {

	public LenovoSmartPhone(int batteryLife, int weight, int height, int width) {
		super(batteryLife, weight, height, width);
		this.setName("Lenovo");
	}

	@Override
	public void start() {
		System.out.println("Booting up... Lenovo");
		System.out.println("Welcome to your Lenovo");
	}
}