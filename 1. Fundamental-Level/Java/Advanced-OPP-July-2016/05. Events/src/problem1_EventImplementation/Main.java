package problem1_EventImplementation;

import problem1_EventImplementation.contracts.Observable;
import problem1_EventImplementation.contracts.Observer;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Dispatcher dispatcher = new Dispatcher(null);
        Observer observer = new Handler();
        dispatcher.addNameChangeListener(observer);

        while (true) {
            String name = scanner.nextLine();
            if (name.equalsIgnoreCase("end")) {
                break;
            }

            dispatcher.setName(name);
        }
    }
}