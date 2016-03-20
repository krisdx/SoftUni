package Advanced_CSharp_Exam_31_May_2015;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.Scanner;

public class Problem1_CommandInterpreter {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] numbersInString = input.nextLine().split("\\s+");
        ArrayList<String> elements = new ArrayList<>();
        for (int i = 0; i < numbersInString.length; i++) {
            elements.add(numbersInString[i]);
        }

        while (true) {
            String line = input.nextLine();
            if (line.equals("end")) {
                break;
            }

            String[] commandDetails = line.split("\\s+");
            String commandTye = commandDetails[0];
            if (commandTye.equals("reverse")) {
                int startIndex = Integer.parseInt(commandDetails[2]);
                if (startIndex < 0 || startIndex >= elements.size()) {
                    System.out.println("Invalid input parameters.");
                    continue;
                }

                reverse(elements, commandDetails[4], startIndex);
            } else if (commandTye.equals("sort")) {
                int startIndex = Integer.parseInt(commandDetails[2]);
                if (startIndex < 0 || startIndex >= elements.size()) {
                    System.out.println("Invalid input parameters.");
                    continue;
                }

                sort(elements, commandDetails[4], startIndex);
            } else if (commandTye.equals("rollLeft")) {
                int count = Integer.parseInt(commandDetails[1]);
                if (count < 0) {
                    System.out.println("Invalid input parameters.");
                    continue;
                }

                for (int i = 0; i < count; i++) {
                    rollRight(elements);
                }
            } else if (commandTye.equals("rollRight")) {
                int count = Integer.parseInt(commandDetails[1]) % elements.size();
                if (count < 0) {
                    System.out.println("Invalid input parameters.");
                    continue;
                }

                for (int i = 0; i < count; i++) {
                    rollLeft(elements);
                }
                System.out.println(elements);
            }
        }

        System.out.println(elements);
    }

    private static void rollLeft(ArrayList<String> elements) {
        String lastElement = elements.get(elements.size() - 1);
        elements.remove(elements.size() - 1);
        elements.add(0, lastElement);
    }

    private static void rollRight(ArrayList<String> elements) {
        String firstElements = elements.get(0);
        elements.remove(0);
        elements.add(elements.size(), firstElements);
    }

    private static void sort(ArrayList<String> elements, String commandDetail, int startIndex) {
        int count = Integer.parseInt(commandDetail);
        if (startIndex + count > elements.size() || count < 0) {
            System.out.println("Invalid input parameters.");
            return;
        }

        ArrayList<String> subNumberArray = new ArrayList<>();
        for (int i = startIndex; i < startIndex + count; i++) {
            subNumberArray.add(elements.get(i));
        }

        Collections.sort(subNumberArray, Comparator.<String>naturalOrder());
        int index = startIndex;
        for (int i = 0; i < subNumberArray.size(); i++) {
            elements.set(index, subNumberArray.get(i));
            index++;
        }
    }

    private static void reverse(ArrayList<String> elements, String commandDetail, int startIndex) {
        int count = Integer.parseInt(commandDetail);
        if (startIndex + count > elements.size() || count < 0) {
            System.out.println("Invalid input parameters.");
            return;
        }

        ArrayList<String> subNumberArray = new ArrayList<>();
        for (int i = startIndex; i < startIndex + count; i++) {
            subNumberArray.add(elements.get(i));
        }

        Collections.reverse(subNumberArray);
        int index = 0;
        for (int i = startIndex; i < startIndex + count; i++) {
            elements.set(i, subNumberArray.get(index));
            index++;
        }
    }
}