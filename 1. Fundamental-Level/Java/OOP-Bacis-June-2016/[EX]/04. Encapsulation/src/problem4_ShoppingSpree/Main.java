package problem4_ShoppingSpree;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.LinkedHashMap;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        HashMap<String, Person> customers = new LinkedHashMap<>();
        HashMap<String, Product> products = new HashMap<>();
        String[] peopleArgs = reader.readLine().split(";");
        for (String entry : peopleArgs) {
            String[] params = entry.split("=");
            String name = params[0];
            Double money = Double.valueOf(params[1]);
            try{
                Person person = new Person(name, money);
                customers.put(name, person);
            } catch (IllegalArgumentException ex){
                System.out.println(ex.getMessage());
                return;
            }

        }

        String[] productsArgs = reader.readLine().split(";");
        for (String entry : productsArgs) {
            String[] params = entry.split("=");
            String name = params[0];
            double cost = Double.valueOf(params[1]);
            try{
                Product product = new Product(name, cost);
                products.put(name, product);
            } catch (IllegalArgumentException ex){
                System.out.println(ex.getMessage());
                return;
            }
        }

        while (true){
            String[] input = reader.readLine().split("\\s+");
            if (input[0].equals("END")){
                break;
            }
            Person customer = customers.get(input[0]);
            Product product = products.get(input[1]);

            boolean bought = customer.tryBuyProduct(product);
            if (bought){
                System.out.printf("%s bought %s%n", customer.getName(), product.getName());
            } else {
                System.out.printf("%s can't afford %s%n", customer.getName(), product.getName());
            }
        }

        customers.values().forEach(System.out::println);
    }
}
