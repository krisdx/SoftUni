package problem8_CustomListSorter;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        CustomSortableList<String> customList = new CustomSortableListImpl<>();
        while (true) {
            String line = scanner.nextLine();
            if (line.equals("END")) {
                break;
            }

            String commandResult =
                    CommandInterpreter.executeCommand(line, customList);
            if (!commandResult.equals("")) {
                System.out.println(commandResult);
            }
        }
    }
}