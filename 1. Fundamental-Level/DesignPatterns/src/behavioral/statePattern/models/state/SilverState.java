package behavioral.statePattern.models.state;

import behavioral.statePattern.models.Account;

public class SilverState extends AbstractState implements State {

	public SilverState(double balance, Account account) {
		super(balance, account);
	}

	public SilverState(State state) {
		super(state);
		this.initialize();
	}

	@Override
	protected void stateChangeCheck() {
		if (this.getBalance() < this.lowerLimit) {
			this.getAccount().setState(new RedState(this));
		} else if (this.getBalance() > this.upperLimit) {
			this.getAccount().setState(new GoldState(this));
		}
	}

	private void initialize() {
		this.interest = 0.0;
		this.lowerLimit = 0.0;
		this.upperLimit = 1000.0;
	}
}