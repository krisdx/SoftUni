package behavioral.commandPattern;

public class Main {

	public static void main(String[] args) throws ReflectiveOperationException {

		/**
		 * Command pattern - An object encapsulates all the information needed
		 * to call a method at a later time. Letting you parameterize clients
		 * with different requests, queue or log requests.
		 */

		Calculator calculator = new Calculator();

		System.out.println(calculator.calculate(1, 2, Calculator.ADD));
		System.out.println(calculator.calculate(20, 2, Calculator.DIVIDE));
		System.out.println(calculator.calculate(1, 2, Calculator.MULTIPLY));
		System.out.println(calculator.calculate(13, 5, Calculator.SUBTRACT));
	}
}