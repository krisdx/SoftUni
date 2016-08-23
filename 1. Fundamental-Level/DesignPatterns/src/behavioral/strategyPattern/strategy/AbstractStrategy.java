package behavioral.strategyPattern.strategy;

public abstract class AbstractStrategy implements BattleStrategy {
	
	private String strategyMessage;
	
	protected AbstractStrategy(String strategyMessage) {
		this.strategyMessage = strategyMessage;
	}

	@Override
	public String getBattleMessage() {
		return this.strategyMessage;
	}
}