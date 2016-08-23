package behavioral.commandPattern.command;

public class SubtractCommand implements Calculable {

	@Override
	public double calculate(double firstOperand, double secondOperand) {
		return firstOperand - secondOperand;
	}

}