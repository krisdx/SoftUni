package problem2_CardRank;

public class Main {
    public static void main(String[] args) {
        System.out.println("Card Ranks:");

        CardRank[] cardSuits = CardRank.values();
        for (CardRank cardRank : cardSuits) {
            System.out.printf("Ordinal value: %d; Name value: %s%n", cardRank.ordinal(), cardRank);
        }
    }
}