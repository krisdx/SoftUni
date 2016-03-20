package Advanced_CSharp_Exam_11_October_2015;

import java.util.Scanner;
import java.util.ArrayList;
import java.util.Collections;

public class Problem1_ArrayManipulator {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] numbersInString = input.nextLine().split("\\s+");
        ArrayList<Integer> numbers = new ArrayList<>();
        for (int i = 0; i < numbersInString.length; i++) {
            numbers.add(Integer.parseInt(numbersInString[i]));
        }

        while (true) {
            String command = input.nextLine();
            if (command.equals("end")) {
                break;
            }

            String[] commandDetails = command.split("\\s+");
            String action = commandDetails[0];
            if (action.equals("exchange")) {
                int index = Integer.parseInt(commandDetails[1]);
                if (index < 0 || index >= numbers.size()) {
                    System.out.println("Invalid index");
                    continue;
                }

                ArrayList<Integer> resultNumbers = new ArrayList<>();
                for (int i = index + 1; i < numbers.size(); i++) {
                    resultNumbers.add(numbers.get(i));
                }
                for (int i = 0; i <= index; i++) {
                    resultNumbers.add(numbers.get(i));
                }

                for (int i = 0; i < resultNumbers.size(); i++) {
                    numbers.set(i, resultNumbers.get(i));
                }
            } else if (action.equals("max")) {
                String oddOrEven = commandDetails[1];

                int maxOddOrEvenNumber = Integer.MIN_VALUE;
                int index = 0;
                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i) % 2 == 1 &&
                            numbers.get(i) >= maxOddOrEvenNumber &&
                            oddOrEven.equals("odd")) {
                        maxOddOrEvenNumber = numbers.get(i);
                        index = i;
                    } else if (numbers.get(i) % 2 == 0 &&
                            numbers.get(i) >= maxOddOrEvenNumber &&
                            oddOrEven.equals("even")) {
                        maxOddOrEvenNumber = numbers.get(i);
                        index = i;
                    }
                }

                if (maxOddOrEvenNumber == Integer.MIN_VALUE) {
                    System.out.println("No matches");
                } else {
                    System.out.println(index);
                }
            } else if (action.equals("min")) {
                String oddOrEven = commandDetails[1];

                int maxOddOrEvenNumber = Integer.MAX_VALUE;
                int index = 0;
                for (int i = 0; i < numbers.size(); i++) {
                    if (numbers.get(i) % 2 == 1 &&
                            numbers.get(i) <= maxOddOrEvenNumber &&
                            oddOrEven.equals("odd")) {
                        maxOddOrEvenNumber = numbers.get(i);
                        index = i;
                    } else if (numbers.get(i) % 2 == 0 &&
                            numbers.get(i) <= maxOddOrEvenNumber &&
                            oddOrEven.equals("even")) {
                        maxOddOrEvenNumber = numbers.get(i);
                        index = i;
                    }
                }

                if (maxOddOrEvenNumber == Integer.MAX_VALUE) {
                    System.out.println("No matches");
                } else {
                    System.out.println(index);
                }
            } else if (action.equals("first")) {
                int count = Integer.parseInt(commandDetails[1]);
                if (count < 0 || count > numbers.size()) {
                    System.out.println("Invalid count");
                    continue;
                }
                String oddOrEven = commandDetails[2];

                ArrayList<Integer> firstElements = new ArrayList<>();
                for (int i = 0; i < numbers.size(); i++) {
                    if ((numbers.get(i) % 2 == 1 && oddOrEven.equals("odd")) ||
                            (numbers.get(i) % 2 == 0 && oddOrEven.equals("even"))) {
                        firstElements.add(numbers.get(i));
                    }

                    if (firstElements.size() == count) {
                        break;
                    }
                }

                if (firstElements.size() == 0) {
                    System.out.println("[]");
                } else {
                    System.out.println(firstElements);
                }
            }else if(action.equals("last")){
                int count = Integer.parseInt(commandDetails[1]);
                if (count < 0 || count > numbers.size()) {
                    System.out.println("Invalid count");
                    continue;
                }
                String oddOrEven = commandDetails[2];

                ArrayList<Integer> lastElements = new ArrayList<>();
                for (int i = numbers.size() - 1; i >= 0; i--) {
                    if ((numbers.get(i) % 2 == 1 && oddOrEven.equals("odd")) ||
                            (numbers.get(i) % 2 == 0 && oddOrEven.equals("even"))) {
                        lastElements.add(numbers.get(i));
                    }

                    if (lastElements.size() == count) {
                        break;
                    }
                }

                if (lastElements.size() == 0) {
                    System.out.println("[]");
                } else {
                    Collections.reverse(lastElements);
                    System.out.println(lastElements);
                }
            }
        }

        System.out.println(numbers);
    }
}