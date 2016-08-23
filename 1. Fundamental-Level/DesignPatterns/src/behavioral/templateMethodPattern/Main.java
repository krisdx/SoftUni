package behavioral.templateMethodPattern;

import behavioral.templateMethodPattern.models.Coffee;
import behavioral.templateMethodPattern.models.HotDrink;

public class Main {

	public static void main(String[] args) {

		/**
		 * Template Method pattern defines the skeleton of an algorithm in an
		 * operation, deferring some steps to client subclasses. Template Method
		 * lets subclasses redefine certain steps of an algorithm without
		 * changing the algorithm's structure.
		 */

		System.out.println("Making coffee: ");
		HotDrink coffee = new Coffee();
	}
}