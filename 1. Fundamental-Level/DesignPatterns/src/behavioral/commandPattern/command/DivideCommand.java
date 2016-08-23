package behavioral.commandPattern.command;

public class DivideCommand implements Calculable {

	@Override
	public double calculate(double dividend, double divisor) {
		return dividend / divisor;
	}

}