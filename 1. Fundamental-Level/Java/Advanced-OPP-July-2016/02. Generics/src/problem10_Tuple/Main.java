package problem10_Tuple;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );

        String[] lineArgs = reader.readLine().split("\\s+");
        String person = lineArgs[0] + " " + lineArgs[1];
        String address = lineArgs[2];
        Tuple<String, String> personAndAddress = new Tuple<>(person, address);
        System.out.println(personAndAddress);

        lineArgs = reader.readLine().split("\\s+");
        String name = lineArgs[0];
        int beerAmount = Integer.valueOf(lineArgs[1]);
        Tuple<String, Integer> personAndBeerAmount= new Tuple<>(name, beerAmount);
        System.out.println(personAndBeerAmount);

        lineArgs = reader.readLine().split("\\s+");
        Integer integer = Integer.valueOf(lineArgs[0]);
        Double floatingPointNumber = Double.valueOf(lineArgs[1]);
        Tuple<Integer, Double> intgerAndDouble = new Tuple<>(integer, floatingPointNumber);
        System.out.println(intgerAndDouble);
    }
}
