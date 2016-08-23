package structural.proxyPattern.models;

public interface BankAccount {

	boolean deposit(double amount);

	boolean withdraw(double amount);

	double getCurrentBallance();
}