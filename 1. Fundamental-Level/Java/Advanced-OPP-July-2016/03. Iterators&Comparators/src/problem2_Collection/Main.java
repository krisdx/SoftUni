package problem2_Collection;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main { // Not finished
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        CustomIterableInterface<String> customIterator = null;
        while (true) {
            String line = reader.readLine();
            if (line.equals("END")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String command = lineArgs[0];
            if (command.equals("Create")) {
                List<String> elements = new ArrayList<>();
                for (int i = 1; i < lineArgs.length; i++) {
                    elements.add(lineArgs[i]);
                }

                customIterator = new CustomCollectionIterator<>(elements);
            } else if (command.endsWith("Move")) {
                System.out.println(customIterator.move());
            } else if (command.endsWith("HasNext")) {
                System.out.println(customIterator.hasNext());
            } else if (command.endsWith("Print")) {
                try {
                    System.out.println(customIterator.printCurrentElement());
                } catch (RuntimeException ex) {
                    System.out.println(ex.getMessage());
                }
            } else if (command.equals("PrintAll")) {
               customIterator.printAll();
            }
        }
    }
}
