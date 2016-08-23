package behavioral.commandPattern.command;

public class AddCommand implements Calculable {

	@Override
	public double calculate(double firstOperand, double secondOperand) {
		return firstOperand + secondOperand;
	}

}