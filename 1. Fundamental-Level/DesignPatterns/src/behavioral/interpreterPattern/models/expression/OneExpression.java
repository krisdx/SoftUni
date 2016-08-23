package behavioral.interpreterPattern.models.expression;

public class OneExpression extends Expression {

	@Override
	public String one() {
		return "I";
	}

	@Override
	public String four() {
		return "IV";
	}

	@Override
	public String five() {
		return "V";
	}

	@Override
	public String nine() {
		return "IX";
	}

	@Override
	public int getMultiplier() {
		return 1;
	}
}