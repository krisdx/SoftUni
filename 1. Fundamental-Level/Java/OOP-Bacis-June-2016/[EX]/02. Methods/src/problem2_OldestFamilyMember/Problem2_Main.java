package problem2_OldestFamilyMember;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Method;

public class Problem2_Main {
    public static void main(String[] args) throws IOException, ClassNotFoundException, NoSuchMethodException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        int n = Integer.valueOf(reader.readLine());
        Family family = new Family();
        for (int i = 0; i < n; i++) {
            String[] lineArgs = reader.readLine().split("\\s+");
            Person person = new Person(lineArgs[0], Integer.valueOf(lineArgs[1]));
            family.addMember(person);
        }
        System.out.println(family.getOldestMember());

        Method getOldestMethod = Class.forName("Family").getMethod("getOldestMember");
        Method addMemberMethod = Class.forName("Family").getMethod("addFamilyMember", Person.class);
    }
}