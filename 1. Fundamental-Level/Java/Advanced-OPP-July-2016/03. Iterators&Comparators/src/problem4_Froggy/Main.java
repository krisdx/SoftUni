package problem4_Froggy;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        List<Integer> numbers = new ArrayList<>();
        String[] lineArgs = reader.readLine().split("[\\s,]+");
        for (int i = 0; i < lineArgs.length; i++) {
            numbers.add(Integer.valueOf(lineArgs[i]));
        }

        Lake<Integer> lake = new Lake<>(numbers);
        int index = 0;
        for (Integer number : lake) {
            if (index + 1 == numbers.size()) {
                System.out.print(number);
            } else {
                System.out.print(number + ", ");
            }

            index++;
        }
    }
}