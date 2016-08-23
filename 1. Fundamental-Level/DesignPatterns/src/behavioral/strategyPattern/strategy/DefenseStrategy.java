package behavioral.strategyPattern.strategy;

public class DefenseStrategy extends AbstractStrategy implements BattleStrategy {

	private static final String DEFENSE_STRATEGY_MESSAGE = "Defense!";
	
	public DefenseStrategy() {
		super(DEFENSE_STRATEGY_MESSAGE);
	}
	
	@Override
	public String toString() {
		return "Defense Strategy";
	}
}