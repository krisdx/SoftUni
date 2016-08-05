package problem5_CardCompareTo;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String firstCardRank = scanner.nextLine();
        String firstCardSuit = scanner.nextLine();
        CardRankPower firstCardRankPower = CardRankPower.valueOf(firstCardRank);
        CardSuitsPower firstSuitRankPower = CardSuitsPower.valueOf(firstCardSuit);
        Card firstCard = new Card(firstCardRankPower, firstSuitRankPower);

        String secondCardRank = scanner.nextLine();
        String secondCardSuit = scanner.nextLine();
        CardRankPower secondCardRankPower = CardRankPower.valueOf(secondCardRank);
        CardSuitsPower secondSuitRankPower = CardSuitsPower.valueOf(secondCardSuit);
        Card secondCard = new Card(secondCardRankPower, secondSuitRankPower);

        int compareResult = firstCard.compareTo(secondCard);
        if (compareResult >= 0) {
            System.out.println(firstCard);
        } else {
            System.out.println(secondCard);
        }
    }
}