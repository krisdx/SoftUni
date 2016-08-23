package behavioral.interpreterPattern.models.expression;

public class TenExpression extends Expression {

	@Override
	public String one() {
		return "X";
	}

	@Override
	public String four() {
		return "XL";
	}

	@Override
	public String five() {
		return "L";
	}

	@Override
	public String nine() {
		return "XC";
	}

	@Override
	public int getMultiplier() {
		return 10;
	}
}