package creational.factoryMethod.models;

public abstract class AbstractSmartPhone implements SmartPhone {

	private int batteryLife;
	private int weight;
	private int height;
	private int width;
	private String name;

	protected AbstractSmartPhone(int batteryLife, int weight, int height, int width) {
		this.batteryLife = batteryLife;
		this.weight = weight;
		this.height = height;
		this.width = width;
	}

	@Override
	public int getBatteryLife() {
		return this.batteryLife;
	}

	@Override
	public int getWeight() {
		return this.weight;
	}

	@Override
	public int getHeight() {
		return this.height;
	}

	@Override
	public int getWidth() {
		return this.width;
	}

	@Override
	public String getName() {
		return this.name;
	}

	protected void setName(String name) {
		this.name = name;
	}

	@Override
	public String toString() {
		return this.getClass().getSimpleName() + ", " + this.getName();
	}
}