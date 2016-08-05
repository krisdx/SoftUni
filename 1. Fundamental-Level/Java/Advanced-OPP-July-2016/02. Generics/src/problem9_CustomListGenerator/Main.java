package problem9_CustomListGenerator;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        CustomIterableList<String> customIterableList = new CustomIterableListImpl<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String commandResult =
                    CommandInterpreter.executeCommand(line, customIterableList);
            if (!commandResult.equals("")) {
                System.out.println(commandResult);
            }
        }
    }
}