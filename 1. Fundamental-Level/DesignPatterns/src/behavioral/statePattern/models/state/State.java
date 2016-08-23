package behavioral.statePattern.models.state;

import behavioral.statePattern.models.Account;

public interface State {
	double getBalance();
	
	Account getAccount();
	
	void deposit(double amount);

	void withdraw(double amount);

	void payInterest();
}