package problem10_11_12_13_InfernoInfinity.io;

import problem10_11_12_13_InfernoInfinity.contracts.IO.Printable;

public class ConsoleWriter implements Printable {

    @Override
    public void print(String message) {
        System.out.print(message);
    }

    @Override
    public void printLine(String message) {
        System.out.println(message);
    }

    @Override
    public void displayException(String exceptionMessage) {
        System.err.println(exceptionMessage);
    }
}