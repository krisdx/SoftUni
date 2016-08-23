package behavioral.statePattern;

import behavioral.statePattern.models.Account;

public class Main {

	public static void main(String[] args) {

		/**
		 * State Pattern alters an object's behavior when its state changes.
		 * Encapsulate the logic of each state into an object. Allow dynamic
		 * state discovery.
		 */

		Account account = new Account("Jim Johnson");

		account.deposit(500.0);
		account.deposit(300.0);
		account.deposit(550.0);
		account.payInterest();
		account.withdraw(2000.00);
		account.withdraw(1100.00);
	}
}