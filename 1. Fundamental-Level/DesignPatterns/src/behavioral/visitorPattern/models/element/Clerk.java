package behavioral.visitorPattern.models.element;

public class Clerk extends AbstractEmployee implements Employee {

	public Clerk() {
		super("Hank", 25000.0, 14);
	}
}