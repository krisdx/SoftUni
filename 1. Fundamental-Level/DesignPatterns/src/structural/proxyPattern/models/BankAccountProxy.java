package structural.proxyPattern.models;

public class BankAccountProxy implements BankAccount {

	private BankAccount realAccount;
	private boolean userIsAuthorized;

	public BankAccountProxy(String userName, String secretKey) {
		// Validate if the user is logged in, if he is legit, if he has rights
		// to see this information and so on...
		if (true) {
			this.userIsAuthorized = true;
		}
	}

	@Override
	public boolean deposit(double amount) {
		if (amount < 25) {
			System.out.println("Minimum deposit amount is 25!");
			return false;
		}

		if (amount > 1000) {
			System.out.println("Maximum deposit amount is 1000!");
			return false;
		}

		if (!this.userIsAuthorized) {
			System.out.println("You are not authorized!");
			System.out.println("Redirecting you to login screen...");
			return false;
		}

		this.checkIfAccountIsActive();

		this.realAccount.deposit(amount);
		return true;
	}

	@Override
	public boolean withdraw(double amount) {
		this.checkIfAccountIsActive();

		this.realAccount.withdraw(amount);
		return true;
	}

	@Override
	public double getCurrentBallance() {
        this.checkIfAccountIsActive();
        return realAccount.getCurrentBallance();
	}

	private void checkIfAccountIsActive() {
		if (this.realAccount == null) {
			this.realAccount = new BankAccountImpl();
		}
	}
}