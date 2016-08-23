package behavioral.statePattern.models.state;

public class RedState extends AbstractState implements State {

	public RedState(State state) {
		super(state);
		this.initialize();
	}

	@Override
	protected void stateChangeCheck() {
		if (this.getBalance() > this.upperLimit) {
			this.getAccount().setState(new SilverState(this));
		}
	}

	private void initialize() {
		this.interest = 0.0;
		this.lowerLimit = -100.0;
		this.upperLimit = 0.0;
	}
}