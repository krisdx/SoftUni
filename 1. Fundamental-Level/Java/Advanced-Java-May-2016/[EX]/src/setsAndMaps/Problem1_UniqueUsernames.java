package setsAndMaps;

import java.util.*;

public class Problem1_UniqueUsernames {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Set<String> hashSet = new LinkedHashSet<>();

        int n = Integer.parseInt(input.nextLine());
        for (int i = 0; i < n; i++) {
            String username = input.nextLine();
            if (!hashSet.contains(username)) {
                hashSet.add(username);
            }
        }

        for (String username : hashSet) {
            System.out.println(username);
        }
    }
}