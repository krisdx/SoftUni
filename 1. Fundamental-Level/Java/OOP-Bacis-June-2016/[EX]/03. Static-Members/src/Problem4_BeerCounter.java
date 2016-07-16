import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Problem4_BeerCounter {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        while (true) {
            String line = reader.readLine();
            if (line.equals("End")) {
                break;
            }

            String[] lineArgs = line.split("\\s+");
            int bougthCount = Integer.valueOf(lineArgs[0]);
            BeerCounter.buyBeer(bougthCount);
            int drankCount = Integer.valueOf(lineArgs[1]);
            BeerCounter.drinkBeer(drankCount);
        }

        System.out.print(BeerCounter.beerInStock);
        System.out.print(" ");
        System.out.println(BeerCounter.beerDrankCount);
    }
}

class BeerCounter {
    public static int beerInStock;
    public static int beerDrankCount;

    public static void buyBeer(int count) {
        beerInStock += count;
    }

    public static void drinkBeer(int count) {
        beerDrankCount += count;
        beerInStock -= count;
    }
}