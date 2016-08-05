package problem10_11_12_13_InfernoInfinity.core.commands;

import problem10_11_12_13_InfernoInfinity.contracts.Engine;
import problem10_11_12_13_InfernoInfinity.contracts.Executable;

public abstract class Command implements Executable {

    private Engine engine;

    protected Command(Engine engine) {
        this.engine = engine;
    }

    public Engine getEngine() {
        return this.engine;
    }
}