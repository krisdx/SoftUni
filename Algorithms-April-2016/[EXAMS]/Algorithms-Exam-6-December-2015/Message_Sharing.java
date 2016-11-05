import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Message_Sharing {

    private static Map<Person, List<Person>> graph;
    private static Map<String, Boolean> visited;

    public static void main(String[] args) throws IOException {
        List<Person> peopleWithMessage = buildGraph();
        bfs(peopleWithMessage);
    }

    private static List<Person> buildGraph() throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        Map<String, Person> people = new HashMap<>();
        visited = new HashMap<>();
        graph = new LinkedHashMap<>();
        String[] peopleNames = reader.readLine().split("[:,\\s]+");
        for (int i = 1; i < peopleNames.length; i++) {
            Person person = new Person(peopleNames[i]);
            people.put(person.getName(), person);
            graph.put(person, new ArrayList<>());
            visited.put(peopleNames[i], false);
        }

        String[] peopleConnections = reader.readLine().split("[:,\\-\\s]+");
        for (int i = 1; i < peopleConnections.length - 1; i += 2) {
            Person firstPerson = people.get(peopleConnections[i]);
            Person secondPerson = people.get(peopleConnections[i + 1]);

            graph.get(firstPerson).add(secondPerson);
            graph.get(secondPerson).add(firstPerson);
        }

        List<Person> peopleWithMessage = new ArrayList<>();
        String[] startPeople = reader.readLine().split("[:,\\-\\s]+");
        for (int i = 1; i < startPeople.length; i++) {
            Person person = people.get(startPeople[i]);
            peopleWithMessage.add(person);
        }

        return peopleWithMessage;
    }

    private static void bfs(List<Person> peopleWithMessage) {
        Queue<Person> queue = new ArrayDeque<>();

        queue.addAll(peopleWithMessage);
        for (Person aPeopleWithMessage : peopleWithMessage) {
            visited.put(aPeopleWithMessage.getName(), true);
        }

        int masStepsCount = 0;
        Map<Integer, List<Person>> lastPeopleByStepsCount = new HashMap<>();
        while (queue.size() > 0) {
            Person currentPerson = queue.poll();
            if (currentPerson.getCount() >= masStepsCount) {
                masStepsCount = currentPerson.getCount();
                if (!lastPeopleByStepsCount.containsKey(masStepsCount)) {
                    lastPeopleByStepsCount.put(masStepsCount, new ArrayList<>());
                }

                lastPeopleByStepsCount.get(masStepsCount).add(currentPerson);
            }

            for (Person friend : graph.get(currentPerson)) {
                if (!visited.get(friend.getName())) {
                    visited.put(friend.getName(), true);
                    friend.setCount(currentPerson.getCount() + 1);
                    queue.add(friend);
                }
            }
        }

        List<String> unreachablePeople = new ArrayList<>();
        for (Map.Entry<String, Boolean> person : visited.entrySet()) {
            if (!person.getValue()) {
                unreachablePeople.add(person.getKey());
            }
        }

        if (unreachablePeople.size() > 0) {
            System.out.print("Cannot reach: ");
            Collections.sort(unreachablePeople);
            System.out.println(String.join(", ", unreachablePeople));
            return;
        }

        System.out.printf("All people reached in %d steps%n", masStepsCount);
        System.out.print("People at last step: ");
        Collections.sort(lastPeopleByStepsCount.get(masStepsCount));
        for (int i = 0; i < lastPeopleByStepsCount.get(masStepsCount).size(); i++) {
            if (i + 1 == lastPeopleByStepsCount.get(masStepsCount).size()) {
                System.out.print(lastPeopleByStepsCount.get(masStepsCount).get(i));
            } else {
                System.out.print(lastPeopleByStepsCount.get(masStepsCount).get(i) + ", ");
            }
        }
    }
}

class Person implements Comparable<Person> {
    private int count;
    private String name;

    Person(String name) {
        this.name = name;
    }

    int getCount() {
        return this.count;
    }

    void setCount(int count) {
        this.count = count;
    }

    String getName() {
        return this.name;
    }

    @Override
    public String toString() {
        return this.getName();
    }

    @Override
    public int compareTo(Person other) {
        return this.getName().compareTo(other.getName());
    }
}