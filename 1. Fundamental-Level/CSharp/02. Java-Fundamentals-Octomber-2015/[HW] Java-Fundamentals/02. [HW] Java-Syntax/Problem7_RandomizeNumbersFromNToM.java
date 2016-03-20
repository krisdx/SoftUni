import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class Problem7_RandomizeNumbersFromNToM {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();
        int m = input.nextInt();

        Random randomGenerator = new Random();
        List<Integer> randomNumbers = new ArrayList<>();
        for (int i = Math.min(n, m); i < Math.max(n, m) + 1; i++) {
            int randomNumber = randomGenerator.nextInt((Math.abs(n - m) + 1) + Math.min(n, m));
            while (randomNumbers.contains(randomNumber)){
                randomNumber = randomGenerator.nextInt((Math.abs(n - m) + 1) + Math.min(n, m));
            }

            randomNumbers.add(randomNumber);
        }

        System.out.println(randomNumbers);
    }
}