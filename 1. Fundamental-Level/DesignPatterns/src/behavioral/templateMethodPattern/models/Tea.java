package behavioral.templateMethodPattern.models;

public class Tea extends AbstractHotDrink implements HotDrink {

	@Override
	public void brew() {
		System.out.println("Brew for 10 minutes...");
	}

	@Override
	public void addSpices() {
		System.out.println("Adding sugar...");
	}
}