package setsAndMaps;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Problem7_FixEmails {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, String> map = new LinkedHashMap<>();
        while (true){
            String personName = input.nextLine();
            if (personName.equals("stop")){
                break;
            }

            String email = input.nextLine();
            if (email.endsWith("uk") || email.endsWith("us")){
                continue;
            }else{
                map.put(personName, email);
            }
        }

        for (Map.Entry<String, String> entry : map.entrySet()) {
            System.out.printf("%s -> %s\n", entry.getKey(), entry.getValue());
        }
    }
}