import java.util.Scanner;

public class Problem2_GrandTheftExamo {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = input.nextInt();

        int slappedThieves = 0;
        long thievesEscaped = 0;
        long totalBeersCount = 0;
        for (int i = 0; i < n; i++) {
            long amountOfThieves = input.nextInt();
            long beers = input.nextInt();
            if (amountOfThieves <= 5){
                slappedThieves += amountOfThieves;
            }else {
            slappedThieves += 5;
                thievesEscaped += amountOfThieves - 5;
            }

            totalBeersCount += beers;
        }

        System.out.printf("%s thieves slapped.\n", slappedThieves);
        System.out.printf("%s thieves escaped.\n", thievesEscaped);
        System.out.printf("%s packs, %s bottles.",
                totalBeersCount / 6, totalBeersCount % 6);
    }
}