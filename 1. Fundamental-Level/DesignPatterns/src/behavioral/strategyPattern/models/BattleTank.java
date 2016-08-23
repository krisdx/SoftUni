package behavioral.strategyPattern.models;

import behavioral.strategyPattern.strategy.BattleStrategy;

public class BattleTank implements Tank {

	private String name;
	private BattleStrategy battleStrategy;

	public BattleTank(String name, BattleStrategy battleStrategy) {
		this.name = name;
		this.battleStrategy = battleStrategy;
	}

	@Override
	public BattleStrategy getBattleStrategy() {
		return this.battleStrategy;
	}

	@Override
	public String getName() {
		return this.name;
	}
	
	@Override
	public String battle() {	
		return String.format("The Strategy of tank %s is %s.%n%s",
			this.getName(),
			this.getBattleStrategy().toString(),
			this.getBattleStrategy().getBattleMessage());
	}
}