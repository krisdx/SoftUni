package Advanced_CSharp_Exam_11_October_2015;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem3_ShmoogleCounter {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        Pattern pattern = Pattern.compile("(int|double)\\s+([a-z][a-zA-Z]*)");

        ArrayList<String> integers = new ArrayList<>();
        ArrayList<String> doubles = new ArrayList<>();
        while (true) {
            String line = input.nextLine();
            if (line.equals("//END_OF_CODE")) {
                break;
            }

            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                if (matcher.group(1).equals("int")) {
                    integers.add(matcher.group(2));
                } else {
                    doubles.add(matcher.group(2));
                }
            }
        }

        System.out.print("Doubles: ");
        if (doubles.size() == 0) {
            System.out.println("None");
        } else {
            Collections.sort(doubles);

            for (int i = 0; i < doubles.size(); i++) {
                if (i + 1 == doubles.size()) {
                    System.out.println(doubles.get(i));
                } else {
                    System.out.print(doubles.get(i) + ", ");
                }
            }
        }

        System.out.print("Ints: ");
        if (integers.size() == 0) {
            System.out.println("None");
        } else {
            Collections.sort(integers);

            for (int i = 0; i < integers.size(); i++) {
                if (i + 1 == integers.size()) {
                    System.out.print(integers.get(i));
                } else {
                    System.out.print(integers.get(i) + ", ");
                }
            }
        }
    }
}