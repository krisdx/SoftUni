package structural.proxyPattern;

import structural.proxyPattern.models.BankAccount;
import structural.proxyPattern.models.BankAccountProxy;

public class Main {

	public static void main(String[] args) {

		/**
		 * An object representing another object. Provide a surrogate or
		 * placeholder for another object to control access to it. Uses an extra
		 * level of indirection to support distributed, controlled, or
		 * intelligent access. Add a wrapper and delegation to protect the real
		 * component from undue complexity.
		 */

		BankAccount bankAccount = new BankAccountProxy("fake", "proxy");

		System.out.println(bankAccount.getCurrentBallance());

		deposit(25, bankAccount);

		withdraw(250, bankAccount);

		deposit(700, bankAccount);

		System.out.println(bankAccount.getCurrentBallance());
	}

	private static void withdraw(double amount, BankAccount account) {
		if (account.withdraw(amount)) {
			System.out.println("Withdrawal complete:" + amount);
		}
	}

	private static void deposit(double amount, BankAccount account) {
		if (account.deposit(amount)) {
			System.out.println("Deposit complete: " + amount);
		}
	}
}