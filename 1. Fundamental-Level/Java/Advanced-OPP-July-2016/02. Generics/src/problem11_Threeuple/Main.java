package problem11_Threeuple;

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
        String town= lineArgs[3];
        Threeuple<String, String, String> personAndAddress = new Threeuple<>(person, address, town);
        System.out.println(personAndAddress);

        lineArgs = reader.readLine().split("\\s+");
        String name = lineArgs[0];
        int beerAmount = Integer.valueOf(lineArgs[1]);
        String druntOrNot = lineArgs[2].equals("drunk") ? "true" : "false";
        Threeuple<String, Integer, String> personAndBeerAmount= new Threeuple<>(name, beerAmount, druntOrNot);
        System.out.println(personAndBeerAmount);

        lineArgs = reader.readLine().split("\\s+");
        name = lineArgs[0];
        Double accountBalance= Double.valueOf(lineArgs[1]);
        String accountName = lineArgs[2];
        Threeuple<String, Double, String> accountInfo = new Threeuple<>(name, accountBalance, accountName);
        System.out.println(accountInfo);
    }
}
