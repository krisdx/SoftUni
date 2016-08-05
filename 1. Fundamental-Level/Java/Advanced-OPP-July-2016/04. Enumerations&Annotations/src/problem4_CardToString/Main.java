package problem4_CardToString;

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

        Card card = new Card(rank, suit, rankPower, suitsPower);
        System.out.println(card);
    }
}
