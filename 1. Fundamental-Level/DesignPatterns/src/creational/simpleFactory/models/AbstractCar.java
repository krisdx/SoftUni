package creational.simpleFactory.models;

public abstract class AbstractCar implements Car {

	private String model;

	public AbstractCar(String model) {
		this.model = model;
	}
	
	@Override
	public String getModel() {
		return this.model;
	}
	
	@Override
	public String toString() {
		return this.model;
	}
}