package structural.proxyPattern.models;

public class BankAccountImpl implements BankAccount {

	private double ballance;

	public BankAccountImpl() {
		this.ballance = 1000;
	}

	@Override
	public boolean deposit(double amount) {
		this.ballance += amount;
		return true;
	}

	@Override
	public boolean withdraw(double amount) {
		this.ballance -= amount;
		return true;
	}

	@Override
	public double getCurrentBallance() {
		return this.ballance;
	}
}