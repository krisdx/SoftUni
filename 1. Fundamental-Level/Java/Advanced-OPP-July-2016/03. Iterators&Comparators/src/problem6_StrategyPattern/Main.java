package problem6_StrategyPattern;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        Set<TestPerson> peopleByName = new TreeSet<>(new NameComparator());
        Set<TestPerson> peopleByAge = new TreeSet<>(new AgeComparator());

        int n = Integer.valueOf(reader.readLine());
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            String name = lineArgs[0];
            int age = Integer.valueOf(lineArgs[1]);

            TestPerson person = new TestPerson(name, age);
            peopleByName.add(person);
            peopleByAge.add(person);
        }

        for (TestPerson person : peopleByName) {
            System.out.println(person);
        }

        for (TestPerson person : peopleByAge) {
            System.out.println(person);
        }
    }
}