package problem10_11_12_13_InfernoInfinity.contracts;

import problem10_11_12_13_InfernoInfinity.contracts.IO.Printable;
import problem10_11_12_13_InfernoInfinity.contracts.IO.Readable;
import problem10_11_12_13_InfernoInfinity.contracts.databese.Database;
import problem10_11_12_13_InfernoInfinity.contracts.factories.GemFactory;
import problem10_11_12_13_InfernoInfinity.contracts.factories.WeaponFactory;

public interface Engine extends Runnable {

    Readable getReader();

    Printable getWriter();

    WeaponFactory getWeaponFactory();

    GemFactory getGemFactory();

    Database getDatabase();

    void stop();
}