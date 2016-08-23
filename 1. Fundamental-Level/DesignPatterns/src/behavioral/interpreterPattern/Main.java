package behavioral.interpreterPattern;

import java.util.ArrayList;
import java.util.List;

import behavioral.interpreterPattern.models.Context;
import behavioral.interpreterPattern.models.expression.Expression;
import behavioral.interpreterPattern.models.expression.HundredExpression;
import behavioral.interpreterPattern.models.expression.OneExpression;
import behavioral.interpreterPattern.models.expression.TenExpression;
import behavioral.interpreterPattern.models.expression.ThousandExpression;

public class Main {

	public static void main(String[] args) {

		/**
		 * Interpreter pattern is a way to include language (formal grammar)
		 * elements in a program. Defines a representation for the grammar.
		 * Defines an interpreter that uses the representation to interpret
		 * sentences in the language.
		 */

		String input = "MCMXXVIII";
		Context context = new Context(input);

		// Build the 'parse tree'
		List<Expression> tree = new ArrayList<>();
		tree.add(new ThousandExpression());
		tree.add(new HundredExpression());
		tree.add(new TenExpression());
		tree.add(new OneExpression());

		// Interpret
		System.out.printf("Current context: Input=%s Output=%s%n", 
				context.getInput(), context.getOutput());
		for (Expression expression : tree) {
			expression.interpret(context);
			System.out.printf("Current context: Input=%s Output=%s",
					context.getInput(), context.getOutput());
		}

		System.out.println();
		System.out.printf("Final: %s = %s", input, context.getOutput());
	}
}