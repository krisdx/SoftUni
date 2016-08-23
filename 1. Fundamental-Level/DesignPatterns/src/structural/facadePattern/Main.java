package structural.facadePattern;

import structural.facadePattern.atm.Atm;
import structural.facadePattern.atm.AtmImpl;

public class Main {

	public static void main(String[] args) {

		/**
		 * Facade Pattern hides complex logic with many classes, and shows it in
		 * a simple way.
		 */

		Atm atm = new AtmImpl();

		atm.draw(100, 123);

		atm.draw(100, 1234);
		atm.draw(500, 1234);

		atm.draw(600, 1234);
		atm.draw(400, 1234);
	}

}