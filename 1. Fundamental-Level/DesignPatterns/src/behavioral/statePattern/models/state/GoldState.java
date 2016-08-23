package behavioral.statePattern.models.state;

public class GoldState extends AbstractState implements State {

	public GoldState(State state) {
		super(state);
		this.initialize();
	}

	@Override
	protected void stateChangeCheck() {
		if (this.getBalance() < 0.0) {
			this.getAccount().setState(new RedState(this));
		} else if (this.getBalance() < this.lowerLimit) {
			this.getAccount().setState(new SilverState(this));
		}
	}

	private void initialize() {
		this.interest = 0.05;
		this.lowerLimit = 1000.0;
		this.upperLimit = 10000000.0;
	}
}