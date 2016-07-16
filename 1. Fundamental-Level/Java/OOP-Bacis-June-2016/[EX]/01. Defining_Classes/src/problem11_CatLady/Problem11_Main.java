package problem11_CatLady;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Problem11_Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        Map<String, Cat> cats = new HashMap<>();

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            String type = lineArgs[0];
            String name = lineArgs[1];
            String argument = lineArgs[2];

            Cat cat = null;
            if (type.equals("Siamese")) {
                cat = new SiameseCat(name, argument);
            } else if (type.equals("Cymric")) {
                cat = new CymricCat(name, argument);
            } else {
                cat = new StreetExtraordinaireCat(name, argument);
            }

            cats.put(name, cat);
        }

        String catToPrint = reader.readLine();
        System.out.println(cats.get(catToPrint));
    }
}