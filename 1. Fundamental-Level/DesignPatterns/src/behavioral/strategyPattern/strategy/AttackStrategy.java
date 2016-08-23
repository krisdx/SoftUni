package behavioral.strategyPattern.strategy;

public class AttackStrategy extends AbstractStrategy implements BattleStrategy {

	private static final String ATTACK_STRATEGY_MESSAGE = "Attack!";

	public AttackStrategy() {
		super(ATTACK_STRATEGY_MESSAGE);
	}

	@Override
	public String toString() {
		return "Attacking Strategy";
	}
}