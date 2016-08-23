package behavioral.strategyPattern.models;

import behavioral.strategyPattern.strategy.BattleStrategy;

public interface Tank {
	
	String getName();
	
	BattleStrategy getBattleStrategy();
	
	String battle();
}