package problem3_CardPowers;

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

        String rank = reader.readLine();
        String suit = reader.readLine();
        int rankPower = Enum.valueOf(CardRankPower.class, rank).getPower();
        int suitsPower = CardSuitsPower.valueOf(suit).getPower();

        System.out.printf("Card name: %s of %s; Card power: %d",
                rank, suit, rankPower + suitsPower);
    }
}