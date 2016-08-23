package creational.factoryMethod.models;

public class AppleSmartPhone extends AbstractSmartPhone implements SmartPhone {

	public AppleSmartPhone(int batteryLife, int weight, int height, int width) {
		super(batteryLife, weight, height, width);
		this.setName("iPhone 6S");
	}

	@Override
	public void start() {
		System.out.println("Starting up the Apple...");
		System.out.println("Thrusters on full!");
	}
}