package problem3_4_5_BarrackWars;

import problem3_4_5_BarrackWars.contracts.CommandInterpreter;
import problem3_4_5_BarrackWars.contracts.Repository;
import problem3_4_5_BarrackWars.contracts.Runnable;
import problem3_4_5_BarrackWars.contracts.UnitFactory;
import problem3_4_5_BarrackWars.core.CommandInterpreterImpl;
import problem3_4_5_BarrackWars.core.Engine;
import problem3_4_5_BarrackWars.core.factories.UnitFactoryImpl;
import problem3_4_5_BarrackWars.data.UnitRepository;

public class Main {

    public static void main(String[] args) {
        Repository repository = new UnitRepository();
        UnitFactory unitFactory = new UnitFactoryImpl();

        CommandInterpreter commandInterpreter = new CommandInterpreterImpl(repository, unitFactory);

        Runnable engine = new Engine(commandInterpreter, repository, unitFactory);
        engine.run();
    }
}