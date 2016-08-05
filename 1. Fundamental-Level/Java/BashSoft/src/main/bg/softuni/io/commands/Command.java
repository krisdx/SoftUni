package main.bg.softuni.io.commands;

import main.bg.softuni.contracts.Executable;
import main.bg.softuni.exceptions.InvalidInputException;

public abstract class Command implements Executable {

    private String input;
    private String[] data;

    protected Command(String input, String[] data) {
        this.setInput(input);
        this.setData(data);
    }

    protected String getInput() {
        return this.input;
    }

    private void setInput(String input) {
        if (input == null || input.equals("")) {
            throw new InvalidInputException(this.input);
        }

        this.input = input;
    }

    protected String[] getData() {
        return this.data;
    }

    private void setData(String[] data) {
        if (data == null || data.length < 1) {
            throw new InvalidInputException(this.input);
        }

        this.data = data;
    }
}