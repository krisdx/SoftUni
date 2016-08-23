package behavioral.statePattern.models;

import behavioral.statePattern.models.state.SilverState;
import behavioral.statePattern.models.state.State;

public class Account {

	private String owner;
	private State state;

	public Account(String owner) {
		this.owner = owner;
		// New accounts are 'Silver' by default
		this.state = new SilverState(0.0, this);
	}

	public void setState(State state) {
		this.state = state;
	}

	public void deposit(double amount) {
		this.state.deposit(amount);
		System.out.printf("Deposited %.2f --- %n", amount);
		System.out.printf(" Balance = %.2f%n", this.state.getBalance());
		System.out.println(" Status  = " + this.state.getClass().getSimpleName());
		System.out.println();
	}

	public void withdraw(double amount) {
		this.state.withdraw(amount);
		System.out.printf("Withdrew %.2f --- ", amount);
		System.out.printf(" Balance = %.2f", this.state.getBalance());
		System.out.printf(" Status  = %s%n", this.state.getClass().getSimpleName());
	}

	public void payInterest() {
		this.state.payInterest();
		System.out.println("Interest Paid --- ");
		System.out.printf(" Balance = %.2f", this.state.getBalance());
		System.out.printf(" Status  = %s%n", this.state.getClass().getSimpleName());
	}
}