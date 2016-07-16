package IO;

import contracts.Printable;

public class OutputWriter implements Printable {

    @Override
    public void printLine(String message) {
        System.out.println(message);
    }

    public void printLine() {
        System.out.println();
    }

    @Override
    public void print(String message) {
        System.out.print(message);
    }

    @Override
    public void printException(String message) {
        System.out.println(message);
    }
}