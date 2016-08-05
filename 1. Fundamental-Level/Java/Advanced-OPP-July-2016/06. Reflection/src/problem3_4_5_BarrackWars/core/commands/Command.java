package problem3_4_5_BarrackWars.core.commands;

import problem3_4_5_BarrackWars.contracts.Executable;

public abstract class Command implements Executable {

    private String[] data;

    protected Command(String[] data) {
        this.data = data;
    }

    protected String[] getData() {
        return this.data;
    }
}