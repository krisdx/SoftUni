package behavioral.statePattern.models.state;

import behavioral.statePattern.models.Account;

public abstract class AbstractState implements State {

	private Account account;
	private double balance;

	protected double interest;
	protected double lowerLimit;
	protected double upperLimit;

	protected AbstractState(State state) {
		this(state.getBalance(), state.getAccount());
	}

	protected AbstractState(double balance, Account account) {
		this.balance = balance;
		this.account = account;
	}

	@Override
	public double getBalance() {
		return this.balance;
	}

	@Override
	public Account getAccount() {
		return this.account;
	}

	@Override
	public void deposit(double amount) {
		this.balance += amount;
		this.stateChangeCheck();
	}

	@Override
	public void withdraw(double amount) {
		this.balance -= amount;
		this.stateChangeCheck();
	}

	@Override
	public void payInterest() {
		this.balance += this.interest * this.getBalance();
		this.stateChangeCheck();
	}

	protected abstract void stateChangeCheck();
}