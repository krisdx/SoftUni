package setsAndMaps;

import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem5_Phonebook {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Map<String, String> phonebook = new TreeMap<>();
        while (true) {
            String inputLine = input.nextLine();
            if (inputLine.equals("search")) {
                break;
            }

            String[] inputParams = inputLine.split("-");
            String personName = inputParams[0];
            String phoneNumber = inputParams[1];
            if (!phonebook.containsKey(personName)) {
                phonebook.put(personName, phoneNumber);
            } else {
                String newPhoneNumber = phoneNumber;
                phonebook.put(personName, newPhoneNumber);
            }
        }

        while (true) {
            String nameToFind = input.nextLine();
            if (nameToFind.equals("stop")) {
                break;
            }

            if (phonebook.containsKey(nameToFind)) {
                System.out.printf("%s -> %s\n", nameToFind, phonebook.get(nameToFind));
            } else {
                System.out.printf("Contact %s does not exist.\n", nameToFind);
            }
        }
    }
}