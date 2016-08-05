package bg.softuni.app;

import bg.softuni.app.core.Engine;
import bg.softuni.app.core.LambdaCoreEngine;
import bg.softuni.app.core.factory.coreFactory.CoreFactory;
import bg.softuni.app.core.factory.coreFactory.CoreFactoryImpl;
import bg.softuni.app.core.factory.fragmentFactory.FragmentFactory;
import bg.softuni.app.core.factory.fragmentFactory.FragmentFactoryImpl;
import bg.softuni.app.core.io.CommandInterpreter;
import bg.softuni.app.core.io.CommandInterpreterImpl;
import bg.softuni.app.core.io.reader.ConsoleReader;
import bg.softuni.app.core.io.reader.Reader;
import bg.softuni.app.core.io.writer.ConsoleWriter;
import bg.softuni.app.core.io.writer.Writer;
import bg.softuni.app.data.DataProvider;
import bg.softuni.app.data.LambdaCoreDatabase;

public class Main {

    public static void main(String[] args) {

        FragmentFactory fragmentFactory = new FragmentFactoryImpl();
        CoreFactory coreFactory = new CoreFactoryImpl();
        DataProvider database = new LambdaCoreDatabase();

        CommandInterpreter commandInterpreter = new CommandInterpreterImpl(
                coreFactory,
                fragmentFactory,
                database);

        Writer writer = new ConsoleWriter();
        Reader reader = new ConsoleReader();

        Engine engine = new LambdaCoreEngine(reader, writer, commandInterpreter);
        engine.run();
    }
}