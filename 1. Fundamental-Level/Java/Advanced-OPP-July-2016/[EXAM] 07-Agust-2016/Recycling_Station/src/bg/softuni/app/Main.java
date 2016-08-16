package bg.softuni.app;

import bg.softuni.app.core.EngimeImpl;
import bg.softuni.app.core.Engine;
import bg.softuni.app.core.factory.garbageFactory.GarbageFactory;
import bg.softuni.app.core.factory.garbageFactory.GarbageFactoryImpl;
import bg.softuni.app.core.io.CommandInterpreter;
import bg.softuni.app.core.io.CommandInterpreterImpl;
import bg.softuni.app.core.io.reader.ConsoleReader;
import bg.softuni.app.core.io.reader.Reader;
import bg.softuni.app.core.io.writer.ConsoleWriter;
import bg.softuni.app.core.io.writer.Writer;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.data.Database;
import bg.softuni.app.framework.contracts.GarbageManager;
import bg.softuni.app.framework.contracts.GarbageProcessor;
import bg.softuni.app.framework.contracts.StrategyHolder;
import bg.softuni.app.framework.garbageProcessor.GarbageProcessorImpl;
import bg.softuni.app.framework.strategyHolder.StrategyHolderImpl;
import bg.softuni.app.models.GarbageManagerImpl;

public class Main {

    public static void main(String[] args) {

        Writer writer = new ConsoleWriter();
        Reader reader = new ConsoleReader();

        GarbageFactory garbageFactory = new GarbageFactoryImpl();

        GarbageManager garbageManager = new GarbageManagerImpl();
        DataProvider database = new Database(garbageManager);

        StrategyHolder strategyHolder = new StrategyHolderImpl() ;
        GarbageProcessor garbageProcessor = new GarbageProcessorImpl(strategyHolder);

        CommandInterpreter commandInterpreter = new CommandInterpreterImpl(
                garbageFactory,
                database,
                garbageProcessor);

        Engine engine = new EngimeImpl(reader,writer,commandInterpreter);
        engine.run();
    }
}