package problem1_CardSuit;

public class Main {
    public static void main(String[] args) {
        System.out.println("Card Suits:");

        CardSuits[] cardSuits = CardSuits.values();
        for (CardSuits cardSuit : cardSuits) {
            System.out.printf("Ordinal value: %d; Name value: %s%n", cardSuit.ordinal(), cardSuit);
        }
    }
}