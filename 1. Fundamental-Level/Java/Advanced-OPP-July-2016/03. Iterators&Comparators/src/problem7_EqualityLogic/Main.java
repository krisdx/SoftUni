package problem7_EqualityLogic;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashSet;
import java.util.Set;
import java.util.TreeSet;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        Set<Human> treeSet = new TreeSet<>();
        Set<Human> hashSet = new HashSet<>();

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String name = lineArgs[0];
            int age = Integer.valueOf(lineArgs[1]);

            Human person = new Human(name, age);
            treeSet.add(person);
            hashSet.add(person);
        }

        System.out.println(treeSet.size());
        System.out.println(hashSet.size());
    }
}
