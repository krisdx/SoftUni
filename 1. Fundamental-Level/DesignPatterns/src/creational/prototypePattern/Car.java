package creational.prototypePattern;

public class Car implements Cloneable {

	private String name;
	private String model;
	private int horsePower;

	public Car(String name, String model, int horsePower) {
		this.name = name;
		this.model = model;
		this.horsePower = horsePower;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getModel() {
		return this.model;
	}

	public void setModel(String model) {
		this.model = model;
	}

	public int getHorsePower() {
		return this.horsePower;
	}

	public void setHorsePower(int horsePower) {
		this.horsePower = horsePower;
	}

	public Car getCopy() {

		try {
			return (Car) super.clone();
		} catch (CloneNotSupportedException ex) {
			ex.printStackTrace();
		}

		return null;
	}
}