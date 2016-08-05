package problem10_11_12_13_InfernoInfinity;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.IO.Printable;
import problem10_11_12_13_InfernoInfinity.contracts.IO.Readable;
import problem10_11_12_13_InfernoInfinity.contracts.databese.Database;
import problem10_11_12_13_InfernoInfinity.contracts.factories.GemFactory;
import problem10_11_12_13_InfernoInfinity.contracts.factories.WeaponFactory;
import problem10_11_12_13_InfernoInfinity.core.InfernoEngine;
import problem10_11_12_13_InfernoInfinity.core.factories.GemFactoryImpl;
import problem10_11_12_13_InfernoInfinity.core.factories.WeaponFactoryImpl;
import problem10_11_12_13_InfernoInfinity.data.InfernoDatabase;
import problem10_11_12_13_InfernoInfinity.io.ConsoleReader;
import problem10_11_12_13_InfernoInfinity.io.ConsoleWriter;

public class Main {

    public static void main(String[] args) {

        Printable writer = new ConsoleWriter();
        Readable reader = new ConsoleReader();

        WeaponFactory weaponFactory = new WeaponFactoryImpl();
        GemFactory gemFactory = new GemFactoryImpl();

        Database database = new InfernoDatabase();

        Engine engine = new InfernoEngine(
                reader, writer,
                weaponFactory, gemFactory,
                database);
        engine.run();
    }
}