package problem9_CollectionHierarchy;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Addable addCollection = new AddCollection();
        Addable addRemoveCollection = new AddRemoveCollection();
        Addable myList = new MyList();

        String[] lineArgs = scanner.nextLine().split("\\s+");

        StringBuilder stringBuilder = new StringBuilder();
        addStrings(addCollection, stringBuilder, lineArgs);
        stringBuilder.append(System.lineSeparator());

        addStrings(addRemoveCollection, stringBuilder, lineArgs);
        stringBuilder.append(System.lineSeparator());

        addStrings(myList, stringBuilder, lineArgs);

        System.out.println(stringBuilder);

        stringBuilder = new StringBuilder();
        int removeOperations = Integer.valueOf(scanner.nextLine());
        for (int i = 0; i < removeOperations; i++) {
            String removedElement = ((Removeable) addRemoveCollection).remove();
            stringBuilder.append(removedElement).append(" ");
        }
        stringBuilder.append(System.lineSeparator());
        for (int i = 0; i < removeOperations; i++) {
            String removedElement = ((Removeable) myList).remove();
            stringBuilder.append(removedElement).append(" ");
        }

        System.out.println(stringBuilder);
    }

    private static void addStrings(Addable collection, StringBuilder stringBuilder, String[] lineArgs) {
        for (String arg : lineArgs) {
            int collectionIndex = collection.add(arg);
            stringBuilder.append(collectionIndex).append(" ");
        }
    }
}