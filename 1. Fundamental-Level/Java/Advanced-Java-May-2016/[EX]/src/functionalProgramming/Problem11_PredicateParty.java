package functionalProgramming;

import java.util.*;
import java.util.function.Predicate;

public class Problem11_PredicateParty {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("\\s+");
        List<String> people = new ArrayList<>();
        for (int i = 0; i < input.length; i++) {
            people.add(input[i]);
        }

        while (true) {
            String command = scanner.nextLine();
            if (command.equals("Party!")) {
                break;
            }

            String[] commandArgs = command.split("\\s+");
            String action = commandArgs[0];
            String firstParam = commandArgs[1];
            String secondParam = commandArgs[2];

            Predicate<String> predicate = getPredicate(firstParam, secondParam);

            if (action.equals("Remove")) {
                people = removePeople(people, predicate);
            } else if (action.equals("Double")) {
                people = doublePeople(people, predicate);
            }
        }

        if (people.size() > 0) {
            String result = String.join(", ", people);
            System.out.println(result + " are going to the party!");
        } else {
            System.out.println("Nobody is going to the party!");
        }
    }

    private static List<String> doublePeople(List<String> people, Predicate<String> predicate) {
        List<String> tempList = new ArrayList<>(people);

        for (int i = 0; i < people.size(); i++) {
            if (predicate.test(people.get(i))) {
                tempList.add(i, people.get(i));
            }
        }

        return tempList;
    }

    private static List<String> removePeople(List<String> people, Predicate<String> predicate) {
        List<String> tempList = new ArrayList<>(people);

        for (String person : people) {
            if (predicate.test(person)) {
                tempList.remove(person);
            }
        }

        return tempList;
    }

    private static Predicate<String> getPredicate(String firstParam, String secondParam) {
        if (firstParam.equals("StartsWith")) {
            return name -> name.startsWith(secondParam);
        } else if (firstParam.equals("EndsWith")) {
            return name -> name.endsWith(secondParam);
        } else {
            int desiredLength = Integer.valueOf(secondParam);
            return name -> name.length() == desiredLength;
        }
    }
}