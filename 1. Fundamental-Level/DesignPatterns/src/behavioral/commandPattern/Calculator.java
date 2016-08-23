package behavioral.commandPattern;

import java.util.HashMap;
import java.util.Map;

import behavioral.commandPattern.command.Calculable;

public class Calculator {

	public static final char ADD = '+';
	public static final char SUBTRACT = '-';
	public static final char MULTIPLY = '*';
	public static final char DIVIDE = '/';

	private static final String CALCULATION_COMMNADS_PACKAGE = Calculable.class.getPackage().getName();

	private static final String COMMANDS_SUFFIX = "Command";

	private Map<Character, String> actionNames;

	public Calculator() {
		this.initActionNames();
	}

	@SuppressWarnings("unchecked")
	public double calculate(double firstOperand, double secondOperand, char opration)
			throws ReflectiveOperationException {
		String packagePath = CALCULATION_COMMNADS_PACKAGE;
		String totalPath = packagePath + "." + this.actionNames.get(opration) + COMMANDS_SUFFIX;
		Class<Calculable> commandClass = (Class<Calculable>) Class.forName(totalPath);

		Calculable action = commandClass.newInstance();
		return action.calculate(firstOperand, secondOperand);
	}

	private void initActionNames() {
		this.actionNames = new HashMap<>();

		this.actionNames.put(ADD, "Add");
		this.actionNames.put(SUBTRACT, "Subtract");
		this.actionNames.put(MULTIPLY, "Multiply");
		this.actionNames.put(DIVIDE, "Divide");
	}
}