package behavioral.templateMethodPattern.models;

public abstract class AbstractHotDrink implements HotDrink {

	protected AbstractHotDrink() {
		this.boilWater();
		this.brew();
		this.pourInCup();
		this.addSpices();
	}

	@Override
	public void boilWater() {
		System.out.println("Boiling the water...");
	}

	@Override
	public void pourInCup() {
		System.out.println("Pouring in cup...");
	}
}