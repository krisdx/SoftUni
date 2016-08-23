package behavioral.templateMethodPattern.models;

public class Coffee extends AbstractHotDrink implements HotDrink {

	@Override
	public void brew() {
		System.out.println("Brew for 5 minutes...");
	}

	@Override
	public void addSpices() {
		System.out.println("Adding sour cream...");
	}
}