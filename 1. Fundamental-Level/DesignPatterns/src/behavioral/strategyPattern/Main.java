package behavioral.strategyPattern;

import behavioral.strategyPattern.models.*;
import behavioral.strategyPattern.strategy.AttackStrategy;
import behavioral.strategyPattern.strategy.DefenseStrategy;

public class Main {

	public static void main(String[] args) {

		/**
		 * Strategy pattern allows the client to use which strategy to use.
		 * Encapsulating an algorithm inside a class, making each algorithm
		 * replaceable by others and the client can work with each algorithm
		 * transparently.
		 */

		Tank attackTank = new BattleTank("Pesho", new AttackStrategy());
		Tank defenseTank = new BattleTank("Gosho", new DefenseStrategy());

		System.out.println(attackTank.battle());
		System.out.println(defenseTank.battle());
	}
}