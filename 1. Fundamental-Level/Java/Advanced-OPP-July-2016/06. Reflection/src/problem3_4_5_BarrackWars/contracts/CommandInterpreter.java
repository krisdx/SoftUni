package problem3_4_5_BarrackWars.contracts;

public interface CommandInterpreter {
	Executable interpretCommand(String[] data, String commandName);
}