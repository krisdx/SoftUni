package behavioral.visitorPattern.models.element;

public class President extends AbstractEmployee implements Employee {

	public President() {
		super("Dick", 45000.0, 21);
	}
}