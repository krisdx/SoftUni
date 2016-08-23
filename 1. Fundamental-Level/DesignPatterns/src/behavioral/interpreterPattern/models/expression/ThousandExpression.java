package behavioral.interpreterPattern.models.expression;

public class ThousandExpression extends Expression {

	@Override
	public String one() {
		return "M";
	}

	@Override
	public String four() {
		return " ";
	}

	@Override
	public String five() {
		return " ";
	}

	@Override
	public String nine() {
		return " ";
	}

	@Override
	public int getMultiplier() {
		return 1000;
	}
}